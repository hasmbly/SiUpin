using MediatR;
using SiUpin.Shared.UphSdms.Common;

namespace SiUpin.Shared.UphSdms.Queries
{
    public class GetUphSdmRequest : IRequest<GetUphSdmResponse>
    {
        public string UphSdmID { get; set; }
    }

    public class GetUphSdmResponse : UphSdmDTO
    {
    }
}
