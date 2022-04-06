using System;

namespace Domain.Exceptions
{
    public class LoginConflictException : Exception
    {
        public readonly NotificationError notificationError;

        public LoginConflictException(NotificationError notificationError)
        {
            this.notificationError = notificationError;
        }  
        
        public LoginConflictException(string errorMessage)
        {
            this.notificationError = new NotificationError(errorMessage);
        }
        
    }
}
