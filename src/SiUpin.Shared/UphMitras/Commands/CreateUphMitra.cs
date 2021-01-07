using MediatR;
using SiUpin.Shared.UphMitras.Common;

namespace SiUpin.Shared.UphMitras.Commands
{
    public class CreateUphMitraRequest : UphMitraDTO, IRequest<CreateUphMitraResponse>
    {
    }

    public class CreateUphMitraResponse
    {
        public string UphMitraID { get; set; }
    }
}
