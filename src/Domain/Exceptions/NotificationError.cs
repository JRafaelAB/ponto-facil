using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace Domain.Exceptions
{
    public class NotificationError
    {
        public IList<string> ErrorMessages { get; }

        [JsonIgnore]
        public bool IsInvalid => this.ErrorMessages.Any();

        public NotificationError()
        {
            ErrorMessages = new List<string>();
        }

        public void Add(string message)
        {
            this.ErrorMessages.Add(message);
        }
    }
}