using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.Uphs.Queries.GetUphAndProduk;
using static SiUpin.Shared.Common.Constants;

namespace SiUpin.Application.Uphs.Queries.GetUphAndProduk
{
    public class GetUphAndProdukQueryHandler : IRequestHandler<GetUphAndProdukRequest, GetUphAndProdukResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphAndProdukQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphAndProdukResponse> Handle(GetUphAndProdukRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Uphs
                    .AsNoTracking()
                    .Include(p => p.Provinsi)
                    .Include(k => k.Kota)
                    .Include(kec => kec.Kecamatan)
                    .Include(kel => kel.Kelurahan)
                    .Include(g => g.ParameterAdministrasi)
                    .Include(h => h.ParameterBadanHukum)
                    .Include(i => i.ParameterBentukLembaga)
                    .Include(j => j.ParameterStatusUph)
                    .Include(a => a.UphProduks)
                    .Where(x => x.UphID == request.UphID)
                    .SingleOrDefaultAsync(cancellationToken);

                if (records == null)
                    throw new Exception(ErrorMessage.DataNotFound);

                var files = await _context.Files
                  .AsNoTracking()
                  .Where(x => x.EntityType == FileEntityType.UphProduk && !x.Name.Contains(".docx") &&
                    !x.Name.Contains(".doc") && !x.Name.Contains(".pdf"))
                  .ToListAsync(cancellationToken);

                var result = new GetUphAndProdukResponse
                {
                    UphID = records.UphID,
                    Name = records.Name,
                    Ketua = records.Ketua,
                    Handphone = records.Handphone,
                    Alamat = records.Alamat,
                    TahunBerdiri = records.TahunBerdiri,

                    ProvinsiID = records.ProvinsiID,
                    KotaID = records.KotaID,
                    KecamatanID = records.KecamatanID,
                    KelurahanID = records.KelurahanID,

                    ParameterAdministrasiID = records.ParameterAdministrasiID,
                    ParameterBadanHukumID = records.ParameterBadanHukumID,
                    ParameterBentukLembagaID = records.ParameterBentukLembagaID,
                    ParameterStatusUphID = records.ParameterStatusUphID
                };

                foreach (var produk in records.UphProduks)
                {
                    var file = files.FirstOrDefault(x => x.EntityID == produk.UphProdukID);

                    result.UphProduks.Add(new UphProdukDTO
                    {
                        UphID = records.UphID,
                        UphProdukID = produk.UphProdukID,
                        Berat = produk.Berat,
                        Description = produk.Description,
                        Harga = produk.Harga,
                        JenisTernakID = produk.JenisTernakID,
                        ProdukOlahanID = produk.ProdukOlahanID,
                        Name = produk.Name,
                        SatuanID = produk.SatuanID,

                        File = new FileDTO
                        {
                            FileID = file.FileID,
                            Name = file.Name,
                            EntityID = file.EntityID,
                            EntityType = file.EntityType,
                            Description = file.Description
                        }
                    });
                }

                //result.NecessaryData.Provinsis = await _context.Provinsis.AsNoTracking().ToListAsync(cancellationToken);
                //result.NecessaryData.Kotas = await _context.Kotas.AsNoTracking().Where(x => x.ProvinsiID == records.ProvinsiID).ToListAsync(cancellationToken);
                //result.NecessaryData.Kecamatans = await _context.Kecamatans.AsNoTracking().Where(x => x.KotaID == records.KotaID).ToListAsync(cancellationToken);
                //result.NecessaryData.Kelurahans = await _context.Kelurahans.AsNoTracking().Where(x => x.KecamatanID == records.KecamatanID).ToListAsync(cancellationToken);

                //result.NecessaryData.ParameterBadanHukums = await _context.ParameterJawabans
                //    .AsNoTracking().Include(a => a.ParameterIndikator)
                //    .Where(x => x.ParameterIndikatorID == x.ParameterIndikator.ParameterIndikatorID)
                //    .ToListAsync(cancellationToken);
                //result.NecessaryData.ParameterAdministrasis = await _context.ParameterJawabans
                //    .AsNoTracking().Include(a => a.ParameterIndikator)
                //    .Where(x => x.ParameterIndikatorID == x.ParameterIndikator.ParameterIndikatorID)
                //    .ToListAsync(cancellationToken);
                //result.NecessaryData.ParameterBentukLembagas = await _context.ParameterJawabans
                //    .AsNoTracking().Include(a => a.ParameterIndikator)
                //    .Where(x => x.ParameterIndikatorID == x.ParameterIndikator.ParameterIndikatorID)
                //    .ToListAsync(cancellationToken);
                //result.NecessaryData.ParameterStatusUphs = await _context.ParameterJawabans
                //    .AsNoTracking().Include(a => a.ParameterIndikator)
                //    .Where(x => x.ParameterIndikatorID == x.ParameterIndikator.ParameterIndikatorID)
                //    .ToListAsync(cancellationToken);

                //result.NecessaryData.ProdukOlahans = await _context.ProdukOlahans.AsNoTracking().ToListAsync(cancellationToken);
                //result.NecessaryData.JenisTernaks = await _context.JenisTernaks.AsNoTracking().ToListAsync(cancellationToken);
                //result.NecessaryData.Satuans = await _context.Satuans.AsNoTracking().ToListAsync(cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}