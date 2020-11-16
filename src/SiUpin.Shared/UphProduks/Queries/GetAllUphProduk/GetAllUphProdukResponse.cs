using System.Collections.Generic;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Shared.UphProduks.Queries.GetAllUphProduk
{
    public class GetAllUphProdukResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphProdukDTO> Data { get; set; }

        public GetAllUphProdukResponse()
        {
            Data = new List<UphProdukDTO>();
        }
    }
}