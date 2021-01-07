using MediatR;
using SiUpin.Shared.UphMitras.Common;

namespace SiUpin.Shared.UphMitras.Queries
{
    public class GetUphMitraRequest : IRequest<GetUphMitraResponse>
    {
        public string UphMitraID { get; set; }
    }

    public class GetUphMitraResponse : UphMitraDTO
    {
    }
}
