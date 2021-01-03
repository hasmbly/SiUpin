using MediatR;
using SiUpin.Shared.Satuans.Common;

namespace SiUpin.Shared.Satuans.Command
{
    public class CreateSatuanRequest : SatuanDTO, IRequest<CreateSatuanResponse>
    {
    }

    public class CreateSatuanResponse : SatuanDTO
    {
    }
}
