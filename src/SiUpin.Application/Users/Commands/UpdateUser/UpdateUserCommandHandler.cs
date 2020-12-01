using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Users.Commands.UpdateUser;

namespace SiUpin.Application.Users.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateUserCommandHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUserResponse();

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

                if (user.Username != request.Username || user.Email != request.Email)
                {
                    if (await _context.Users.AsNoTracking().AnyAsync(x => x.Username == request.Username || x.Email == request.Email, cancellationToken))
                    {
                        throw new Exception("Maaf Username atau Email sudah di gunakan");
                    }
                    else
                    {
                        user.Username = request.Username;
                        user.Email = request.Email;
                    }
                }

                user.Alamat = request.Alamat;
                user.Fullname = request.Fullname;
                user.Instansi = request.Instansi;
                user.Jabatan = request.Jabatan;
                user.NIP = request.NIP;
                user.Telepon = request.Telepon;
                user.RoleID = request.RoleID;
                user.ProvinsiID = request.ProvinsiID;
                user.KotaID = request.KotaID;
                user.KecamatanID = request.KecamatanID;
                user.KelurahanID = request.KelurahanID;

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