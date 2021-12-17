using Domain.Models.Requests;
using Xunit;

namespace UnitTests.UseCases.PostUser
{
    public sealed class PostUserPasswordTheoryData : TheoryData<PostUserRequest>
    {
        public PostUserPasswordTheoryData()
        {
            this.Add(new PostUserRequest("name", "email", null));
            this.Add(new PostUserRequest("name", "email", ""));
            this.Add(new PostUserRequest("name", "email", " "));
        }
    }
}