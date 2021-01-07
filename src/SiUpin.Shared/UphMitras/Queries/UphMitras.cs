using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.UphMitras.Common;

namespace SiUpin.Shared.UphMitras.Queries
{
    public class GetUphMitrasRequest : PaginationRequest, IRequest<GetUphMitrasResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphMitrasResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphMitraDTO> Data { get; set; } = new List<UphMitraDTO>();
    }
}
