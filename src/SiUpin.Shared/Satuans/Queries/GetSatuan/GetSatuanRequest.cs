using MediatR;

namespace SiUpin.Shared.Satuans.Queries.GetSatuan
{
    public class GetSatuanRequest : IRequest<GetSatuanResponse>
    {
        public string SatuanID { get; set; }
    }
}
