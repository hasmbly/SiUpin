using MediatR;

namespace SiUpin.Shared.JenisTernaks.Commands
{
    public class DeleteJenisTernakRequest : IRequest<DeleteJenisTernakResponse>
    {
        public string JenisTernakID { get; set; }
    }

    public class DeleteJenisTernakResponse
    {
    }
}
