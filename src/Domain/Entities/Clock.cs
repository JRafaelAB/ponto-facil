using System;
using Domain.Enums;

namespace Domain.Entities
{
    public class Clock
    {
        public long Id { get; init; }
        public ClockType Type { get; }
        public DateTime Time { get; }
        public long IdUser { get; }
        public User? User { get; init; }
        
        public Clock(ClockType type, DateTime time, long idUser)
        {
            Type = type;
            Time = time;
            IdUser = idUser;
        }
    }
}
