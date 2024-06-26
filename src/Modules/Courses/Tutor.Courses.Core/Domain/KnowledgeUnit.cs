﻿using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Courses.Core.Domain;

public class KnowledgeUnit : Entity
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string? Introduction { get; private set; }
    public string? Goals { get; private set; }
    public string? Guidelines { get; private set; }
    public int Order { get; private set; }
    public int CourseId { get; set; }

    internal KnowledgeUnit Clone()
    {
        return new KnowledgeUnit
        {
            Code = Code,
            Name = Name,
            Introduction = Introduction,
            Goals = Goals,
            Guidelines = Guidelines,
            Order = Order
        };
    }
}