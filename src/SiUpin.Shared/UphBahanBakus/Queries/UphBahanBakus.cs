using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.UphBahanBakus.Common;

namespace SiUpin.Shared.UphBahanBakus.Queries
{
    public class GetUphBahanBakusRequest : PaginationRequest, IRequest<GetUphBahanBakusResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphBahanBakusResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphBahanBakuDTO> Data { get; set; }

        public GetUphBahanBakusResponse()
        {
            Data = new List<UphBahanBakuDTO>();
        }
    }
}
