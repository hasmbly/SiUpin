using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SiUpin.Shared.Auth.Queries.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        [Required(ErrorMessage = "Please enter your username or e-mail address.")]
        public string UsernameOrEmail { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; } = string.Empty;
    }
}
