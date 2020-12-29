using MediatR;

namespace SiUpin.Shared.Uphs.Command.DeleteUph
{
    public class DeleteUphRequest : IRequest<DeleteUphResponse>
    {
        public string UphID { get; set; }
    }
}
