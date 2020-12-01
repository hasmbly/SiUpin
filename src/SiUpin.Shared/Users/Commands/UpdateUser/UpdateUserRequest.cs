using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SiUpin.Shared.Users.Commands.UpdateUser
{
    public class UpdateUserRequest : IRequest<UpdateUserResponse>
    {
        public string UserID { get; set; }

        [Required(ErrorMessage = "Please enter your Username.")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid e-mail address.")]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        public string Fullname { get; set; }

        [Required]
        public string RoleID { get; set; }

        public string NIP { get; set; }
        public string Telepon { get; set; }

        public string Jabatan { get; set; }
        public string Instansi { get; set; }
        public string Alamat { get; set; }

        public string ProvinsiID { get; set; }
        public string KotaID { get; set; }
        public string KecamatanID { get; set; }
        public string KelurahanID { get; set; }
    }
}
