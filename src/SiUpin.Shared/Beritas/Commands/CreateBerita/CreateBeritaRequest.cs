using MediatR;
using SiUpin.Shared.Beritas.Common;

namespace SiUpin.Shared.Beritas.Commands.CreateBerita
{
    public class CreateBeritaRequest : BeritaDTO, IRequest<CreateBeritaResponse>
    {
    }
}
