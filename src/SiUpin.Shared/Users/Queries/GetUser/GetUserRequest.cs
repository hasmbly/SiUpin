using System.ComponentModel.DataAnnotations;
using MediatR;

namespace SiUpin.Shared.Users.Queries.GetUser
{
    public class GetUserRequest : IRequest<GetUserResponse>
    {
        [Required]
        public string UserID { get; set; }
    }
}