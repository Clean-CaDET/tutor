using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text.Json;

namespace Tutor.Core.BuildingBlocks.EventSourcing;

public interface IEventQueryable
{
    IEventQueryable After(DateTime moment);
    IEventQueryable Before(DateTime moment);
    IEventQueryable Where(Expression<Func<JsonDocument, bool>> condition);
    List<DomainEvent> ToList();
    List<T> ToList<T>() where T : DomainEvent;
}