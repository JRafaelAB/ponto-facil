using System;
using Domain.Utils;
using Xunit;

namespace UnitTests.Utils
{
    public class ValidationUtilsTest
    {
        [Theory]
        [InlineData(10)]
        [InlineData("10")]
        [InlineData(10.0)]
        [InlineData('c')]
        public void TestingSucess_ValidateNullArgument(object? obj)
        {
            obj.ValidateNullArgument();
        }
        
        [Fact]
        public void TestingArgumentException_ValidateNullArgument()
        {
            object? obj = null;
            Assert.Throws<ArgumentException>(obj.ValidateNullArgument);
        }
        
        
        [Theory]
        [InlineData("Hello World")]
        [InlineData("ahuhuhashashsauksaushushaksahksa")]
        [InlineData("c")]
        public void TestingSucess_ValidateStringArgumentNotEmpty(string argument)
        {
            argument.ValidateStringArgumentNotEmpty();
        }
        
        [Fact]
        public void TestingArgumentException_ValidateStringArgumentNotEmpty()
        {
            string argument = string.Empty;
            Assert.Throws<ArgumentException>(argument.ValidateStringArgumentNotEmpty);
        }
        
    }
}
