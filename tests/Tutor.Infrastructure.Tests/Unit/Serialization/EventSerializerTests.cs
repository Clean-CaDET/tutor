using Shouldly;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;
using Tutor.Infrastructure.Serialization;
using Xunit;

namespace Tutor.Infrastructure.Tests.Unit.Serialization
{
    public class EventSerializerTests
    {
        [Theory]
        [MemberData(nameof(Events))]
        public void Serializes_and_deserializes_events(DomainEvent @event)
        {
            var serializer = new EventSerializer();

            var serialized = serializer.Serialize(@event);
            var deserialized = serializer.Deserialize(serialized);

            deserialized.ShouldNotBeNull();
            deserialized.ShouldBeOfType(@event.GetType());
            foreach (var property in @event.GetType().GetProperties())
            {
                property.GetValue(deserialized).ShouldBe(property.GetValue(@event));
            }
        }

        public static IEnumerable<object[]> Events() => new List<object[]>
        {
            new object[]
            {
                new AssessmentItemSelected()
                {
                    KnowledgeComponentId = 1,
                    AssessmentItemId = 2,
                    LearnerId = 3
                }
            },
            new object[]
            {
                new AssessmentItemAnswered()
            }
        };
    }
}
