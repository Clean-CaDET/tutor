using System.Reflection;
using Shouldly;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;
using Xunit;

namespace Tutor.Elaborations.Tests.Unit;

public class ConceptElaborationTaskTests
{
    [Fact]
    public void IsAttemptComplete_returns_true_when_no_relations_and_all_KPs_covered()
    {
        var kp = MakeKp(1);
        var task = MakeTask(kps: [kp], relations: []);
        var attempt = MakeAttemptWithCoveredAndArticulated(coveredKpIds: [1], articulatedRelationIds: []);

        task.IsAttemptComplete(attempt).ShouldBeTrue();
    }

    [Fact]
    public void IsAttemptComplete_returns_false_when_relations_exist_but_not_articulated()
    {
        var kp1 = MakeKp(1);
        var kp2 = MakeKp(2);
        var task = MakeTask(
            kps: [kp1, kp2],
            relations: [MakeRelation(10, 1, 2)]);
        var attempt = MakeAttemptWithCoveredAndArticulated(coveredKpIds: [1, 2], articulatedRelationIds: []);

        task.IsAttemptComplete(attempt).ShouldBeFalse();
    }

    [Fact]
    public void IsAttemptComplete_returns_true_when_all_KPs_covered_and_all_relations_articulated()
    {
        var kp1 = MakeKp(1);
        var kp2 = MakeKp(2);
        var task = MakeTask(
            kps: [kp1, kp2],
            relations: [MakeRelation(10, 1, 2)]);
        var attempt = MakeAttemptWithCoveredAndArticulated(coveredKpIds: [1, 2], articulatedRelationIds: [10]);

        task.IsAttemptComplete(attempt).ShouldBeTrue();
    }

    private static KeyProposition MakeKp(int id)
    {
        var kp = new KeyProposition();
        SetProp(kp, "Id", id);
        return kp;
    }

    private static KeyRelation MakeRelation(int id, int sourceKpId, int targetKpId)
    {
        var kr = new KeyRelation();
        SetProp(kr, "Id", id);
        SetProp(kr, "SourceKeyPropositionId", sourceKpId);
        SetProp(kr, "TargetKeyPropositionId", targetKpId);
        return kr;
    }

    private static ConceptElaborationTask MakeTask(List<KeyProposition> kps, List<KeyRelation> relations)
    {
        var task = new ConceptElaborationTask();
        SetProp(task, "KeyPropositions", kps);
        SetProp(task, "BoundaryConditions", new List<BoundaryCondition>());
        SetProp(task, "CommonMisconceptions", new List<CommonMisconception>());
        SetProp(task, "KeyRelations", relations);
        return task;
    }

    private static ConversationAttempt MakeAttemptWithCoveredAndArticulated(
        List<int> coveredKpIds, List<int> articulatedRelationIds)
    {
        var ctor = typeof(ConversationAttempt)
            .GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, Type.EmptyTypes)!;
        var attempt = (ConversationAttempt)ctor.Invoke(null);

        var evalCtor = typeof(TurnEvaluation).GetConstructors().First(c => c.GetParameters().Length > 0);
        var evaluation = (TurnEvaluation)evalCtor.Invoke([
            true, 2, 2, (int?)null, (int?)null, "test", null,
            coveredKpIds, new List<int>(), articulatedRelationIds
        ]);

        var turnCtor = typeof(ConversationTurn).GetConstructors(
                BindingFlags.NonPublic | BindingFlags.Instance)
            .First(c => c.GetParameters().Length > 0);
        var turn = (ConversationTurn)turnCtor.Invoke([TurnRole.Learner, "x", 0, evaluation]);

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
