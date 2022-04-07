using System.ComponentModel.DataAnnotations;

namespace Domain.Models.Requests
{
    public class LoginUserRequest
    {
        [Required(AllowEmptyStrings = false)]
        public string Login { get; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; }

        public LoginUserRequest(string login, string password)
        {
            Login = login;
            Password = password;
        }
    }
}