using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Systems.Commands.SeedUphBahanBaku;

#pragma warning disable CS8632
namespace SiUpin.Application.Systems.Commands.SeedUphBahanBakuBahanBaku
{
    public class SeedUphBahanBakuCommandHandler : IRequestHandler<SeedUphBahanBakuRequest, SeedUphBahanBakuResponse>
    {
        private readonly ISiUpinDBContext _context;
        private readonly IEntityRepository _entityRepository;
        private IMediator _mediator;

        public SeedUphBahanBakuCommandHandler(ISiUpinDBContext context, IMediator mediator, IEntityRepository entityRepository)
        {
            _context = context;
            _entityRepository = entityRepository;
            _mediator = mediator;
        }

        public async Task<SeedUphBahanBakuResponse> Handle(SeedUphBahanBakuRequest request, CancellationToken cancellationToken)
        {
            var result = new SeedUphBahanBakuResponse();

            var getAllBahanBaku = await _entityRepository.GetAllBahanBaku();

            List<UphBahanBaku> uphBahanBakus = new List<UphBahanBaku>();

            // collect temporary data from db
            var uphs = await _context.Uphs.AsNoTracking().ToListAsync(cancellationToken);
            var jenisTernaks = await _context.JenisTernaks.AsNoTracking().ToListAsync(cancellationToken);
            var jenisKomoditis = await _context.JenisKomoditis.AsNoTracking().ToListAsync(cancellationToken);
            var satuans = await _context.Satuans.AsNoTracking().ToListAsync(cancellationToken);
            var users = await _context.Users.AsNoTracking().ToListAsync(cancellationToken);

            var existingDatas = await _context.UphBahanBakus.AsNoTracking().ToListAsync(cancellationToken);

            #region Handle UPH BahanBaku
            foreach (var data in getAllBahanBaku)
            {
                if (existingDatas.Any(x => x.id_bahan_baku == data.id_bahan_baku))
                    continue;

                UphBahanBaku uphBahanBaku = new UphBahanBaku();

                string? uphID, jenisTernakID, jenisKomodtiID, satuanID, userID = "";

                uphBahanBaku = uphBahanBakus.FirstOrDefault(x => x.id_bahan_baku == data.id_bahan_baku);

                if (uphBahanBaku == null)
                {
                    var getUphID = uphs.FirstOrDefault(x => x.id_uph == data.id_uph);
                    var getJenisTernakID = jenisTernaks.FirstOrDefault(x => x.Name.Contains(data.jenis_ternak));
                    var getJenisKomodtiID = jenisKomoditis.FirstOrDefault(x => x.Name.Contains(data.bahan_utama));
                    var getSatuanID = satuans.FirstOrDefault(x => x.Name.Contains(data.satuan));
                    var getUserID = users.FirstOrDefault(x => x.id == data.user);

                    uphID = getUphID != null ? getUphID.UphID : null;
                    jenisTernakID = getJenisTernakID != null ? getJenisTernakID.JenisTernakID : null;
                    jenisKomodtiID = getJenisKomodtiID != null ? getJenisKomodtiID.JenisKomoditiID : null;
                    satuanID = getSatuanID != null ? getSatuanID.SatuanID : null;
                    userID = getUserID != null ? getUserID.UserID : null;

                    System.Console.WriteLine($"BEGIN Insert UphBahanBaku");

                    uphBahanBaku = new UphBahanBaku
                    {
                        id_bahan_baku = data.id_bahan_baku,
                        id_uph = data.id_uph,

                        UphID = uphID,
                        JenisKomoditiID = jenisKomodtiID,
                        JenisTernakID = jenisTernakID,
                        SatuanID = satuanID,

                        TotalKebutuhan = data.kebutuhan,
                        AsalBahanBaku = data.asal,
                        Nilai = data.nilai,
                        CreatedBy = userID
                    };

                    uphBahanBakus.Add(uphBahanBaku);

                    _context.UphBahanBakus.Add(uphBahanBaku);

                    System.Console.WriteLine($"END Insert UphBahanBaku");

                }
            }

            await _context.SaveChangesAsync(cancellationToken);
            #endregion

            return result;
        }
    }
}