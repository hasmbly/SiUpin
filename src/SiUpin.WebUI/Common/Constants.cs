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

                public static readonly string Register = $"{Base}/register";
                public static readonly string Paginate = $"{Base}/paginate";
            }

            public static class UphProduk
            {
                public static readonly string Base = $"{BaseAPI}/UphProduk";

                public static readonly string Paginate = $"{Base}/paginate";
                public static readonly string PaginateByUphID = $"{Base}/paginateByUphID";
                public static readonly string Register = $"{Base}/register";
            }

            public static class Berita
            {
                public static readonly string Base = $"{BaseAPI}/Berita";

                public static readonly string Paginate = $"{Base}/paginate";
            }

            public static class Pesan
            {
                public static readonly string Base = $"{BaseAPI}/Pesan";

                public static readonly string GetAll = $"{Base}/GetAll";
            }

            public static class JenisKomoditi
            {
                public static readonly string Base = $"{BaseAPI}/jenisKomoditi";
            }

            public static class JenisTernak
            {
                public static readonly string Base = $"{BaseAPI}/jenisTernak";
            }

            public static class ProdukOlahan
            {
                public static readonly string Base = $"{BaseAPI}/ProdukOlahan";
            }

            public static class Satuan
            {
                public static readonly string Base = $"{BaseAPI}/Satuan";
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
            public const string Susu = "c23ab8a1-54e6-405a-8671-8645e598293b";
            public const string Daging = "efa802d0-ba25-4aa3-9b9b-bf075cc9aa98";
            public const string Unggas = "6a009abf-47d4-46ff-aeff-09b938b13a83";
            public const string HasilTernak = "525e8624-2fee-4d9d-8591-652feed3d8f8";
            public const string Limbah = "01f61dee-0c71-4e3a-baec-a8e300256aac";
        }

        public static class AlertMessageStatus
        {
            public const string Success = "alert-success";
            public const string Warning = "alert-warning";
        }

        public static class StorageKey
        {
            public const string Token = "Token";
        }

        public static class AuthenticationType
        {
            public const string ServerAuthentication = "ServerAuthentication";
        }
    }
}