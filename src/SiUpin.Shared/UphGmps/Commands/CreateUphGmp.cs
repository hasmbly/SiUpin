using MediatR;
using SiUpin.Shared.UphGmps.Common;

namespace SiUpin.Shared.UphGmps.Commands
{
    public class CreateUphGmpRequest : UphGmpDTO, IRequest<CreateUphGmpResponse>
    {
    }

    public class CreateUphGmpResponse
    {
        public string UphGmpID { get; set; }
    }
}
