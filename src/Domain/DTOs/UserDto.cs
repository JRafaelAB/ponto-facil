namespace Domain.DTOs
{
    public class UserDto
    {
        public string Name { get; }
        public string Login { get; }
        public string Password { get; }
        public string Salt { get; }
        
        public UserDto(string name, string login, string password, string salt)
        {
            Name = name;
            Login = login;
            Password = password;
            Salt = salt;
        }
    }
}
