using MediatR;
using SiUpin.Shared.JenisTernaks.Queries.Common;

namespace SiUpin.Shared.JenisTernaks.Commands
{
    public class CreateJenisTernakRequest : JenisTernakDTO, IRequest<CreateJenisTernakResponse>
    {
    }

    public class CreateJenisTernakResponse
    {
    }
}
