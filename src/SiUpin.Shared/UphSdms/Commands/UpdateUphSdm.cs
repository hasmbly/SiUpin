using MediatR;
using SiUpin.Shared.UphSdms.Common;

namespace SiUpin.Shared.UphSdms.Commands
{
    public class UpdateUphSdmRequest : UphSdmDTO, IRequest<UpdateUphSdmResponse>
    {
    }

    public class UpdateUphSdmResponse
    {
        public string UphSdmID { get; set; }
    }
}
