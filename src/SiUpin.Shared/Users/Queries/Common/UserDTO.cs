namespace SiUpin.Shared.Users.Queries.Common
{
    public class UserDTO
    {
        public string UserID { get; set; }
        public string Username { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string NIP { get; set; }
        public string Jabatan { get; set; }
        public string Instansi { get; set; }
        public string Telepon { get; set; }
        public string Alamat { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string PictureURL { get; set; }

        public string RoleID { get; set; }
        public string RoleName { get; set; }

        public string ProvinsiID { get; set; }
        public string ProvinsiName { get; set; }

        public string KotaID { get; set; }
        public string KotaName { get; set; }

        public string KecamatanID { get; set; }
        public string KecamatanName { get; set; }

        public string KelurahanID { get; set; }
        public string KelurahanName { get; set; }
    }
}
