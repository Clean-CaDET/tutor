using System;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Core.Domain.Knowledge.Structure;

public class Course : Entity
{
    public string Code { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public DateTime StartDate { get; private set; }
    public bool IsArchived { get; set; }
    public List<KnowledgeUnit> KnowledgeUnits { get; private set; }

    private Course() {}

    public Course(Course course, List<KnowledgeUnit> knowledgeUnits)
    {
        Id = course.Id;
        Code = course.Code;
        Name = course.Name;
        Description = course.Description;
        StartDate = course.StartDate;
        IsArchived = course.IsArchived;
        KnowledgeUnits = knowledgeUnits;
    }
}