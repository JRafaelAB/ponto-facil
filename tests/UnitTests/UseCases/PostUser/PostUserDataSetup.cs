using Domain.DTOs;
using Domain.Models.Requests;

namespace UnitTests.UseCases.PostUser
{
    public static class PostUserDataSetup
    {
        public static readonly PostUserRequest validUser = new("usuario", "email", "senha");
        public static readonly UserDto user = new(PostUserDataSetup.validUser, "10", "10");
    }
}