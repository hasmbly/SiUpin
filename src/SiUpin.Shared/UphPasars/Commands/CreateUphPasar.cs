using MediatR;
using SiUpin.Shared.UphPasars.Common;

namespace SiUpin.Shared.UphPasars.Commands
{
    public class CreateUphPasarRequest : UphPasarDTO, IRequest<CreateUphPasarResponse>
    {
    }

    public class CreateUphPasarResponse
    {
        public string UphPasarID { get; set; }
    }
}
