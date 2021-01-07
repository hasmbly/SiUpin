using MediatR;
using SiUpin.Shared.UphGmps.Common;

namespace SiUpin.Shared.UphGmps.Queries
{
    public class GetUphGmpRequest : IRequest<GetUphGmpResponse>
    {
        public string UphGmpID { get; set; }
    }

    public class GetUphGmpResponse : UphGmpDTO
    {
    }
}
