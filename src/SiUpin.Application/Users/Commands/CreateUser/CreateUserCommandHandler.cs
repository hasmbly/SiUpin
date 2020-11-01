using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Users.Commands.CreateUser;

namespace SiUpin.Application.Users.Commands
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateUserCommandHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateUserResponse();

            if (await _context.Users.AnyAsync(x => x.Username == request.Username, cancellationToken))
            {
                throw new Exception("Maaf Username sudah di gunakan");
            }
            else
            {
                string passwordSalt = AppUtility.CreatePasswordSalt();
                string passwordHash = AppUtility.CreatePasswordHash(request.Password, passwordSalt);

                var user = new User
                {
                    Username = request.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt
                };

                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync(cancellationToken);

                result.UserID = user.UserID;
                result.Username = user.Username;
            }

            return result;
        }
    }
}