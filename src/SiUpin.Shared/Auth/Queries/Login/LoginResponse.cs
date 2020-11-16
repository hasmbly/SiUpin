using SiUpin.Shared.Common;

namespace SiUpin.Shared.Auth.Queries.Login
{
    public class LoginResponse : GeneralResponse
    {
        public bool UsernameExists { get; set; }
        public bool PasswordIsCorrect { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
    }
}
