using MediatR;

namespace SiUpin.Shared.Pesans.Commands
{
    public class DeletePesanRequest : IRequest<DeletePesanResponse>
    {
        public string PesanID { get; set; }
    }

    public class DeletePesanResponse
    {
    }
}
