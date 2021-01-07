using MediatR;
using SiUpin.Shared.UphGmps.Common;

namespace SiUpin.Shared.UphGmps.Commands
{
    public class UpdateUphGmpRequest : UphGmpDTO, IRequest<UpdateUphGmpResponse>
    {
    }

    public class UpdateUphGmpResponse
    {
        public string UphGmpID { get; set; }
    }
}
