using System.Reflection;
using Shouldly;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
using Tutor.Elaborations.Core.Domain.Conversations;
using Xunit;

namespace Tutor.Elaborations.Tests.Unit;

public class ConceptRecordTests
{
    [Fact]
    public void DeriveForLevel_filters_relations_whose_endpoints_are_above_level()
    {
        var beginnerKp = MakeKp(1, PropositionLevel.Beginner);
        var advancedKp = MakeKp(2, PropositionLevel.Advanced);
        var record = MakeRecord(
            kps: [beginnerKp, advancedKp],
            relations: [MakeRelation(10, beginnerKp.Id, advancedKp.Id, PropositionLevel.Beginner)]);

        var derived = record.DeriveForLevel(PropositionLevel.Beginner);

        derived.KeyPropositions.Count.ShouldBe(1);
        derived.KeyPropositions[0].Id.ShouldBe(beginnerKp.Id);
        derived.KeyRelations.Count.ShouldBe(0,
            "relation references an Advanced KP that was filtered out");
    }

    [Fact]
    public void DeriveForLevel_filters_relations_above_level_even_when_endpoints_survive()
    {
        var kp1 = MakeKp(1, PropositionLevel.Beginner);
        var kp2 = MakeKp(2, PropositionLevel.Beginner);
        var record = MakeRecord(
            kps: [kp1, kp2],
            relations: [MakeRelation(10, kp1.Id, kp2.Id, PropositionLevel.Advanced)]);

        var derived = record.DeriveForLevel(PropositionLevel.Beginner);

        derived.KeyPropositions.Count.ShouldBe(2);
        derived.KeyRelations.Count.ShouldBe(0,
            "relation itself is Advanced and should be filtered out");
    }

    [Fact]
    public void DeriveForLevel_keeps_relations_at_or_below_level_with_surviving_endpoints()
    {
        var kp1 = MakeKp(1, PropositionLevel.Beginner);
        var kp2 = MakeKp(2, PropositionLevel.Beginner);
        var record = MakeRecord(
            kps: [kp1, kp2],
            relations: [MakeRelation(10, kp1.Id, kp2.Id, PropositionLevel.Beginner)]);

        var derived = record.DeriveForLevel(PropositionLevel.Beginner);

        derived.KeyRelations.Count.ShouldBe(1);
        derived.KeyRelations[0].Id.ShouldBe(10);
    }

    [Fact]
    public void IsAttemptComplete_returns_true_when_no_relations_and_all_KPs_covered()
    {
        var kp = MakeKp(1, PropositionLevel.Beginner);
        var record = MakeRecord(kps: [kp], relations: []);
        var attempt = MakeAttemptWithCoveredAndArticulated(coveredKpIds: [1], articulatedRelationIds: []);

        record.IsAttemptComplete(attempt).ShouldBeTrue();
    }

    [Fact]
    public void IsAttemptComplete_returns_false_when_relations_exist_but_not_articulated()
    {
        var kp1 = MakeKp(1, PropositionLevel.Beginner);
        var kp2 = MakeKp(2, PropositionLevel.Beginner);
        var record = MakeRecord(
            kps: [kp1, kp2],
            relations: [MakeRelation(10, 1, 2, PropositionLevel.Beginner)]);
        var attempt = MakeAttemptWithCoveredAndArticulated(coveredKpIds: [1, 2], articulatedRelationIds: []);

        record.IsAttemptComplete(attempt).ShouldBeFalse();
    }

    [Fact]
    public void IsAttemptComplete_returns_true_when_all_KPs_covered_and_all_relations_articulated()
    {
        var kp1 = MakeKp(1, PropositionLevel.Beginner);
        var kp2 = MakeKp(2, PropositionLevel.Beginner);
        var record = MakeRecord(
            kps: [kp1, kp2],
            relations: [MakeRelation(10, 1, 2, PropositionLevel.Beginner)]);
        var attempt = MakeAttemptWithCoveredAndArticulated(coveredKpIds: [1, 2], articulatedRelationIds: [10]);

        record.IsAttemptComplete(attempt).ShouldBeTrue();
    }

    private static KeyProposition MakeKp(int id, PropositionLevel level)
    {
        var kp = new KeyProposition();
        SetProp(kp, "Id", id);
        SetProp(kp, "Level", level);
        return kp;
    }

    private static KeyRelation MakeRelation(int id, int sourceKpId, int targetKpId, PropositionLevel level)
    {
        var kr = new KeyRelation();
        SetProp(kr, "Id", id);
        SetProp(kr, "SourceKeyPropositionId", sourceKpId);
        SetProp(kr, "TargetKeyPropositionId", targetKpId);
        SetProp(kr, "Level", level);
        return kr;
    }

    private static ConceptRecord MakeRecord(List<KeyProposition> kps, List<KeyRelation> relations)
    {
        var record = new ConceptRecord();
        SetProp(record, "KeyPropositions", kps);
        SetProp(record, "BoundaryConditions", new List<BoundaryCondition>());
        SetProp(record, "CommonMisconceptions", new List<CommonMisconception>());
        SetProp(record, "KeyRelations", relations);
        return record;
    }

    private static ConversationAttempt MakeAttemptWithCoveredAndArticulated(
        List<int> coveredKpIds, List<int> articulatedRelationIds)
    {
        var ctor = typeof(ConversationAttempt)
            .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, Type.EmptyTypes)!;
        var attempt = (ConversationAttempt)ctor.Invoke(null);

        var evalCtor = typeof(TurnEvaluation).GetConstructors().First(c => c.GetParameters().Length > 0);
        var evaluation = (TurnEvaluation)evalCtor.Invoke([
            2, 2, (int?)null, (int?)null, "test", null,
            coveredKpIds, new List<int>(), articulatedRelationIds
        ]);

        var turnCtor = typeof(ConversationTurn).GetConstructors(
                BindingFlags.NonPublic | BindingFlags.Instance)
            .First(c => c.GetParameters().Length > 0);
        var turn = (ConversationTurn)turnCtor.Invoke([TurnRole.Learner, "x", true, 0, evaluation]);

        SetProp(attempt, "Turns", new List<ConversationTurn> { turn });
        return attempt;
    }

    private static void SetProp(object instance, string propName, object? value)
    {
        var prop = instance.GetType().GetProperty(propName,
            BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        if (prop == null)
            throw new InvalidOperationException($"Property {propName} not found on {instance.GetType().Name}");
        prop.SetValue(instance, value);
    }
}
