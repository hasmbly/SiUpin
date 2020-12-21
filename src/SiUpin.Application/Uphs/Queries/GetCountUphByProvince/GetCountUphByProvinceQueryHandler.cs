using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Constants;
using SiUpin.Shared.Uphs.Queries.GetCountUphByProvince;

namespace SiUpin.Application.Uphs.Queries.GetCountUphByProvince
{
    public class GetCountUphByProvinceQueryHandler : IRequestHandler<GetCountUphByProvinceRequest, GetCountUphByProvinceResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetCountUphByProvinceQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetCountUphByProvinceResponse> Handle(GetCountUphByProvinceRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var records = await _context.Provinsis.AsNoTracking().ToListAsync(cancellationToken);
                var recordUphs = await _context.Uphs.AsNoTracking().ToListAsync(cancellationToken);

                List<UphByProvinceDTO> listOfDTO = new List<UphByProvinceDTO>();

                if (records.Count > 0)
                {
                    foreach (var data in records)
                    {
                        var totalUph = recordUphs.Count(x => x.ProvinsiID == data.ProvinsiID);

                        var entity = new UphByProvinceDTO
                        {
                            ProvinceName = data.Name,
                            TotalUph = totalUph,
                            TotalValueMark = GetValueMark(totalUph)
                        };

                        if (entity != null)
                            listOfDTO.Add(entity);
                    }
                }
                else
                {
                    throw new Exception(ErrorMessage.DataNotFound);
                }

                return new GetCountUphByProvinceResponse
                {
                    Datas = listOfDTO
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetValueMark(int total)
        {
            string valueMark;

            if (total >= 100)
            {
                valueMark = "High";
            }
            else if (total >= 50 && total < 100)
            {
                valueMark = "Moderate";
            }
            else if (total >= 1 && total < 50)
            {
                valueMark = "Low";
            }
            else
            {
                valueMark = "Low";
            }

            return valueMark;
        }
    }
}