using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.Uphs.Queries.GetCountUphByJenisKomoditi;

namespace SiUpin.Application.Uphs.Queries.GetCountUphByJenisKomoditi
{
    public class GetCountUphByJenisKomoditiQuery : IRequestHandler<GetCountUphByJenisKomoditiRequest, GetCountUphByJenisKomoditiResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetCountUphByJenisKomoditiQuery(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetCountUphByJenisKomoditiResponse> Handle(GetCountUphByJenisKomoditiRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var jenisKomoditis = await _context.JenisKomoditis.AsNoTracking().ToListAsync(cancellationToken);
                var uphProduks = await _context.UphProduks
                    .Include(a => a.ProdukOlahan)
                    .AsNoTracking()
                    .Select(x => x.ProdukOlahan.JenisKomoditiID)
                    .ToListAsync(cancellationToken);

                List<UphByJenisKomoditiDTO> uphByJenisKomoditis = new List<UphByJenisKomoditiDTO>();

                if (jenisKomoditis.Count > 0)
                {
                    foreach (var jenisKomoditi in jenisKomoditis)
                    {
                        var totalUphProdukByJenisKomoditi = uphProduks.Count(x => x == jenisKomoditi.JenisKomoditiID);

                        var entity = new UphByJenisKomoditiDTO
                        {
                            JenisKomoditiID = jenisKomoditi.JenisKomoditiID,
                            Name = jenisKomoditi.Name,
                            TotalUph = totalUphProdukByJenisKomoditi,
                            Color = GetColorBy(jenisKomoditi.Name)
                        };

                        if (entity != null)
                            uphByJenisKomoditis.Add(entity);
                    }
                }
                else
                {
                    throw new Exception(ErrorMessage.DataNotFound);
                }

                return new GetCountUphByJenisKomoditiResponse
                {
                    UphByJenisKomoditis = uphByJenisKomoditis
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetColorBy(string name)
        {
            string colorValue = string.Empty;

            if (name == "Unggas dan Aneka Ternak")
            {
                colorValue = "#511cff";
            }
            else if (name == "Limbah")
            {
                colorValue = "green";
            }
            else if (name == "Susu")
            {
                colorValue = "#ff0097";
            }
            else if (name == "Daging")
            {
                colorValue = "crimson";
            }
            else if (name == "Hasil Ikutan Ternak")
            {
                colorValue = "darkorange";
            }

            return colorValue;
        }
    }
}