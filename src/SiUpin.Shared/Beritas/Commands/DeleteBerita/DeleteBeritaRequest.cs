using MediatR;

namespace SiUpin.Shared.Beritas.Commands.DeleteBerita
{
    public class DeleteBeritaRequest : IRequest<DeleteBeritaResponse>
    {
        public string BeritaID { get; set; }
    }
}
