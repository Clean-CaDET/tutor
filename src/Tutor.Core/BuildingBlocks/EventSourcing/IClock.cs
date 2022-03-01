using System;

namespace Tutor.Core.BuildingBlocks.EventSourcing
{
    public interface IClock
    {
        DateTime Now();
    }
}
