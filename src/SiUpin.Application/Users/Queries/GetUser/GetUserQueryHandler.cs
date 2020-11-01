using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Users.Queries.GetUser;

namespace SiUpin.Application.Users.Queries.GetUser
{
    public class GetUserQueryHandler : IRequestHandler<GetUserRequest, GetUserResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUserQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUserResponse> Handle(GetUserRequest request, CancellationToken cancellationToken)
        {
            var result = new GetUserResponse();

            var user = await _context.Users
                .Where(x => x.UserID == request.UserID)
                .SingleOrDefaultAsync(cancellationToken);

            if (user == null)
                throw new Exception("Maaf Username tidak di temukan");

            result.UserID = user.UserID;
            result.Username = user.Username;

            return result;
        }
    }
}