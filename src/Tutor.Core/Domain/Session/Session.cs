using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Core.Domain.Session;

public class Session : ValueObject
{
    public DateTime Start { get; set; }
    
    public DateTime End { get; set; }

    public List<DomainEvent> Events { get; set; }
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Start;
        yield return End;
        
        foreach (var domainEvent in Events)
        {
            yield return domainEvent;
        }
    }
}