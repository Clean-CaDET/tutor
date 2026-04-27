using System.Reflection;
using Shouldly;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Tests.Unit;

public class ConceptRecordTests
{
    [Fact]
    public void IsAttemptComplete_returns_true_when_no_relations_and_all_KPs_covered()
    {
        var record = MakeRecord(
            kps: [new KeyProposition("P1", "first")],
            relations: []);
        var attempt = MakeAttemptWithCoveredAndArticulated(coveredKpKeys: ["P1"], articulatedRelationKeys: []);

        record.IsAttemptComplete(attempt).ShouldBeTrue();
    }

    [Fact]
    public void IsAttemptComplete_returns_false_when_relations_exist_but_not_articulated()
    {
        var record = MakeRecord(
            kps: [new KeyProposition("P1", "first"), new KeyProposition("P2", "second")],
            relations: [new KeyRelation("R1", "P1", "P2", "m")]);
        var attempt = MakeAttemptWithCoveredAndArticulated(coveredKpKeys: ["P1", "P2"], articulatedRelationKeys: []);

        record.IsAttemptComplete(attempt).ShouldBeFalse();
    }

    [Fact]
    public void IsAttemptComplete_returns_true_when_all_KPs_covered_and_all_relations_articulated()
    {
        var record = MakeRecord(
            kps: [new KeyProposition("P1", "first"), new KeyProposition("P2", "second")],
            relations: [new KeyRelation("R1", "P1", "P2", "m")]);
        var attempt = MakeAttemptWithCoveredAndArticulated(coveredKpKeys: ["P1", "P2"], articulatedRelationKeys: ["R1"]);

        record.IsAttemptComplete(attempt).ShouldBeTrue();
    }

    private static ConceptRecord MakeRecord(List<KeyProposition> kps, List<KeyRelation> relations)
    {
        return new ConceptRecord(
            conceptElaborationTaskId: 0,
            canonicalDefinition: "def",
            keyPropositions: kps,
            commonMisconceptions: new List<CommonMisconception>(),
            keyRelations: relations);
    }

    private static ConversationAttempt MakeAttemptWithCoveredAndArticulated(
        List<string> coveredKpKeys, List<string> articulatedRelationKeys)
    {
        var ctor = typeof(ConversationAttempt)
            .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, Type.EmptyTypes)!;
        var attempt = (ConversationAttempt)ctor.Invoke(null);

        var evaluation = new TurnEvaluation(
            2, 2, null,
            "test", null, coveredKpKeys,
            new List<string>(), articulatedRelationKeys, false);
        attempt.AddLearnerTurn("x", TurnIntent.Substantive, evaluation);
        return attempt;
    }
}