using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Tests.TestData.EventStore
{
    public class TestEventA : DomainEvent
    {
        public string? PropertyA { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TestEventA a &&
                   TimeStamp == a.TimeStamp &&
                   PropertyA == a.PropertyA;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TimeStamp, PropertyA);
        }
    }

    public class TestEventB : DomainEvent
    {
        public int? PropertyB { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TestEventB b &&
                   TimeStamp == b.TimeStamp &&
                   PropertyB == b.PropertyB;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TimeStamp, PropertyB);
        }
    }

    public class TestEventC : TestEventB
    {
        public string? PropertyA { get; set; }

        public override bool Equals(object? obj)
        {
            return obj is TestEventC c &&
                   base.Equals(obj) &&
                   TimeStamp == c.TimeStamp &&
                   PropertyB == c.PropertyB &&
                   PropertyA == c.PropertyA;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(base.GetHashCode(), TimeStamp, PropertyB, PropertyA);
        }
    }

    public class TestAggregate : EventSourcedAggregateRoot
    {
        public void SeedEvents(IEnumerable<DomainEvent> events)
        {
            foreach (var @event in events) Causes(@event);
        }

        protected override void Apply(DomainEvent @event)
        {
            // no action needed
        }
    }
}
