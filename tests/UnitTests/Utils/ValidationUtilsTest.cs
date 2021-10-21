﻿using System;
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
        public void TestingNullArgumentException_ValidateNullArgument()
        {
            object? obj = null;
            Assert.Throws<ArgumentException>(obj.ValidateNullArgument);
        }
        
    }
}
