using System.Linq;
using System.Threading.Tasks;
using Domain.DTOs;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ClockContext _context;

        public UserRepository(ClockContext context)
        {
            _context = context;
        }

        public async Task AddUser(UserDto userDto)
        {
            User userEntity = new(userDto);
            await this._context.Users.AddAsync(userEntity);
        }

        public async Task<User?> GetLogin(string login)
        {
            return await this._context.Users.Where(user => user.Login == login).SingleOrDefaultAsync();
        }
    }
}