using System.Collections.Generic;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Shared.UphProduks.Queries.GetAllUphProdukByUphID
{
    public class GetAllUphProdukByUphIDResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphProdukDTO> Data { get; set; }

        public GetAllUphProdukByUphIDResponse()
        {
            Data = new List<UphProdukDTO>();
        }
    }
}