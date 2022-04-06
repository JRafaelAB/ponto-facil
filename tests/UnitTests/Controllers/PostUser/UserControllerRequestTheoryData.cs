using Xunit;

namespace UnitTests.Controllers.PostUser
{
    public class UserControllerRequestTheoryData : TheoryData<string>
    {
        public UserControllerRequestTheoryData()
        {
            this.Add("{\"Name\":\"\",\"Login\":\"login\",\"Password\":\"password\"}");
            this.Add("{\"Name\":\"   \",\"Login\":\"login\",\"Password\":\"password\"}");
            this.Add("{\"Login\":\"login\",\"Password\":\"password\"}");
            this.Add("{\"Name\":\"name\",\"Login\":\"\",\"Password\":\"password\"}");
            this.Add("{\"Name\":\"name\",\"Login\":\"    \",\"Password\":\"password\"}");
            this.Add("{\"Name\":\"name\",\"Password\":\"password\"}");
            this.Add("{\"Name\":\"name\",\"Login\":\"login\",\"Password\":\"\"}");
            this.Add("{\"Name\":\"name\",\"Login\":\"login\",\"Password\":\"      \"}");
            this.Add("{\"Name\":\"name\",\"Login\":\"login\"}");
        }
    }
}
