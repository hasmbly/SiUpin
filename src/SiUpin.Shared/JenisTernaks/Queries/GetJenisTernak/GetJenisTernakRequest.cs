using MediatR;

namespace SiUpin.Shared.JenisTernaks.Queries.GetJenisTernak
{
    public class GetJenisTernakRequest : IRequest<GetJenisTernakResponse>
    {
        public string JenisTernakID { get; set; }
    }
}
