using MediatR;
using SiUpin.Shared.UphPasars.Common;

namespace SiUpin.Shared.UphPasars.Queries
{
    public class GetUphPasarRequest : IRequest<GetUphPasarResponse>
    {
        public string UphPasarID { get; set; }
    }

    public class GetUphPasarResponse : UphPasarDTO
    {
    }
}
