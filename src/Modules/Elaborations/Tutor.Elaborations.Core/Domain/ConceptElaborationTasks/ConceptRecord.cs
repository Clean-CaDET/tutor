using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class ConceptRecord : Entity
{
    public int ConceptElaborationTaskId { get; private set; }
    public string CanonicalDefinition { get; private set; } = string.Empty;
    public List<KeyProposition> KeyPropositions { get; private set; } = [];

    private ConceptRecord() { }

    public ConceptRecord(int conceptElaborationTaskId, string canonicalDefinition, List<KeyProposition> keyPropositions)
    {
        ConceptElaborationTaskId = conceptElaborationTaskId;
        CanonicalDefinition = canonicalDefinition;
        KeyPropositions = keyPropositions;
    }

    public void Update(ConceptRecord incoming)
    {
        CanonicalDefinition = incoming.CanonicalDefinition;
        KeyPropositions = incoming.KeyPropositions;
    }

    public int CountTargets() => KeyPropositions.Count;
}
