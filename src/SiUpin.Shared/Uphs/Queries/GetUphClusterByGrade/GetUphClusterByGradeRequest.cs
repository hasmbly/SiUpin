using System.Collections.Generic;
using MediatR;
using SiUpin.Shared.Common.Pagination;

namespace SiUpin.Shared.Uphs.Queries.GetUphClusterByGrade
{
    public class GetUphClusterByGradeRequest : PaginationRequest, IRequest<GetUphClusterByGradeResponse>
    {
        public IList<string> UphIDs { get; set; } = new List<string>();
        public string FilterUphName { get; set; }
        public string FilterUphGrade { get; set; }
    }
}
