using System;
using System.Collections.Generic;
using System.Linq;

namespace SiUpin.WebUI.Common
{
    public static class Constants
    {
        public const string Bearer = "Bearer";

        public static class URI
        {
            public const string BaseAPI = "api/v1";

            public static class Dev
            {
                public static readonly string Base = $"{BaseAPI}/dev";
            }

            public static class Region
            {
                public static readonly string Base = $"{BaseAPI}/region";

                public static readonly string GetProvinsis = $"{Base}/GetProvinsis";
                public static readonly string GetKotasByProvinsiID = $"{Base}/GetKotasByProvinsiID/?provinsiID=";
                public static readonly string GetKecamatansByKotaID = $"{Base}/GetKecamatansByKotaID/?kotaID=";
                public static readonly string GetKelurahansByKecamatanID = $"{Base}/GetKelurahansByKecamatanID/?kecamatanID=";
            }

            public static class Auth
            {
                public static readonly string Base = $"{BaseAPI}/auth";

                public static readonly string CheckUsername = $"{Base}/checkUsername";
                public static readonly string Login = $"{Base}/login";
            }

            public static class User
            {
                public static readonly string Base = $"{BaseAPI}/user";

                public static readonly string GetUser = $"{Base}/?id=";
                public static readonly string GetRoles = $"{Base}/GetRoles";
                public static readonly string Paginate = $"{Base}/paginate";
                public static readonly string Register = $"{Base}/register";
                public static readonly string ResetPassword = $"{Base}/resetPassword";
                public static readonly string Delete = $"{Base}/Delete";
            }

            public static class Uph
            {
                public static readonly string Base = $"{BaseAPI}/uph";

                public static readonly string Details = $"{Base}/details/";
                public static readonly string Register = $"{Base}/register";
                public static readonly string Paginate = $"{Base}/paginate";
                public static readonly string Delete = $"{Base}/Delete";

                public static readonly string CountByProvince = $"{Base}/countByProvince";
                public static readonly string UphIDandNames = $"{Base}/uphIDandNames";

                public static readonly string Cluster = $"{Base}/cluster/";
                public static readonly string ClusterPaginate = $"{Base}/cluster/paginate";

                public static readonly string ClusterGrade = $"{Base}/cluster/grade";
            }

            public static class UphProduk
            {
                public static readonly string Base = $"{BaseAPI}/UphProduk";

                public static readonly string Paginate = $"{Base}/paginate";
                public static readonly string Delete = $"{Base}/Delete";
                public static readonly string PaginateByUphID = $"{Base}/paginateByUphID";
                public static readonly string Register = $"{Base}/register";
            }

            public static class UphBahanBaku
            {
                public static readonly string Base = $"{BaseAPI}/UphBahanBaku";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
                public static readonly string Paginate = $"{Base}/paginate";
            }

            public static class UphSarana
            {
                public static readonly string Base = $"{BaseAPI}/UphSarana";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
                public static readonly string Paginate = $"{Base}/paginate";
            }

            public static class UphGmp
            {
                public static readonly string Base = $"{BaseAPI}/UphGmp";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
                public static readonly string Paginate = $"{Base}/paginate";
            }

            public static class UphMitra
            {
                public static readonly string Base = $"{BaseAPI}/UphMitra";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
                public static readonly string Paginate = $"{Base}/paginate";

                public static readonly string ClusterGrade = $"{Base}/cluster/grade";
            }

            public static class UphPasar
            {
                public static readonly string Base = $"{BaseAPI}/UphPasar";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
                public static readonly string Paginate = $"{Base}/paginate";
            }

            public static class UphProduksi
            {
                public static readonly string Base = $"{BaseAPI}/UphProduksi";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
                public static readonly string Paginate = $"{Base}/paginate";
            }

            public static class UphSdm
            {
                public static readonly string Base = $"{BaseAPI}/UphSdm";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
                public static readonly string Paginate = $"{Base}/paginate";
            }

            public static class Berita
            {
                public static readonly string Base = $"{BaseAPI}/Berita";

                public static readonly string Paginate = $"{Base}/paginate";
                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
            }

            public static class Pesan
            {
                public static readonly string Base = $"{BaseAPI}/Pesan";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
            }

