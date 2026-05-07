using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

public class ConceptRecord : Entity
{
    public int ConceptElaborationTaskId { get; private set; }
    public string CanonicalDefinition { get; private set; } = string.Empty;
    public List<KeyProposition> KeyPropositions { get; private set; } = [];
    public List<CommonMisconception> CommonMisconceptions { get; private set; } = [];
    public List<KeyRelation> KeyRelations { get; private set; } = [];

    private ConceptRecord() { }

    public ConceptRecord(
        int conceptElaborationTaskId, string canonicalDefinition,
        List<KeyProposition> keyPropositions, List<CommonMisconception> commonMisconceptions,
        List<KeyRelation> keyRelations)
    {
        ConceptElaborationTaskId = conceptElaborationTaskId;
        CanonicalDefinition = canonicalDefinition;
        KeyPropositions = keyPropositions;
        CommonMisconceptions = commonMisconceptions;
        KeyRelations = keyRelations;
    }

    public void Update(ConceptRecord incoming)
    {
        CanonicalDefinition = incoming.CanonicalDefinition;
        KeyPropositions = incoming.KeyPropositions;
        CommonMisconceptions = incoming.CommonMisconceptions;
        KeyRelations = incoming.KeyRelations;
    }

    public int CountTargets() => KeyPropositions.Count + KeyRelations.Count;
}
