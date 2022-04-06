using Domain.Models.Requests;

namespace UnitTests.UseCases.PostUser
{
    public static class PostUserDataSetup
    {
        public static readonly PostUserRequest validUser = new("usuario", "email", "senha");
    }
}