using System;
using Domain.Enums;

namespace Domain.Entities
{
    public class Clock
    {
        public long Id { get; init; }
        public ClockType Type { get; init; }
        public DateTime Time { get; init; }
        public long IdUser { get; init; }
        public User? User { get; init; }
    }
}
