using System.Collections.Generic;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Shared.Uphs.Queries.GetAllUph
{
    public class GetAllUphResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphDTO> Data { get; set; }

        public GetAllUphResponse()
        {
            Data = new List<UphDTO>();
        }
    }
}
