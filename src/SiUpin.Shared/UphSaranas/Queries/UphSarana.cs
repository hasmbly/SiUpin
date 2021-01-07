using MediatR;
using SiUpin.Shared.UphSaranas.Common;

namespace SiUpin.Shared.UphSaranas.Queries
{
    public class GetUphSaranaRequest : IRequest<GetUphSaranaResponse>
    {
        public string UphSaranaID { get; set; }
    }

    public class GetUphSaranaResponse : UphSaranaDTO
    {
    }
}
