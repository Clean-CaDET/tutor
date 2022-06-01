using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Infrastructure.Database.EventStore.Postgres
{
    internal class PostgresEventQueryable : IEventQueryable
    {
        private readonly IEventSerializer _serializer;

        private IQueryable<StoredDomainEvent> EventSource { get; set; }
        private IEnumerable<Expression<Func<JsonDocument, bool>>> Conditions { get; set; }

        public PostgresEventQueryable(IQueryable<StoredDomainEvent> eventSource, IEventSerializer serializer)
        {
            EventSource = eventSource;
            Conditions = new List<Expression<Func<JsonDocument, bool>>>();

            _serializer = serializer;
        }

        private PostgresEventQueryable(PostgresEventQueryable parent)
        {
            EventSource = parent.EventSource;
            Conditions = parent.Conditions;

            _serializer = parent._serializer;
        }

        public IEventQueryable After(DateTime moment)
        {
            return new PostgresEventQueryable(this)
            {
                EventSource = EventSource.Where(e => e.TimeStamp >= moment.ToUniversalTime())
            };
        }

        public IEventQueryable Before(DateTime moment)
        {
            return new PostgresEventQueryable(this)
            {
                EventSource = EventSource.Where(e => e.TimeStamp <= moment.ToUniversalTime())
            };
        }

        public IEventQueryable Where(Expression<Func<JsonDocument, bool>> condition)
        {
            return new PostgresEventQueryable(this)
            {
                Conditions = Conditions.Append(condition)
            };
        }

        public List<DomainEvent> ToList()
        {
            return ApplyConditions().ToList();
        }

        public List<T> ToList<T>() where T : DomainEvent
        {
            return ApplyConditions().Where(e => e is T).Select(e => e as T).ToList();
        }

        private IEnumerable<DomainEvent> ApplyConditions()
        {
            IQueryable<JsonDocument> events = EventSource.Select(e => e.DomainEvent);
            foreach (Expression<Func<JsonDocument, bool>> condition in Conditions)
            {
                events = events.Where(condition);
            }

            return events.Select(e => _serializer.Deserialize(e));
        }
    }
}
