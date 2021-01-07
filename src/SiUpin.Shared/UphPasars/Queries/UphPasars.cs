using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.UphPasars.Common;

namespace SiUpin.Shared.UphPasars.Queries
{
    public class GetUphPasarsRequest : PaginationRequest, IRequest<GetUphPasarsResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphPasarsResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphPasarDTO> Data { get; set; } = new List<UphPasarDTO>();
    }
}
