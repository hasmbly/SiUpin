using MediatR;

namespace SiUpin.Shared.Users.Commands.ResetPassword
{
    public class ResetPasswordRequest : IRequest<ResetPasswordResponse>
    {
        public string UserID { get; set; }
        public string Password { get; set; } = "Password0!";
    }
}
