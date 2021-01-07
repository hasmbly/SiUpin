using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.UphGmps.Common;

namespace SiUpin.Shared.UphGmps.Queries
{
    public class GetUphGmpsRequest : PaginationRequest, IRequest<GetUphGmpsResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphGmpsResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphGmpDTO> Data { get; set; } = new List<UphGmpDTO>();
    }
}
