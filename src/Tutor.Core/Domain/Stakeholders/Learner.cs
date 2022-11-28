using System.Collections.Generic;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Core.Domain.Stakeholders;

public class Learner
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public string Index { get; private set; }
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public List<KnowledgeComponentMastery> KnowledgeComponentMasteries { get; private set; } = new();
}