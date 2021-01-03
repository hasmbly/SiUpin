using MediatR;
using SiUpin.Shared.Pesans.Queries.Common;

namespace SiUpin.Shared.Pesans.Commands
{
    public class CreatePesanRequest : PesanDTO, IRequest<CreatePesanResponse>
    {
    }

    public class CreatePesanResponse
    {
    }
}
