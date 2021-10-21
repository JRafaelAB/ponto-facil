using System;

namespace Domain.Utils
{
    public static class Validation
    {
        public static void ValidateNullArgument(this object? obj)
        {
            if (obj == null)
            {
                throw new ArgumentException(null, nameof(obj));
            }
        }

        public static void ValidateStringArgumentNotEmpty(this string argument)
        {
            if (string.IsNullOrWhiteSpace(argument))
            {
                throw new ArgumentException(null, nameof(argument));
            }
        }
    }
}
