using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Users.Commands.DeleteUser;

namespace SiUpin.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
    {
        private readonly ISiUpinDBContext _context;

        public DeleteUserCommandHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            var result = new DeleteUserResponse();

            var user = await _context.Users.FindAsync(request.UserID);

            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception("Maaf User tidak ditemukan");
            }

            return result;
        }
    }
}