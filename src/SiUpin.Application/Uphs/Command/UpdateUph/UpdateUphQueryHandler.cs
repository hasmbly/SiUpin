using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.Uphs.Command.UpdateUph;

namespace SiUpin.Application.Uphs.Command.UpdateUph
{
    public class UpdateUphQueryHandler : IRequestHandler<UpdateUphRequest, UpdateUphResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateUphQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateUphResponse> Handle(UpdateUphRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUphResponse();

            var uph = await _context.Uphs.FirstOrDefaultAsync(x => x.UphID == request.UphID, cancellationToken);

            if (uph != null)
            {
                if (uph.Name != request.Name)
                {
                    if (await _context.Uphs.AsNoTracking().AnyAsync(x => x.Name == request.Name, cancellationToken))
                    {
                        throw new Exception("Maaf Nama UPH sudah di gunakan");
                    }
                    else
                    {
                        uph.Name = request.Name;
                    }
                }

                #region uph
                uph.Name = request.Name;
                uph.Ketua = request.Ketua;
                uph.Handphone = request.Handphone;
                uph.Alamat = request.Alamat;
                uph.TahunBerdiri = request.TahunBerdiri;
                uph.ProvinsiID = request.ProvinsiID;
                uph.KotaID = request.KotaID;
                uph.KecamatanID = request.KecamatanID;
                uph.KelurahanID = request.KelurahanID;
                uph.ParameterBadanHukumID = request.ParameterBadanHukumID;
                uph.ParameterAdministrasiID = request.ParameterAdministrasiID;
                uph.ParameterBentukLembagaID = request.ParameterBentukLembagaID;
                uph.ParameterStatusUphID = request.ParameterStatusUphID;
                #endregion

                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new Exception("Maaf, Uph tidak ditemukan");
            }

            return result;
        }
    }
}