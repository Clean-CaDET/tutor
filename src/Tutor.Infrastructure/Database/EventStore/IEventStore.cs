using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;

namespace Tutor.Infrastructure.Database.EventStore
{
    public interface IEventStore
    {
        void Save(KnowledgeComponentMastery aggregate);
        IEnumerable<DomainEvent> GetEvents(DateTime? start, DateTime? end);
    }
}
