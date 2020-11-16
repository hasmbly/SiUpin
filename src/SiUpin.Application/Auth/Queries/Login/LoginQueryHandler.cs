using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SiUpin.Application.Auth.Common;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Auth.Queries.Login;
using SiUpin.Shared.Constants;

namespace SiUpin.Application.Auth.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginRequest, LoginResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IConfiguration _config;

        public LoginQueryHandler(ISiUpinDBContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var result = new LoginResponse();

            var user = await _context.Users
                .AsNoTracking()
                .Include(r => r.Role)
                .Where(x => x.Username == request.UsernameOrEmail || x.Email == request.UsernameOrEmail)
                .SingleOrDefaultAsync(cancellationToken);

            if (user != null)
            {
                result.UsernameExists = true;

                if (AppUtility.VerifyPasswordHash(request.Password, user.PasswordSalt, user.PasswordHash))
                {
                    result.PasswordIsCorrect = true;
                    result.IsSuccessful = true;
                    result.RoleName = user.Role.Name;

                    string securityKey = _config.GetSection("SiUpin:TokenSecurityKey").Value;
                    result.Token = TokenHelper.GenerateToken(user, securityKey);
                }
                else
                {
                    throw new Exception(ErrorMessage.InvalidPassword);
                }
            }
            else
            {
                throw new Exception(ErrorMessage.MemberUsernameNotFound);
            }

            return result;
        }
    }
}