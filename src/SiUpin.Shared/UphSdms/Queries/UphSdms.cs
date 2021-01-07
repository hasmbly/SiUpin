using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.UphSdms.Common;

namespace SiUpin.Shared.GetUphSdms.Queries
{
    public class GetUphSdmsRequest : PaginationRequest, IRequest<GetUphSdmsResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphSdmsResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphSdmDTO> Data { get; set; } = new List<UphSdmDTO>();
    }
}
