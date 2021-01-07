using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common;
using SiUpin.Shared.Common.Pagination;
using SiUpin.Shared.UphProduksis.Common;

namespace SiUpin.Shared.UphProduksis.Queries
{
    public class GetUphProduksisRequest : PaginationRequest, IRequest<GetUphProduksisResponse>
    {
        public string FilterByName { get; set; }
    }

    public class GetUphProduksisResponse : GeneralResponse
    {
        public PaginationResponse Pagination { get; set; }

        public IList<UphProduksiDTO> Data { get; set; } = new List<UphProduksiDTO>();
    }
}
