using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SiUpin.Shared.Users.Commands.CreateUser
{
    public class CreateUserRequest : IRequest<CreateUserResponse>
    {
        [Required(ErrorMessage = "Please enter your Username.")]
        public string Username { get; set; }

        [EmailAddress(ErrorMessage = "Please enter a valid e-mail address.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter your password.")]
        public string Password { get; set; }
    }
}