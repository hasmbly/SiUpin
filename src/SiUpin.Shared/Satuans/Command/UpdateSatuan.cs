using MediatR;
using SiUpin.Shared.Satuans.Common;

namespace SiUpin.Shared.Satuans.Command
{
    public class UpdateSatuanRequest : SatuanDTO, IRequest<UpdateSatuanResponse>
    {
    }

    public class UpdateSatuanResponse : SatuanDTO
    {
    }
}
