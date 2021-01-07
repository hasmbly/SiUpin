using MediatR;
using SiUpin.Shared.UphSaranas.Common;

namespace SiUpin.Shared.UphSaranas.Commands
{
    public class CreateUphSaranaRequest : UphSaranaDTO, IRequest<CreateUphSaranaResponse>
    {
    }

    public class CreateUphSaranaResponse
    {
        public string UphSaranaID { get; set; }
    }
}
