using Domain.Exceptions;
using Domain.Resources;
using System.Linq;
using Xunit;

namespace UnitTests.Exceptions
{
    public class NotificationErrorTest
    {
        [Fact]
        public void TestingSuccessAddMessage()
        {
            NotificationError notificationError = new NotificationError();
            notificationError.Add(Messages.RequiredName);
            var errors = notificationError.ErrorMessages;

            Assert.Equal(Messages.RequiredName, errors.First());
        }

        [Fact]
        public void TestingSuccessInvalidNotification()
        {
            NotificationError notificationError = new NotificationError();
            notificationError.Add(Messages.RequiredLogin);

            Assert.True(notificationError.IsInvalid);
        }
    }
}