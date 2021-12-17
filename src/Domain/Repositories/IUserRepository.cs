using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Entities;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(UserDto userDto);

        Task<User?> GetLogin(string login);
    }
}