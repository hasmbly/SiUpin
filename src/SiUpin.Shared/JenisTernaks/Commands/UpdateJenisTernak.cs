using MediatR;
using SiUpin.Shared.JenisTernaks.Queries.Common;

namespace SiUpin.Shared.JenisTernaks.Commands
{
    public class UpdateJenisTernakRequest : JenisTernakDTO, IRequest<UpdateJenisTernakResponse>
    {
    }

    public class UpdateJenisTernakResponse
    {
    }
}
