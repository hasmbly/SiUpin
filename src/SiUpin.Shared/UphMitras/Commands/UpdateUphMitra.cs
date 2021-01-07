using MediatR;
using SiUpin.Shared.UphMitras.Common;

namespace SiUpin.Shared.UphMitras.Commands
{
    public class UpdateUphMitraRequest : UphMitraDTO, IRequest<UpdateUphMitraResponse>
    {
    }

    public class UpdateUphMitraResponse
    {
        public string UphMitraID { get; set; }
    }
}
