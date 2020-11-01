using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedFile;
using SiUpin.Shared.Systems.Commands.SeedUph;

namespace SiUpin.Application.Systems.Commands.SeedUph
{
    public class SeedUphCommandHandler : IRequestHandler<SeedUphRequest, SeedUphResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;
        private IMediator _mediator;

        public SeedUphCommandHandler(ISiUpinDBContext context, IFileService fileService, IMediator mediator)
        {
            _context = context;
            _fileService = fileService;
            _mediator = mediator;
        }

        public async Task<SeedUphResponse> Handle(SeedUphRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedUphResponse();

            var dataJSON = _fileService.ReadJSONFile<UphJSON>(FilePath.UphJSON);

            List<Uph> uphs = new List<Uph>();

            var listDataJSON = dataJSON.rows.ToList();

            // collect temporary data from db
            var provinsis = await _context.Provinsis.ToListAsync(cancellationToken);
            var kotas = await _context.Kotas.ToListAsync(cancellationToken);
            var kecamatans = await _context.Kecamatans.ToListAsync(cancellationToken);
            var kelurahans = await _context.Kelurahans.ToListAsync(cancellationToken);

            var produkOlahans = await _context.ProdukOlahans.ToListAsync(cancellationToken);
            var jenisTernaks = await _context.JenisTernaks.ToListAsync(cancellationToken);

            foreach (var data in listDataJSON)
            {
                Uph uph = new Uph();

#pragma warning disable CS8632
                string? provinsiID, kotaID, kecamatanID, kelurahanID, produkOlahanID, jenisTernakID, sameUphID = "";

                // Check just make sure if data was not duplicated or if uph's data has same id or name
                uph = uphs.Where(x => x.id_uph == data.id_uph || x.Name == data.nama_uph.ToLower())
                    .FirstOrDefault();

                if (uph == null)
                {
                    var getProvinsiID = provinsis.Where(x => x.id_provinsi == data.provinsi).FirstOrDefault();
                    var getKotaID = kotas.Where(x => x.id_kota == data.kabupaten).FirstOrDefault();
                    var getKecamatanID = kecamatans.Where(x => x.id_kecamatan == data.kecamatan).FirstOrDefault();
                    var getKelurahanID = kelurahans.Where(x => x.id_kelurahan == data.desa).FirstOrDefault();

                    provinsiID = getProvinsiID != null ? getProvinsiID.ProvinsiID : null;
                    kotaID = getKotaID != null ? getKotaID.KotaID : null;
                    kecamatanID = getKecamatanID != null ? getKecamatanID.KecamatanID : null;
                    kelurahanID = getKelurahanID != null ? getKelurahanID.KelurahanID : null;

                    uph = new Uph
                    {
                        id_uph = data.id_uph,
                        ProvinsiID = provinsiID,
                        KotaID = kotaID,
                        KecamatanID = kecamatanID,
                        KelurahanID = kelurahanID,

                        Name = data.nama_uph,
                        Ketua = data.nama_ketua,
                        Handphone = data.no_hp,
                        Alamat = data.alamat,
                        TahunBerdiri = data.tahun_berdiri
                    };

                    uphs.Add(uph);

                    _context.Uphs.Add(uph);
                    await _context.SaveChangesAsync(cancellationToken);

                    IList<ParameterJawaban> jawabans = new List<ParameterJawaban>();

                    #region Handle UphParameter
                    jawabans.Add(getJawaban(data.bentuk_lembaga));
                    jawabans.Add(getJawaban(data.badan_hukum));
                    jawabans.Add(getJawaban(data.status_uph));
                    jawabans.Add(getJawaban(data.administrasi));

                    foreach (var jawaban in jawabans)
                    {
                        // there is a problem in here !!!!!!!!!!!!!!!
                        if (jawaban != null)
                        {
                            var uphParameter = new UphParameter
                            {
                                Uph = uph,
                                ParameterJawaban = jawaban
                            };

                            _context.UphParameters.Add(uphParameter);
                        }
                        else
                        {
                            System.Console.WriteLine("uphParameter: jawaban was empty");
                        }

                        await _context.SaveChangesAsync(cancellationToken);
                    }
                    #endregion
                }
                else
                {
                    System.Console.WriteLine("uph: same uph was exist");

                    sameUphID = uphs.Where(x => x.id_uph == uph.id_uph).FirstOrDefault().UphID ?? "";
                }

                #region Handle UphProduk
                var getProdukOlahanID = produkOlahans.Where(x => x.Name.Contains(data.produk_olahan)).FirstOrDefault();
                var getJenisTernakID = jenisTernaks.Where(x => x.Name.Contains(data.spesies)).FirstOrDefault();

                produkOlahanID = getProdukOlahanID != null ? getProdukOlahanID.ProdukOlahanID : null;
                jenisTernakID = getJenisTernakID != null ? getJenisTernakID.JenisTernakID : null;

                string uphID = !string.IsNullOrEmpty(sameUphID) ? sameUphID : uph.UphID;

                var uphProduk = new UphProduk
                {
                    UphID = uphID,
                    ProdukOlahanID = produkOlahanID,
                    JenisTernakID = jenisTernakID,

                    Name = data.merk,
                    Description = data.ket_produk
                };

                _context.UphProduks.Add(uphProduk);
                await _context.SaveChangesAsync(cancellationToken);
                #endregion

                #region Handle Foto Produk
                if (!string.IsNullOrEmpty(data.foto) && !string.IsNullOrEmpty(uphID))
                {
                    await _mediator.Send(new SeedFileRequest()
                    {
                        EntityID = uphID,
                        EntityType = "UPH_PRODUK",
                        Name = data.foto
                    });
                }
                #endregion
            }

            return result;
        }

        private ParameterJawaban getJawaban(string indikatorName)
        {
            ParameterJawaban jawaban = null;

            if (!string.IsNullOrEmpty(indikatorName))
            {
                jawaban = _context.ParameterJawabans
                    .Where(x => x.Name == indikatorName.ToLower())
                    .FirstOrDefault();
            }

            return jawaban;
        }
    }
}