using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.UphMitras.Commands;

namespace SiUpin.Application.UphMitras.Commands
{
    public class CreateUphMitraCommand : IRequestHandler<CreateUphMitraRequest, CreateUphMitraResponse>
    {
        private readonly ISiUpinDBContext _context;

        public CreateUphMitraCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<CreateUphMitraResponse> Handle(CreateUphMitraRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateUphMitraResponse();

            int count_nilai_mitra = 0;
            foreach (var item in request.jenis_mitras)
            {
                if (item == "Bahan baku")
                    count_nilai_mitra += 5;

                if (item == "Sarana dan prasarana")
                    count_nilai_mitra += 4;

                if (item == "Peningkatan kompetensi")
                    count_nilai_mitra += 3;

                if (item == "Fasilitasi")
                    count_nilai_mitra += 2;

                if (item == "Promosi dan pemasaran")
                    count_nilai_mitra += 1;
            }

            int count_nilai_sarana = 0;
            foreach (var item in request.detail_saranas)
            {
                if (item == "Bangunan / Rumah Produksi / Outlet Pemasaran")
                    count_nilai_sarana += 4;

                if (item == "Alat Pengolahan dan Produksi")
                    count_nilai_sarana += 3;

                if (item == "Alat Pengemasan")
                    count_nilai_sarana += 2;

                if (item == "Lainya")
                    count_nilai_sarana += 1;
            }

            var entity = new UphMitra
            {
                UphID = request.UphID,
                status = request.status,
                sasaran = request.sasaran,
                penanggungjawab = request.penanggungjawab,
                akhir_periode = request.akhir_periode,
                alamat = request.alamat,
                awal_periode = request.awal_periode,
                bermitra = request.bermitra,
                nama_perusahaan = request.nama_perusahaan,
                jenis_usaha = request.jenis_usaha,
                no_hp = request.no_hp,
                perjanjian = request.perjanjian,
                CreatedBy = request.user,

                lembaga = string.Join(",", request.lembagas),
                lembaga_lain = request.lembaga_lain,
                nilai_lembaga = request.lembagas.Count().ToString(),

                jenis_mitra = string.Join(",", request.jenis_mitras),
                nilai_mitra = count_nilai_mitra.ToString(),

                detail_promosi = string.Join(",", request.detail_promosis),
                nilai_promosi = request.detail_promosis.Count().ToString(),

                detail_sarana = string.Join(",", request.detail_saranas),
                nilai_sarana = count_nilai_sarana.ToString(),

                detail_fasilitasi = string.Join(",", request.detail_fasilitasis),

                satuan_bahan = request.satuan_bahan,
                detail_bahan = request.detail_bahan,

                detail_kopetensi = request.detail_kopetensi,

                manajemen_limbah = request.manajemen_limbah,
            };

            await _context.UphMitras.AddAsync(entity);
            await _context.SaveChangesAsync(cancellationToken);

            result.UphMitraID = entity.UphMitraID;

            return result;
        }
    }
}