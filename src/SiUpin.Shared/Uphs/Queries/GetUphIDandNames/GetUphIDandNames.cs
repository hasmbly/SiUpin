using System.Collections.Generic;
using MediatR;

namespace SiUpin.Shared.Uphs.Queries.GetUphIDandNames
{
    public class GetUphIDandNamesRequest : IRequest<GetUphIDandNamesResponse>
    {
    }

    public class GetUphIDandNamesResponse
    {
        public IList<UphIDandNameDTO> UphIDandNames { get; set; } = new List<UphIDandNameDTO>();
    }

    public class UphIDandNameDTO
    {
        public string UphID { get; set; }
        public string Name { get; set; }
    }
}
