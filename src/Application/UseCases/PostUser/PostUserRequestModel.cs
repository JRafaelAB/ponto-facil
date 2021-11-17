namespace Application.UseCases.PostUser
{
    public class PostUserRequestModel
    {
        public string Name { get; }
        public string Login { get; }
        public string Password { get; }

        public PostUserRequestModel(string Name, string Login, string Password)
        {
            this.Name = Name;
            this.Login = Login;
            this.Password = Password;
        }
    }
}