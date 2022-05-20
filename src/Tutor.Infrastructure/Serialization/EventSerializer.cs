using Dahomey.Json;
using System;
using System.Collections.Generic;
using System.Text.Json;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.DomainModel.AssessmentItems.ShortAnswerQuestions;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.AssessmentItemEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.KnowledgeComponentEvents;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.Events.SessionLifecycleEvents;
using Tutor.Infrastructure.Database.EventStore;

namespace Tutor.Infrastructure.Serialization
{
    public class EventSerializer : IEventSerializer
    {
        public JsonDocument Serialize(DomainEvent @event)
        {
            return JsonSerializer.SerializeToDocument(@event, EventSerializationConfiguration.GetEventSerializerOptions());
        }

        public DomainEvent Deserialize(JsonDocument @event)
        {
            return JsonSerializer.Deserialize<DomainEvent>(@event, EventSerializationConfiguration.GetEventSerializerOptions());
        }
    }
}
