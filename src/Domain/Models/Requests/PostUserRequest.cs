namespace Domain.Models.Requests
{
    public class PostUserRequest
    {
        public string? Name { get; }
        public string? Login { get; }
        public string? Password { get; }

        public PostUserRequest(string? name, string? login, string? password)
        {
            Name = name;
            Login = login;
            Password = password;
        }
    }
}