            public static class JenisKomoditi
            {
                public static readonly string Base = $"{BaseAPI}/jenisKomoditi";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
            }

            public static class JenisTernak
            {
                public static readonly string Base = $"{BaseAPI}/jenisTernak";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
            }

            public static class ProdukOlahan
            {
                public static readonly string Base = $"{BaseAPI}/ProdukOlahan";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
            }

            public static class Satuan
            {
                public static readonly string Base = $"{BaseAPI}/Satuan";

                public static readonly string Register = $"{Base}/register";
                public static readonly string Delete = $"{Base}/delete";
            }

            public static class ParameterJawaban
            {
                public static readonly string Base = $"{BaseAPI}/ParameterJawaban";

                public static readonly string ByIndikatorName = $"{Base}/byIndikatorName/?indikatorName=";
            }

            public static class File
            {
                public static readonly string Base = $"{BaseAPI}/File";

                public static readonly string Register = $"{Base}/register";
            }
        }

        public static class Pagination
        {
            public const int PageSize = 10;
            public const int PageNumber = 1;
        }

        public static class FileEntityType
        {
            public const string Berita = "BERITA";
            public const string UphProduk = "UPH_PRODUK";
        }

        public static class JenisKomoditiID
        {
            public const string Susu = "Susu";
            public const string Daging = "Daging";
            public const string Unggas = "Unggas dan Aneka Ternak";
            public const string HasilTernak = "Hasil Ikutan Ternak";
            public const string Limbah = "Limbah";
        }

        public static class ParameterIndikator
        {
            public static class ParameterIndikatorName
            {
                public const string AdministrasiKegiatanDanKeuangan = "Administrasi kegiatan dan keuangan";
                public const string KesesuaianDenganGMP = "Kesesuaian dengan GMP";
                public const string Bermitra = "Bermitra";
                public const string Sertifikat = "Sertifikat";
                public const string JumlahHariProduksi = "Jumlah hari produksi";
                public const string StatusUPH = "Status UPH";
                public const string MoU = "MoU";
                public const string IzinEdar = "Izin edar";
                public const string LembagaYangBermitra = "Lembaga yang bermitra";
                public const string SumberModal = "Sumber modal";
                public const string StrukturPermodalan = "Struktur permodalan";
                public const string BentukKelembagaan = "Bentuk kelembagaan";
                public const string MekanismePemasaran = "Mekanisme pemasaran";
                public const string RasioKapasitasTerpakaiTerhadapKapasitasTerpasang = "Rasio kapasitas terpakai terhadap kapasitas terpasang";
                public const string JangkauanPemasaran = "Jangkauan Pemasaran";
                public const string JenisKemitraan = "Jenis Kemitraan";
                public const string BadanHukum = "Badan hukum";
            }
        }

        public static class UphSdm
        {
            public static IList<string> SumberModals { get; set; } = new List<string>
            {
                "Bank",
                "Koperasi",
                "Non Bank",
                "Perorangan",
                "Keluarga",
                "Lainya"
            };

            public static IList<string> SOPs { get; set; } = new List<string>
            {
                "Keamanan Air",
                "Kondisi dan Kebersihan Permukaan Yang Kontak Dengan Bahan Pangan",
                "Pencegahan Kontaminasi Silang",
                "Menjaga Fasilitas Pencuci Tangan, Toilet dan Sanitasi Pekerja",
                "Proteksi Dari Bahan Kontaminan",
                "Pelabelan, Penyimpanan dan Pengunaan Bahan Toksin Yang Benar",
                "Pengawasan Kondisi Kesehatan Personil Yang Dapat Menyebabkan Kontaminasi",
                "Menghilangkan Hama Dari Unit Pengolahan"
            };

            public static IList<string> StrukturModals { get; set; } = new List<string>
            {
                "Modal Sendiri",
                "Sebagian dari pihak lain",
                "Sepenuhnya dari pihak lain",
            };

            public static IList<int> Tahuns { get; set; } = Enumerable.Range(1992, (DateTime.Now.Year - 1992) + 1).ToList();
        }

        public static class UphSarana
        {
            public static IList<string> AsalBantuans { get; set; } = new List<string>
            {
                "APBN",
                "APBD"
            };

