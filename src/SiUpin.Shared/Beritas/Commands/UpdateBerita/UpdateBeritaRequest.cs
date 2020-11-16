using MediatR;

namespace SiUpin.Shared.Beritas.Commands.UpdateBerita
{
    public class UpdateBeritaRequest : IRequest<UpdateBeritaResponse>
    {
        public string BeritaID { get; set; }
    }
}
