using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedProdukOlahan;


namespace SiUpin.Application.Systems.Commands.SeedProdukOlahan
{
    public class SeedProdukOlahanCommandHandler : IRequestHandler<SeedProdukOlahanRequest, SeedProdukOlahanResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IFileService _fileService;

        public SeedProdukOlahanCommandHandler(ISiUpinDBContext context, IFileService fileService)
        {
            _context = context;
            _fileService = fileService;
        }

        public async Task<SeedProdukOlahanResponse> Handle(SeedProdukOlahanRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedProdukOlahanResponse();

            var dataJSON = _fileService.ReadJSONFile<ProdukOlahanJSON>(FilePath.ProdukOlahanJSON);

            List<ProdukOlahan> produkOlahans = new List<ProdukOlahan>();

            var listDataJSON = dataJSON.rows.ToList();

            // collect data from db to temporary List
            var jenisKomoditis = await _context.JenisKomoditis
                .ToListAsync(cancellationToken);

            foreach (var data in listDataJSON)
            {
                ProdukOlahan produkOlahan = new ProdukOlahan();

                produkOlahan = produkOlahans
                    .SingleOrDefault(x => x.ProdukOlahanID == data.id_olahan);

                if (produkOlahan == null)
                {
                    string jenisKomoditiID = jenisKomoditis.Where(x => x.id_komoditi == data.id_komoditi_fk).FirstOrDefault().JenisKomoditiID ?? "";

                    produkOlahan = new ProdukOlahan
                    {
                        id_olahan = data.id_olahan,
                        JenisKomoditiID = jenisKomoditiID,
                        Name = data.nama_olahan
                    };

                    produkOlahans.Add(produkOlahan);

                    _context.ProdukOlahans.Add(produkOlahan);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            result.IsSuccessful = true;

            return result;
        }
    }
}