using Domain.DTOs;

namespace Infrastructure.Services
{
    public interface ITokenService
    {
        public string GenerateToken(UserDto user);
    }
}