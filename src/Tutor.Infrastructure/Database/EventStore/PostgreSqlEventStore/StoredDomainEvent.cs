﻿using System;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Database.EventStore.PostgreSqlEventStore
{
    public class StoredDomainEvent
    {
        public int Id { get; set; }
        public string AggregateType { get; set; }
        public int AggregateId { get; set; }
        public DateTime TimeStamp { get; set; }
        public DomainEvent DomainEvent { get; set; }
    }
}
