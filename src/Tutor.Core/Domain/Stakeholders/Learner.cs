using System.Collections.Generic;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.Domain.Stakeholders;

public class Learner : Stakeholder
{
    public string Index { get; private set; }
    public List<KnowledgeComponentMastery> KnowledgeComponentMasteries { get; private set; } = new();
    public LearnerType LearnerType { get; private set; }
}

public enum LearnerType
{
    Regular,
    Commercial
}