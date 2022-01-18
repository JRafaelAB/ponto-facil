using Domain.Entities;

namespace Infrastructure.Services
{
    public interface ITokenService
    {
        public string GenerateToken(User userDto);
    }
}