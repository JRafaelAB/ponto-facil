using System;

namespace Domain.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public NotificationError notificationError;

        public InvalidLoginException(NotificationError notificationError)
        {
            this.notificationError = notificationError;
        }
    }
}