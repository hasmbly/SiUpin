using MediatR;
using SiUpin.Shared.UphSaranas.Common;

namespace SiUpin.Shared.UphSaranas.Commands
{
    public class UpdateUphSaranaRequest : UphSaranaDTO, IRequest<UpdateUphSaranaResponse>
    {
    }

    public class UpdateUphSaranaResponse
    {
        public string UphSaranaID { get; set; }
    }
}
