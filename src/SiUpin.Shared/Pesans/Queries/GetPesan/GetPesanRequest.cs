using MediatR;

namespace SiUpin.Shared.Pesans.Queries.GetPesan
{
    public class GetPesanRequest : IRequest<GetPesanResponse>
    {
        public string PesanID { get; set; }
    }
}
