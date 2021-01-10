﻿using System.Collections.Generic;

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

        public static class UphBahanBaku
        {
            public static IList<string> AsalBahanBakus { get; set; } = new List<string>
            {
                "Dari Peternakan UPH",
                "Membeli Dari Peternak Lain"
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