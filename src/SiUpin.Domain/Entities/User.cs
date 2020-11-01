using System.Collections.Generic;
using SiUpin.Domain.Common;

namespace SiUpin.Domain.Entities
{
    public class User : AuditableEntity
    {
        public string UserID { get; set; }

        public string id { get; set; }

#pragma warning disable CS8632
        public string? RoleID { get; set; }

        public string? ProvinsiID { get; set; }
        public string? KotaID { get; set; }
        public string? KecamatanID { get; set; }
        public string? KelurahanID { get; set; }

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

        public Role Role { get; set; }

        public Provinsi Provinsi { get; set; }
        public Kota Kota { get; set; }
        public Kecamatan Kecamatan { get; set; }
        public Kelurahan Kelurahan { get; set; }

        public IList<File> Files { get; set; }

        public User()
        {
            Files = new List<File>();
        }
    }
}