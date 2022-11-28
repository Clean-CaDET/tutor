using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Tests.TestData.EventStore;

public static class TestEvents
{
    public static readonly IImmutableDictionary<Type, string> Types = new Dictionary<Type, string>
    {
        { typeof(TestEventA), "TestEventA" },
        { typeof(TestEventB), "TestEventB" },
        { typeof(TestEventC), "TestEventC" }
    }.ToImmutableDictionary();

    public static readonly IEnumerable<DomainEvent> Examples = new List<DomainEvent> {
        new TestEventA() { TimeStamp = new DateTime(2022, 8, 1) },
        new TestEventA() { TimeStamp = new DateTime(2022, 8, 15), PropertyA = "test" },
        new TestEventA() { TimeStamp = new DateTime(2022, 8, 30), PropertyA = "testovi" },
        new TestEventA() { TimeStamp = new DateTime(2022, 8, 15), PropertyA = "lalalalal" },
        new TestEventB() { TimeStamp = new DateTime(2022, 8, 1) },
        new TestEventB() { TimeStamp = new DateTime(2022, 8, 15), PropertyB = 1 },
        new TestEventB() { TimeStamp = new DateTime(2022, 8, 30), PropertyB = 15 },
        new TestEventB() { TimeStamp = new DateTime(2022, 8, 15), PropertyB = 30 },
        new TestEventC() { TimeStamp = new DateTime(2022, 8, 1) },
        new TestEventC() { TimeStamp = new DateTime(2022, 8, 15), PropertyB = 1 },
        new TestEventC() { TimeStamp = new DateTime(2022, 8, 30), PropertyB = 15 },
        new TestEventC() { TimeStamp = new DateTime(2022, 8, 15), PropertyB = 30 },
        new TestEventC() { TimeStamp = new DateTime(2022, 8, 30), PropertyB = 15, PropertyA = "test" },
        new TestEventC() { TimeStamp = new DateTime(2022, 8, 30), PropertyB = 30, PropertyA = "lala" },
    };

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