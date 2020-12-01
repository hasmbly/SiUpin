using MediatR;

namespace SiUpin.Shared.Users.Commands.DeleteUser
{
    public class DeleteUserRequest : IRequest<DeleteUserResponse>
    {
        public string UserID { get; set; }
    }
}
