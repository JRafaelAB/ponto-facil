using Domain.DTOs;
using Domain.Entities;

namespace UnitTests.Repositories.UserRepository
{
    public static class DataSetup
    {
        public static readonly UserDto UserDto = new UserDto("name", "login", "password", "salt");
        public static readonly User User = new User("name", "login", "password", "salt");
    }
}
