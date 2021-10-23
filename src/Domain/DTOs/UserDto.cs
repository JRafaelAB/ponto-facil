using System;
using Domain.Entities;

namespace Domain.DTOs
{
    public class UserDto
    {
        public string Name { get; }
        public string Login { get; }
        public string Password { get; }
        public string Salt { get; }

        public UserDto(User user)
        {
            Name = user.Name;
            Login = user.Login;
            Password = user.Password;
            Salt = user.Salt;
        }
        
        public UserDto(string name, string login, string password, string salt)
        {
            Name = name;
            Login = login;
            Password = password;
            Salt = salt;
        }
        
        protected bool Equals(UserDto other)
        {
            return Name == other.Name && Login == other.Login && Password == other.Password && Salt == other.Salt;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == this.GetType() && Equals((UserDto)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Login, Password, Salt);
        }

        public static bool operator ==(UserDto? left, UserDto? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserDto? left, UserDto? right)
        {
            return !Equals(left, right);
        }
    }
}
