using MediatR;

namespace SiUpin.Shared.Uphs.Queries.GetUph
{
    public class GetUphRequest : IRequest<GetUphResponse>
    {
        public string UphID { get; set; }
    }
}
