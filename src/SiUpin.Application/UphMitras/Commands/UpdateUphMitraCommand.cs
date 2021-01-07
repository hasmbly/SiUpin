using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Shared.UphMitras.Commands;

namespace SiUpin.Application.UphMitras.Commands
{
    public class UpdateUphMitraCommand : IRequestHandler<UpdateUphMitraRequest, UpdateUphMitraResponse>
    {
        private readonly ISiUpinDBContext _context;

        public UpdateUphMitraCommand(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<UpdateUphMitraResponse> Handle(UpdateUphMitraRequest request, CancellationToken cancellationToken)
        {
            var result = new UpdateUphMitraResponse();

            var entity = await _context.UphMitras
                .FirstOrDefaultAsync(x => x.UphMitraID == request.UphMitraID, cancellationToken);

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
                if (item == "Bangunan / Rumah Produksi/ Outlet Pemasaran")
                    count_nilai_sarana += 4;

                if (item == "Alat Pengolahan dan Produksi")
                    count_nilai_sarana += 3;

                if (item == "Alat Pengemasan")
                    count_nilai_sarana += 2;

                if (item == "Lainya")
                    count_nilai_sarana += 1;
            }

            entity.UphMitraID = request.UphMitraID;
            entity.UphID = request.UphID;
            entity.status = request.status;
            entity.sasaran = request.sasaran;
            entity.penanggungjawab = request.penanggungjawab;
            entity.akhir_periode = request.akhir_periode;
            entity.alamat = request.alamat;
            entity.awal_periode = request.awal_periode;
            entity.bermitra = request.bermitra;
            entity.nama_perusahaan = request.nama_perusahaan;
            entity.jenis_usaha = request.jenis_usaha;
            entity.no_hp = request.no_hp;
            entity.perjanjian = request.perjanjian;
            entity.CreatedBy = request.user;
            entity.lembaga = string.Join(",", request.lembagas);
            entity.lembaga_lain = request.lembaga_lain;
            entity.nilai_lembaga = request.lembagas.Count().ToString();
            entity.jenis_mitra = string.Join(",", request.jenis_mitras);
            entity.nilai_mitra = count_nilai_mitra.ToString();
            entity.detail_promosi = string.Join(",", request.detail_promosis);
            entity.nilai_promosi = request.detail_promosis.Count().ToString();
            entity.detail_sarana = string.Join(",", request.detail_saranas);
            entity.nilai_sarana = count_nilai_sarana.ToString();
            entity.detail_fasilitasi = string.Join(",", request.detail_fasilitasis);
            entity.satuan_bahan = request.satuan_bahan;
            entity.detail_bahan = request.detail_bahan;
            entity.detail_kopetensi = request.detail_kopetensi;
            entity.manajemen_limbah = request.manajemen_limbah;

            await _context.SaveChangesAsync(cancellationToken);

            result.UphMitraID = entity.UphMitraID;

            return result;
        }
    }
}