using Domain.Models.Requests;

namespace UnitTests.UseCases.PostUser
{
    public static class PostUserDataSetup
    {
        public static readonly PostUserRequest usuarioValido = new("usuario", "email", "senha");
    }
}