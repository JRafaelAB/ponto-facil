using System;

namespace Domain.Exceptions
{
    public class InvalidRequestException : Exception
    {
        public NotificationError notificationError;

        public InvalidRequestException(NotificationError notificationError)
        {
            this.notificationError = notificationError;
        }
    }
}