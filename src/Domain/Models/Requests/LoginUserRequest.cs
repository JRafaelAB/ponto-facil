namespace Domain.Models.Requests
{
    public class LoginUserRequest
    {
        public string? Login { get; }
        public string? Password { get; }

        public LoginUserRequest(string? login, string? password)
        {
            Login = login;
            Password = password;
        }
    }
}