using System.Threading.Tasks;
using Domain.DTOs;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(UserDto userDto);

        Task<UserDto?> GetUser(string login);
    }
}