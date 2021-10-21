using System.Text.RegularExpressions;
using Domain.Utils;
using Xunit;

namespace UnitTests.Utils
{
    public class SaltUtilsTest
    {
        [Fact]
        public void TestingSucess_Generate()
        {
            for (uint size = 0; size < 1000; size++)
            {
                string salt = Salt.Generate(size);
                Assert.Equal((int)size, salt.Length);
                foreach (char c in salt)
                {
                    Assert.Matches(new Regex("([a-z]|[0-9]|[A-Z])"), c.ToString());
                }
                
            }
        }
    }
}
