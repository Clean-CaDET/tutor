using System;

namespace Tutor.Core.BuildingBlocks.EventSourcing
{
    public class SystemClock : IClock
    {
        public DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }
}
