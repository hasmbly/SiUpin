using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.UphSaranas.Common;

namespace SiUpin.Shared.UphSaranas.Queries
{
    public class GetUphSaranasRequest : PaginationRequest, IRequest<GetUphSaranasResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphSaranasResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphSaranaDTO> Data { get; set; } = new List<UphSaranaDTO>();
    }
}
