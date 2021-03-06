using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataAccess.Contexts;
using Mapster;

namespace Infrastructure.Repositories
{
    public class UserRepository: IUserRepository
    {
        private readonly ClockContext _context;

        public UserRepository(ClockContext context)
        {
            _context = context;
        }

        public async Task AddUser(UserDto userDto)
        {
            User userEntity = userDto.Adapt<User>();
            await this._context.Users.AddAsync(userEntity);
        }
    }
}
