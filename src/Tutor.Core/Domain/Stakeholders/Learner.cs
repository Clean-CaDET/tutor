using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.Domain.Stakeholders;

public class Learner : Entity
{
    public int UserId { get; protected set; }
    public string Name { get; protected set; }
    public string Surname { get; protected set; }
    public string Index { get; private set; }
    public List<KnowledgeComponentMastery> KnowledgeComponentMasteries { get; private set; } = new();
}