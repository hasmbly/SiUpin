using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedFile;
using SiUpin.Shared.Systems.Commands.SeedUph;

#pragma warning disable CS8632
namespace SiUpin.Application.Systems.Commands.SeedUph
{
    public class SeedUphCommandHandler : IRequestHandler<SeedUphRequest, SeedUphResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IEntityRepository _entityRepository;
        private IMediator _mediator;

        public SeedUphCommandHandler(ISiUpinDBContext context, IMediator mediator, IEntityRepository entityRepository)
        {
            _context = context;
            _entityRepository = entityRepository;
            _mediator = mediator;
        }

        public async Task<SeedUphResponse> Handle(SeedUphRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedUphResponse();

            var getAllUph = await _entityRepository.GetAllUph();
            var getAllBahanBaku = await _entityRepository.GetAllBahanBaku();

            List<Uph> uphs = new List<Uph>();

            // collect temporary data from db
            var provinsis = await _context.Provinsis.AsNoTracking().ToListAsync(cancellationToken);
            var kotas = await _context.Kotas.AsNoTracking().ToListAsync(cancellationToken);
            var kecamatans = await _context.Kecamatans.AsNoTracking().ToListAsync(cancellationToken);
            var kelurahans = await _context.Kelurahans.AsNoTracking().ToListAsync(cancellationToken);
            var produkOlahans = await _context.ProdukOlahans.AsNoTracking().ToListAsync(cancellationToken);
            var jenisTernaks = await _context.JenisTernaks.AsNoTracking().ToListAsync(cancellationToken);

            // for safety to avoid redundant data between existing db and old db
            var existingUphs = await _context.Uphs.AsNoTracking().ToListAsync(cancellationToken);

            foreach (var data in getAllUph)
            {
                if (existingUphs.Any(x => x.id_uph == data.id_uph))
                    continue;

                Uph uph = new Uph();

                string? provinsiID, kotaID, kecamatanID, kelurahanID, produkOlahanID, jenisTernakID, sameUphID = "";

                uph = uphs.FirstOrDefault(x => x.id_uph == data.id_uph || x.Name == data.nama_uph.ToLower());

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

                    System.Console.WriteLine($"Insert UPH - uph: {data.nama_uph} - {data.id_uph}");

                    #region Handle UPH
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
                        TahunBerdiri = data.tahun_berdiri,

                        ParameterAdministrasiID = getJawaban(data.administrasi)?.ParameterJawabanID,
                        ParameterBadanHukumID = getJawaban(data.badan_hukum)?.ParameterJawabanID,
                        ParameterBentukLembagaID = getJawaban(data.bentuk_lembaga)?.ParameterJawabanID,
                        ParameterStatusUphID = getJawaban(data.status_uph)?.ParameterJawabanID
                    };

                    uphs.Add(uph);

                    _context.Uphs.Add(uph);
                    await _context.SaveChangesAsync(cancellationToken);
                    #endregion

                    #region Handle UphParameter
                    //IList<ParameterJawaban> jawabans = new List<ParameterJawaban>();

                    //jawabans.Add(getJawaban(data.bentuk_lembaga));
                    //jawabans.Add(getJawaban(data.badan_hukum));
                    //jawabans.Add(getJawaban(data.status_uph));
                    //jawabans.Add(getJawaban(data.administrasi));

                    //foreach (var jawaban in jawabans)
                    //{
                    //    System.Console.WriteLine($"Insert uphParameter - UphID: {uph.UphID}");

                    //    if (jawaban != null)
                    //    {
                    //        System.Console.WriteLine("uphParameter: jawaban not empty");

                    //        var uphParameter = new UphParameter
                    //        {
                    //            Uph = uph,
                    //            ParameterJawaban = jawaban
                    //        };

                    //        _context.UphParameters.Add(uphParameter);
                    //    }
                    //    else
                    //    {
                    //        System.Console.WriteLine("uphParameter: jawaban was empty");
                    //    }

                    //    await _context.SaveChangesAsync(cancellationToken);
                    //}
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

                System.Console.WriteLine($"Insert UphProduk - UphID: {uphID}");

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
                    System.Console.WriteLine($"Insert FotoProduk - UphID: {uphID}");

                    await _mediator.Send(new SeedFileRequest()
                    {
                        EntityID = uphProduk.UphProdukID,
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
                    .AsNoTracking()
                    .Where(x => x.Name == indikatorName.ToLower())
                    .FirstOrDefault();
            }

            return jawaban;
        }
    }
}