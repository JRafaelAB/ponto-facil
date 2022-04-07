using System;

namespace Domain.Exceptions
{
    public class InvalidLoginException : Exception
    {
        public readonly NotificationError notificationError;

        public InvalidLoginException(NotificationError notificationError)
        {
            this.notificationError = notificationError;
        }  
        
        public InvalidLoginException(string errorMessage)
        {
            this.notificationError = new NotificationError(errorMessage);
        }
    }
}