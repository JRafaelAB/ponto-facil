using Domain.Models.Requests;
using Xunit;

namespace UnitTests.UseCases.PostUser
{
    public sealed class PostUserLoginTheoryData : TheoryData<PostUserRequest>
    {
        public PostUserLoginTheoryData()
        {
            this.Add(new PostUserRequest("name", null, "password"));
            this.Add(new PostUserRequest("name", "", "password"));
            this.Add(new PostUserRequest("name", " ", "password"));
        }
    }
}