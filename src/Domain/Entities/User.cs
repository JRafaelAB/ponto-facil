using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public long Id { get; init; }
        public string Name { get; }
        public string Login { get; }
        public string Password { get; }
        public string Salt { get; }
        public IEnumerable<Clock>? Clocks { get; init; }
        
        public User(string name, string login, string password, string salt)
        {
            Name = name;
            Login = login;
            Password = password;
            Salt = salt;
        }
    }
}
