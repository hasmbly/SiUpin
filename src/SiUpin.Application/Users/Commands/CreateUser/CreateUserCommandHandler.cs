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

            if (!string.IsNullOrEmpty(request.Username))
            {
                if (await _context.Users.AnyAsync(x => x.Username == request.Username))
                {
                    throw new Exception("Maaf Username sudah di gunakan");
                }
            }

            if (!string.IsNullOrEmpty(request.Email))
            {
                if (await _context.Users.AnyAsync(x => x.Email == request.Email, cancellationToken))
                {
                    throw new Exception("Maaf Email sudah di gunakan");
                }
            }
            string passwordSalt = AppUtility.CreatePasswordSalt();
            string passwordHash = AppUtility.CreatePasswordHash(request.Password, passwordSalt);

            var user = new User
            {
                Username = request.Username,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,

                Alamat = request.Alamat,
                Email = request.Email,
                Fullname = request.Fullname,
                Instansi = request.Instansi,
                Jabatan = request.Jabatan,
                NIP = request.NIP,
                Telepon = request.Telepon,

                RoleID = request.RoleID,
                ProvinsiID = request.ProvinsiID,
                KotaID = request.KotaID,
                KecamatanID = request.KecamatanID,
                KelurahanID = request.KelurahanID
            };

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync(cancellationToken);

            result.UserID = user.UserID;
            result.Username = user.Username;

            return result;
        }
    }
}