using Shouldly;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;
using Tutor.Infrastructure.Database.EventStore.DefaultEventSerializer;
using Tutor.Infrastructure.Tests.TestData.EventStore;
using Xunit;

namespace Tutor.Infrastructure.Tests.Unit.EventSerialization
{
    public class DefaultEventSerializerTests
    {
        [Theory]
        [MemberData(nameof(Events))]
        public void Serializes_and_deserializes_events(DomainEvent @event, IImmutableDictionary<Type, string> eventRelatedTypes)
        {
            var serializer = new DefaultEventSerializer(eventRelatedTypes);

            var serialized = serializer.Serialize(@event);
            var deserialized = serializer.Deserialize(serialized);

            deserialized.ShouldNotBeNull();
            deserialized.ShouldBeOfType(@event.GetType());
            foreach (var property in @event.GetType().GetProperties())
            {
                property.GetValue(deserialized).ShouldBe(property.GetValue(@event));
            }
        }

        public static IEnumerable<object[]> Events()
        {
            var events = TestEvents.Examples.Select(e => new object[] { e, TestEvents.Types }).ToList();
            events.Add(new object[]
            {
                new AssessmentItemSelected()
                {
                    KnowledgeComponentId = 1,
                    AssessmentItemId = 2,
                    LearnerId = 3
                },
                EventConfiguration.SerializationConfiguration
            });
            events.Add(new object[]
            {
                new AssessmentItemAnswered(),
                EventConfiguration.SerializationConfiguration
            });
            return events;
        }
    }
}
