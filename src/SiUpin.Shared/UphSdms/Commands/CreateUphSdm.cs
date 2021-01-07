using MediatR;
using SiUpin.Shared.UphSdms.Common;

namespace SiUpin.Shared.UphSdms.Commands
{
    public class CreateUphSdmRequest : UphSdmDTO, IRequest<CreateUphSdmResponse>
    {
    }

    public class CreateUphSdmResponse
    {
        public string UphSdmID { get; set; }
    }
}
