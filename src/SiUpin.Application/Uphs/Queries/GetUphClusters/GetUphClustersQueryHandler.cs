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
using SiUpin.Shared.Uphs.Queries.GetUphClusterGrades;

namespace SiUpin.Application.Uphs.Queries.GetUphClusters
{
    public class GetUphClustersQueryHandler : IRequestHandler<GetUphClusterGradesRequest, GetUphClusterGradesResponse>
    {
        private readonly ISiUpinDBContext _context;

        public GetUphClustersQueryHandler(ISiUpinDBContext context)
        {
            _context = context;
        }

        public async Task<GetUphClusterGradesResponse> Handle(GetUphClusterGradesRequest request, CancellationToken cancellationToken)
        {
            var result = new GetUphClusterGradesResponse();

            var records = await _context.Uphs
                .AsNoTracking()
                .Include(a => a.UphMitras)
                .Include(b => b.UphProduksis)
                .Include(c => c.UphSaranas)
                .Include(d => d.UphSdms)
                .Include(e => e.UphPasars)
                .Include(e => e.UphPasars)
                .Include(f => f.UphGmps)
                .Include(g => g.ParameterAdministrasi)
                .Include(h => h.ParameterBadanHukum)
                .Include(i => i.ParameterBentukLembaga)
                .Include(j => j.ParameterStatusUph)
                .Include(h => h.Provinsi)
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

        public List<UphClusterDTO> calculateClusterUph(IList<Uph> Uphs)
        {
            var uphClusters = new List<UphClusterDTO>();

            var uphClustersA = new UphClusterDTO { No = 1, ClusterGrade = "A", ClusterGradeStar = 4 };
            var uphClustersB = new UphClusterDTO { No = 2, ClusterGrade = "B", ClusterGradeStar = 3 };
            var uphClustersC = new UphClusterDTO { No = 3, ClusterGrade = "C", ClusterGradeStar = 2 };
            var uphClustersD = new UphClusterDTO { No = 4, ClusterGrade = "D", ClusterGradeStar = 1 };

            int noA = 1;
            int noB = 1;
            int noC = 1;
            int noD = 1;

            foreach (var uph in Uphs)
            {
                #region get all value
                int uphBentukLembagaValue = int.Parse(s: uph.ParameterBentukLembaga?.Skor ?? "0");
                int uphBadanHukumValue = int.Parse(s: uph.ParameterBadanHukum?.Skor ?? "0");
                int uphStatusUphValue = int.Parse(s: uph.ParameterStatusUph?.Skor ?? "0");
                int uphAdministrasiValue = int.Parse(s: uph.ParameterAdministrasi?.Skor ?? "0");

                var pasarJangkauan = uph.UphPasars.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.jangkauan;
                int pasarJangkauanValue = int.Parse(s: _context.ParameterJawabans.AsNoTracking().FirstOrDefault(x => x.Name == pasarJangkauan)?.Skor ?? "0");

                int pasarNilaiMekanisme = int.Parse(s: uph.UphPasars.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.nilai_mekanisme ?? "0");
                int pasarNilaiMekanismeValue = pasarNilaiMekanisme > 1 || pasarNilaiMekanisme >= 3 ? 5 :
                    pasarNilaiMekanisme <= 1 ? 3 : 0;

                var sdmStrukturModal = uph.UphSdms.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.struktur_modal;
                int? sdmStrukturModalValue = int.Parse(_context.ParameterJawabans.AsNoTracking().FirstOrDefault(x => x.Name == sdmStrukturModal)?.Skor ?? "0");

                int? sdmJmlModalValue = int.Parse(uph.UphSdms.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.jml_modal ?? "0");

                var produksiJmlHariProduksi = uph.UphProduksis.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.jml_hari_produksi;
                int? produksiJmlHariProduksiValue = int.Parse(_context.ParameterJawabans.AsNoTracking()
                    .FirstOrDefault(x => x.Name == produksiJmlHariProduksi)?.Skor ?? "0");

                int gmpJmlGmpValue = int.Parse(uph.UphGmps.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.jml_gmp ?? "0") / 2;

                int saranaKapasitasTerpakai = int.Parse(uph.UphSaranas.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.kapasitas_terpakai ?? "0");
                int? saranaKapasitasTerpasang = int.Parse(uph.UphSaranas.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.kapasitas_terpasang ?? "0");

                int? saranaKapasitas = 0;
                if (saranaKapasitasTerpakai != 0 && saranaKapasitasTerpasang != 0)
                    saranaKapasitas = (saranaKapasitasTerpakai / saranaKapasitasTerpasang) * 100;

                int? saranaKapasitasCount = saranaKapasitas >= 75 ? 5 :
                    saranaKapasitas >= 50 && saranaKapasitas <= 74 ? 3 :
                    saranaKapasitas <= 49 && saranaKapasitas >= 1 ? 1 : 0;
                int? saranaKapasitasValue = saranaKapasitasCount;

                var produksiIzinEdar = uph.UphProduksis.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.izin_edar;
                int? produksiIzinEdarValue = int.Parse(_context.ParameterJawabans.AsNoTracking().FirstOrDefault(x => x.Name == produksiIzinEdar)?.Skor ?? "0");

                int produksiJmlSertifikat = int.Parse(uph.UphProduksis.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.jml_sertifikat ?? "0");
                int produksiJmlSertifikatValue = produksiJmlSertifikat > 1 ? 5 :
                    produksiJmlSertifikat == 1 ? 3 : 0;

                var mitraNilaiMitra = int.Parse(uph.UphMitras.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.nilai_mitra ?? "0");
                int? mitraNilaiMitraValue = mitraNilaiMitra / 3;

                var mitraBermitra = uph.UphMitras.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.bermitra;
                int? mitraBermitraValue = int.Parse(_context.ParameterJawabans.AsNoTracking().FirstOrDefault(x => x.Name == mitraBermitra)?.Skor ?? "0");

                var mitraPerjanjian = uph.UphMitras.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.perjanjian;
                int? mitraPerjanjianValue = int.Parse(_context.ParameterJawabans.AsNoTracking().FirstOrDefault(x => x.Name == mitraPerjanjian)?.Skor ?? "0");

                int? mitraNilaiLembagaValue = int.Parse(uph.UphMitras.FirstOrDefault(x => x.UphID == uph.UphID || x.id_uph == uph.id_uph)?.nilai_lembaga ?? "0");
                #endregion

                #region count total value
                int? totalNilai =
                    uphAdministrasiValue + pasarNilaiMekanismeValue +
                    sdmJmlModalValue + produksiJmlHariProduksiValue +
                    gmpJmlGmpValue + saranaKapasitasValue +
                    produksiJmlSertifikatValue + mitraNilaiMitraValue +
                    mitraBermitraValue + mitraPerjanjianValue +
                    mitraNilaiLembagaValue + uphBadanHukumValue +
                    uphBentukLembagaValue + uphStatusUphValue +
                    produksiIzinEdarValue + sdmStrukturModalValue + pasarJangkauanValue;

                #region code analysis
                //if (uph.Name == "MUTIARA")
                //{
                //    Console.WriteLine($"uph.Name: {uph.Name}");

                //    Console.WriteLine($"uphBentukLembagaValue: {uphBentukLembagaValue}");
                //    Console.WriteLine($"uphBadanHukumValue: {uphBadanHukumValue}");
                //    Console.WriteLine($"uphStatusUphValue: {uphStatusUphValue}");
                //    Console.WriteLine($"uphAdministrasiValue: {uphAdministrasiValue}");
                //    Console.WriteLine("");
                //    Console.WriteLine($"produksiIzinEdarValue: {produksiIzinEdarValue}");
                //    Console.WriteLine($"produksiJmlSertifikatValue: {produksiJmlSertifikatValue}");
                //    Console.WriteLine($"produksiJmlHariProduksiValue: {produksiJmlHariProduksiValue}");
                //    Console.WriteLine("");
                //    Console.WriteLine($"mitraBermitraValue: {mitraBermitraValue}");
                //    Console.WriteLine($"mitraPerjanjianValue: {mitraPerjanjianValue}");
                //    Console.WriteLine($"mitraJenisKemitraanNilaiMitraValue: {mitraNilaiMitraValue}");
                //    Console.WriteLine($"mitraNilaiLembagaValue: {mitraNilaiLembagaValue}");
                //    Console.WriteLine("");
                //    Console.WriteLine($"sdmJmlModalValue: {sdmJmlModalValue}");
                //    Console.WriteLine($"sdmStrukturModalValue: {sdmStrukturModalValue}");
                //    Console.WriteLine("");
                //    Console.WriteLine($"saranaKapasitasValue: {saranaKapasitasValue}");
                //    Console.WriteLine("");
                //    Console.WriteLine($"pasarNilaiMekanismeValue: {pasarNilaiMekanismeValue}");
                //    Console.WriteLine($"pasarJangkauanValue: {pasarJangkauanValue}");
                //    Console.WriteLine("");
                //    Console.WriteLine($"gmpJmlGmpValue: {gmpJmlGmpValue}");
                //    Console.WriteLine("");
                //}
                #endregion

                int? aspekKelembagaan =
                    mitraNilaiLembagaValue + uphBadanHukumValue +
                    uphStatusUphValue + mitraBermitraValue +
                    mitraPerjanjianValue + uphAdministrasiValue +
                    mitraNilaiMitraValue + mitraNilaiLembagaValue;
                double? nilaiAspekKelembagaan = aspekKelembagaan * 0.19;

                int? aspekSumberDaya =
                    sdmJmlModalValue + sdmStrukturModalValue;
                double? nilaiAspekSumberDaya = aspekSumberDaya * 0.08;

                int? aspekProduksi =
                    gmpJmlGmpValue + saranaKapasitasValue +
                    produksiJmlHariProduksiValue + produksiJmlSertifikatValue +
                    produksiIzinEdarValue;
                double? nilaiAspekProduksi = aspekProduksi * 0.42;

                int? aspekPasar =
                    pasarJangkauanValue + pasarNilaiMekanismeValue;
                double? nilaiAspekPasar = aspekPasar * 0.31;

                double? totalNilaiAspek =
                    nilaiAspekKelembagaan + nilaiAspekSumberDaya +
                    nilaiAspekProduksi + nilaiAspekPasar;

                double? rata2totalNilaiAspek = totalNilaiAspek / 4;

                if (rata2totalNilaiAspek.HasValue)
                {
                    if (rata2totalNilaiAspek >= 4)
                    {
                        uphClustersA.ClusterTotal++; // A
                        uphClustersA
                            .Uphs.Add(new UphClusterByGradeDTO
                            {
                                No = noA++,
                                UphID = uph.UphID,
                                Name = uph.Name,
                                Provinsi = uph.Provinsi?.Name,
                                Alamat = uph.Alamat,
                                Handphone = uph.Handphone,
                                ClusterGrade = "A",
                                ClusterGradeStar = 4,
                                TotalNilai = totalNilaiAspek,
                                TotalNilaiRata2 = rata2totalNilaiAspek
                            });
                    }
                    else if (rata2totalNilaiAspek >= 3 && rata2totalNilaiAspek < 4)
                    {
                        uphClustersB.ClusterTotal++; // B
                        uphClustersB
                            .Uphs.Add(new UphClusterByGradeDTO
                            {
                                No = noB++,
                                UphID = uph.UphID,
                                Name = uph.Name,
                                Provinsi = uph.Provinsi?.Name,
                                Alamat = uph.Alamat,
                                Handphone = uph.Handphone,
                                ClusterGrade = "B",
                                ClusterGradeStar = 3,
                                TotalNilai = totalNilaiAspek,
                                TotalNilaiRata2 = rata2totalNilaiAspek
                            });
                    }
                    else if (rata2totalNilaiAspek >= 2 && rata2totalNilaiAspek < 3)
                    {
                        uphClustersC.ClusterTotal++; // C
                        uphClustersC
                            .Uphs.Add(new UphClusterByGradeDTO
                            {
                                No = noC++,
                                UphID = uph.UphID,
                                Name = uph.Name,
                                Provinsi = uph.Provinsi?.Name,
                                Alamat = uph.Alamat,
                                Handphone = uph.Handphone,
                                ClusterGrade = "C",
                                ClusterGradeStar = 2,
                                TotalNilai = totalNilaiAspek,
                                TotalNilaiRata2 = rata2totalNilaiAspek
                            });
                    }
                    else if (rata2totalNilaiAspek < 2)
                    {
                        uphClustersD.ClusterTotal++; // D
                        uphClustersD
                            .Uphs.Add(new UphClusterByGradeDTO
                            {
                                No = noD++,
                                UphID = uph.UphID,
                                Name = uph.Name,
                                Provinsi = uph.Provinsi?.Name,
                                Alamat = uph.Alamat,
                                Handphone = uph.Handphone,
                                ClusterGrade = "D",
                                ClusterGradeStar = 1,
                                TotalNilai = totalNilaiAspek,
                                TotalNilaiRata2 = rata2totalNilaiAspek
                            });
                    }
                }
                #endregion
            }

            uphClusters.Add(uphClustersA);
            uphClusters.Add(uphClustersB);
            uphClusters.Add(uphClustersC);
            uphClusters.Add(uphClustersD);

            return uphClusters;
        }
    }
}