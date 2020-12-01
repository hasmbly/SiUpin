using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Users.Commands.ResetPassword;

namespace SiUpin.Application.Users.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordRequest, ResetPasswordResponse>
    {
        private readonly ISiUpinDBContext _context;

        public ResetPasswordCommandHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<ResetPasswordResponse> Handle(ResetPasswordRequest request, CancellationToken cancellationToken)
        {
            var result = new ResetPasswordResponse();

            var user = await _context.Users.FindAsync(request.UserID);

            if (user != null)
            {
                string passwordSalt;
                string passwordHash;

                if (!string.IsNullOrEmpty(request.Password))
                {
                    if (!AppUtility.VerifyPasswordHash(request.Password, user.PasswordSalt, user.PasswordHash))
                    {
                        passwordSalt = AppUtility.CreatePasswordSalt();
                        passwordHash = AppUtility.CreatePasswordHash(request.Password, passwordSalt);

                        user.PasswordHash = passwordHash;
                        user.PasswordSalt = passwordSalt;
                    }
                }

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception("Maaf, User tidak ditemukan");
            }

            return result;
        }
    }
}