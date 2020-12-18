using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Uphs.Command.CreateUph;

namespace SiUpin.Application.Uphs.Command.CreateUph
{
    public class CreateUphCommandHandler : IRequestHandler<CreateUphRequest, CreateUphResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateUphCommandHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateUphResponse> Handle(CreateUphRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateUphResponse();

            if (await _context.Uphs.AnyAsync(x => x.Name == request.Name))
            {
                throw new Exception("Maaf Nama sudah di gunakan");
            }
            else
            {
                var entity = new Uph
                {
                    ProvinsiID = request.ProvinsiID,
                    KotaID = request.KotaID,
                    KecamatanID = request.KecamatanID,
                    KelurahanID = request.KelurahanID,

                    Name = request.Name,
                    Ketua = request.Ketua,
                    Handphone = request.Handphone,
                    Alamat = request.Alamat,
                    TahunBerdiri = request.TahunBerdiri,

                    ParameterStatusUphID = request.ParameterStatusUphID,
                    ParameterBentukLembagaID = request.ParameterBentukLembagaID,
                    ParameterAdministrasiID = request.ParameterAdministrasiID,
                    ParameterBadanHukumID = request.ParameterBadanHukumID
                };

                await _context.Uphs.AddAsync(entity);
                await _context.SaveChangesAsync(cancellationToken);

                result.UphID = entity.UphID;
            }

            return result;
        }
    }
}