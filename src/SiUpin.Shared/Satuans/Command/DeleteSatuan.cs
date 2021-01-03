using MediatR;

namespace SiUpin.Shared.Satuans.Command
{
    public class DeleteSatuanRequest : IRequest<DeleteSatuanResponse>
    {
        public string SatuanID { get; set; }
    }

    public class DeleteSatuanResponse
    {
    }
}
