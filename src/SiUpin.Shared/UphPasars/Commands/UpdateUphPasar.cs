using MediatR;
using SiUpin.Shared.UphPasars.Common;

namespace SiUpin.Shared.UphPasars.Commands
{
    public class UpdateUphPasarRequest : UphPasarDTO, IRequest<UpdateUphPasarResponse>
    {
    }

    public class UpdateUphPasarResponse
    {
        public string UphPasarID { get; set; }
    }
}
