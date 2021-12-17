using Domain.Models.Requests;
using Xunit;

namespace UnitTests.UseCases.PostUser
{
    public sealed class PostUserNameTheoryData : TheoryData<PostUserRequest>
    {
        public PostUserNameTheoryData()
        {
            this.Add(new PostUserRequest(null, "email", "password"));
            this.Add(new PostUserRequest("", "email", "password"));
            this.Add(new PostUserRequest(" ", "email", "password"));
        }
    }
}