            public static IList<int> Tahuns { get; set; } = Enumerable.Range(1992, (DateTime.Now.Year - 1992) + 1).ToList();

            public static IList<string> Alasans { get; set; } = new List<string>
            {
                "Kekurangan Bahan Baku",
                "Rusak",
                "Alat Tidak Seuai",
                "Hilang",
            };

            public static IList<string> JenisMesins { get; set; } = new List<string>
            {
                "Mesin Utama",
                "Mesin Pendukung"
            };

            public static IList<string> Status { get; set; } = new List<string>
            {
                "Beroperasi",
                "Tidak Beroperasi"
            };
        }

        public static class UphBahanBaku
        {
            public static IList<string> AsalBahanBakus { get; set; } = new List<string>
            {
                "Dari Peternakan UPH",
                "Membeli Dari Peternak Lain"
            };
        }

        public static class UphProduksi
        {
            public static IList<string> Sertifikats { get; set; } = new List<string>
            {
                "Organik",
                "Halal",
                "Sertifikat Penyuluhan",
                "NKV",
            };
        }

        public static class UphPasar
        {
            public static IList<string> Mekanismes { get; set; } = new List<string>
            {
                "Langsung ke konsumen",
                "Pedagang Perantara",
                "Online",
                "Lainya",
            };

            public static IList<string> JangkauanPemasarans { get; set; } = new List<string>
            {
                "DN Dalam Kecamatan",
                "DN Dalam Kabupaten",
                "DN Dalam Provinsi",
                "DN Antar Provinsi",
                "Luar Negeri/Ekspor",
            };
        }

        public static class UphMitra
        {
            public static IList<string> DetailSaranas { get; set; } = new List<string>
            {
                "Bangunan / Rumah Produksi / Outlet Pemasaran",
                "Alat Pengolahan dan Produksi",
                "Alat Pengemasan",
                "Lainya"
            };

            public static IList<string> Bermitras { get; set; } = new List<string>
            {
                "Ya",
                "Tidak",
            };

            public static IList<string> SasaranKemitraans { get; set; } = new List<string>
            {
                "Kemitraan Pengolahan",
                "Kemitraan Non Pengolahan",
            };

            public static IList<string> JenisUsahas { get; set; } = new List<string>
            {
                "IPS",
                "Importir",
                "Industri Olahan Lain",
                "Peternak",
            };

            public static IList<string> LembagaBermitras { get; set; } = new List<string>
            {
                "BUMN",
                "Swasta",
                "Perbankan",
                "Yayasan/LSM",
                "Lainya",
            };

            public static IList<string> JenisMitras { get; set; } = new List<string>
            {
                "Bahan baku",
                "Sarana Prasarana",
                "Peningkatan kompetensi",
                "Promosi dan pemasaran",
                "Fasilitasi",
                "Manajemen Limbah",
            };

            public static IList<string> DetailPromosis { get; set; } = new List<string>
            {
                "Media",
                "Pameran",
                "Campaign",
                "Gerakan Minum Susu",
                "Kontrak Pemasaran",
                "Rebranding Produk"
            };

            public static IList<string> DetailFasilitasis { get; set; } = new List<string>
            {
                "MD",
                "Halal",
                "NKV",
                "PIRT",
            };

            public static IList<string> DetailKompetensis { get; set; } = new List<string>
            {
                "Lebih Dari 2 Bimtek",
                "2 Bimtek",
                "1 Kali Bimtek",
            };

            public static IList<string> DetailLimbahs { get; set; } = new List<string>
            {
                "Melakukan Manajemen Limbah",
                "Tidak Melakukan Manajemen Limbah",
            };

            public static IList<string> Perjanjians { get; set; } = new List<string>
            {
                "Ada",
                "Tidak",
            };

            public static IList<string> Status { get; set; } = new List<string>
            {
                "Aktif",
                "Tidak Aktif",
            };
        }

        public static class AlertMessageStatus
        {
            public const string Success = "alert-success";
            public const string Warning = "alert-warning";
        }

        public static class StorageKey
        {
            public const string Token = "Token";
            public const string UserID = "UserID";
        }

        public static class AuthenticationType
        {
            public const string ServerAuthentication = "ServerAuthentication";
        }
    }
}