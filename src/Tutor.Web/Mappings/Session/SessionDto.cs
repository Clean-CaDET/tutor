using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks.EventSourcing;

namespace Tutor.Web.Mappings.Session;

public class SessionDto
{
    public DateTime Start { get; set; }
    
    public DateTime End { get; set; }

    public List<DomainEvent> Events { get; set; }
}