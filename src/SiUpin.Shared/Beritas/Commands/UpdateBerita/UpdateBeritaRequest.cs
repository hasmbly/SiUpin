using MediatR;
using SiUpin.Shared.Beritas.Common;

namespace SiUpin.Shared.Beritas.Commands.UpdateBerita
{
    public class UpdateBeritaRequest : BeritaDTO, IRequest<UpdateBeritaResponse>
    {
    }
}
