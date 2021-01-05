using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SiUpin.Application.Common.Interfaces;
using SiUpin.Domain.Entities;
using SiUpin.Shared.Constants;
using SiUpin.Shared.UphMitras.Queries;

namespace SiUpin.Application.UphMitras.Queries
{
    public class GetUphMitraClusterGradesQueryHandler : IRequestHandler<GetUphMitraClusterGradesRequest, GetUphMitraClusterGradesResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphMitraClusterGradesQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphMitraClusterGradesResponse> Handle(GetUphMitraClusterGradesRequest request, CancellationToken cancellationToken)
        {
            var result = new GetUphMitraClusterGradesResponse();

            var records = await _context.UphMitras
                .AsNoTracking()
                .Include(a => a.Uph)
                .ToListAsync(cancellationToken);

            if (records.Count > 0)
            {
                result.TotalUph = records.Count();
                result.Datas = calculateClusterUph(records);

                result.Datas.OrderByDescending(x => x.No);
            }
            else
            {
                throw new Exception(ErrorMessage.DataNotFound);
            }

            return result;
        }

        public List<UphMitraClusterDTO> calculateClusterUph(IList<UphMitra> entities)
        {
            var uphMitraClusters = new List<UphMitraClusterDTO>();

            var uphMitraClustersA = new UphMitraClusterDTO { No = 1, ClusterGrade = "A", ClusterGradeStar = 4 };
            var uphMitraClustersB = new UphMitraClusterDTO { No = 2, ClusterGrade = "B", ClusterGradeStar = 3 };
            var uphMitraClustersC = new UphMitraClusterDTO { No = 3, ClusterGrade = "C", ClusterGradeStar = 2 };
            var uphMitraClustersD = new UphMitraClusterDTO { No = 4, ClusterGrade = "D", ClusterGradeStar = 1 };

            int noA = 1;
            int noB = 1;
            int noC = 1;
            int noD = 1;

            foreach (var entity in entities)
            {
                #region get all value
                int total_nilai_mitra = 0;
                var jenisMitras = entity.jenis_mitra.Replace(", ", ",").Split(",").ToList();
                if (jenisMitras[0] == "Bahan baku")
                    total_nilai_mitra = 5;

                int nilai_perjanjian = 0;
                if (entity.perjanjian == "Ada")
                    nilai_perjanjian = 5;

                if (entity.perjanjian == "Tidak Ada")
                    nilai_perjanjian = 1;

                if (string.IsNullOrEmpty(entity.perjanjian))
                    nilai_perjanjian = 1;

                int nilai_sasaran = 0;
                if (entity.sasaran == "Kemitraan Pengolahan")
                    nilai_sasaran = 5;

                if (entity.sasaran == "Kemitraan non Pengolahan")
                    nilai_sasaran = 3;

                int nilai_sarana = int.Parse(s: entity.nilai_sarana) / 2;

                int nilai_kopetensi = 0;
                if (entity.detail_kopetensi == "Lebih dari 2 bimtek")
                    nilai_kopetensi = 5;

                if (entity.detail_kopetensi == "2 bimtek")
                    nilai_kopetensi = 3;

                if (entity.detail_kopetensi == "1 kali bimtek")
                    nilai_kopetensi = 1;

                int nilai_fasilitasi = 0;
                if (entity.detail_fasilitasi == "MD, Halal")
                    nilai_fasilitasi = 5;

                if (entity.detail_fasilitasi == "MD")
                    nilai_fasilitasi = 3;

                if (entity.detail_fasilitasi == "NKV" ||
                    entity.detail_fasilitasi == "PIRT" ||
                    entity.detail_fasilitasi == "Halal")
                    nilai_fasilitasi = 1;

                int nilai_limbah = 0;
                if (entity.manajemen_limbah == "Melakukan Manajemen Limbah")
                    nilai_limbah = 5;

                int nilai_promosi = 0;
                if (int.Parse(s: entity.nilai_promosi) > 2)
                    nilai_promosi = 5;

                if (int.Parse(s: entity.nilai_promosi) <= 2)
                    nilai_promosi = 3;
                #endregion

                #region count total value
                int? total_nilai = nilai_sasaran + nilai_sarana + nilai_kopetensi + nilai_fasilitasi + nilai_limbah + nilai_promosi + nilai_perjanjian + total_nilai_mitra;

                double? rata2totalNilai = total_nilai / 8;

                if (rata2totalNilai.HasValue)
                {
                    if (rata2totalNilai >= 4)
                    {
                        uphMitraClustersA.ClusterTotal++; // A
                        uphMitraClustersA
                            .UphMitras.Add(new UphMitraClusterByGradeDTO
                            {
                                No = noA++,
                                UphID = entity.UphID,
                                UphName = entity.Uph?.Name,
                                NamaPerusahaan = entity.nama_perusahaan,
                                JenisKemitraan = entity.jenis_mitra,

                                ClusterGrade = "A",
                                ClusterGradeStar = 4,
                                TotalNilai = total_nilai,
                                TotalNilaiRata2 = rata2totalNilai
                            });
                    }
                    else if (rata2totalNilai >= 3 && rata2totalNilai < 4)
                    {
                        uphMitraClustersB.ClusterTotal++; // B
                        uphMitraClustersB
                            .UphMitras.Add(new UphMitraClusterByGradeDTO
                            {
                                No = noB++,
                                UphID = entity.UphID,
                                UphName = entity.Uph?.Name,
                                NamaPerusahaan = entity.nama_perusahaan,
                                JenisKemitraan = entity.jenis_mitra,

                                ClusterGrade = "B",
                                ClusterGradeStar = 3,
                                TotalNilai = total_nilai,
                                TotalNilaiRata2 = rata2totalNilai
                            });
                    }
                    else if (rata2totalNilai >= 2 && rata2totalNilai < 3)
                    {
                        uphMitraClustersC.ClusterTotal++; // C
                        uphMitraClustersC
                            .UphMitras.Add(new UphMitraClusterByGradeDTO
                            {
                                No = noC++,
                                UphID = entity.UphID,
                                UphName = entity.Uph?.Name,
                                NamaPerusahaan = entity.nama_perusahaan,
                                JenisKemitraan = entity.jenis_mitra,

                                ClusterGrade = "C",
                                ClusterGradeStar = 2,
                                TotalNilai = total_nilai,
                                TotalNilaiRata2 = rata2totalNilai
                            });
                    }
                    else if (rata2totalNilai < 2)
                    {
                        uphMitraClustersD.ClusterTotal++; // D
                        uphMitraClustersD
                            .UphMitras.Add(new UphMitraClusterByGradeDTO
                            {
                                No = noD++,
                                UphID = entity.UphID,
                                UphName = entity.Uph?.Name,
                                NamaPerusahaan = entity.nama_perusahaan,
                                JenisKemitraan = entity.jenis_mitra,

                                ClusterGrade = "D",
                                ClusterGradeStar = 1,
                                TotalNilai = total_nilai,
                                TotalNilaiRata2 = rata2totalNilai
                            });
                    }
                }
                #endregion
            }

            uphMitraClusters.Add(uphMitraClustersA);
            uphMitraClusters.Add(uphMitraClustersB);
            uphMitraClusters.Add(uphMitraClustersC);
            uphMitraClusters.Add(uphMitraClustersD);

            return uphMitraClusters;
        }
    }
}