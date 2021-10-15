using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class User
    {
        public long Id { get; init; }
        public string Name { get; init; }
        public string Login { get; init; }
        public string Password { get; init; }
        public string Salt { get; init; }
        public IEnumerable<Clock>? Clocks { get; init; }
    }
}
