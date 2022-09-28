﻿using System.Collections.Generic;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.InstructionalItems;

namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KnowledgeComponent
    {
        public int Id { get; private set; }
        public string Code { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int? ExpectedDurationInMinutes { get; private set; }

        public int? KnowledgeUnitId { get; private set; }
        public int? ParentId { get; private set; }
        public List<KnowledgeComponent> KnowledgeComponents { get; private set; }
        public List<AssessmentItem> AssessmentItems { get; private set; }
        public List<InstructionalItem> InstructionalItems { get; private set; }
    }
}