using Tutor.BuildingBlocks.Core.Domain;

namespace Tutor.Elaborations.Core.Domain.Conversations;

public class ConversationAttempt : AggregateRoot
{
    public int ConceptElaborationTaskId { get; private set; }
    public int LearnerId { get; private set; }
    public AttemptStatus Status { get; private set; }
    public DateTime StartedAt { get; private set; }
    public DateTime? CompletedAt { get; private set; }
    public double FinalGrade { get; private set; }
    public int TotalTargets { get; private set; }
    public int MaxRounds { get; private set; }
    public int RoundCount { get; private set; }
    private readonly List<ConversationTurn> _turns = new();
    public IReadOnlyList<ConversationTurn> Turns => _turns.AsReadOnly();

    private ConversationAttempt() { }

    public ConversationAttempt(int conceptElaborationTaskId, int learnerId, int totalTargets)
    {
        ConceptElaborationTaskId = conceptElaborationTaskId;
        LearnerId = learnerId;
        TotalTargets = totalTargets;
        Status = AttemptStatus.InProgress;
        StartedAt = DateTime.UtcNow;
        MaxRounds = Math.Max(4, (int)Math.Ceiling(totalTargets / 3.0) + 2);
    }

    public bool IsHardCapReached() => RoundCount >= MaxRounds;

    public bool IsStagnating()
    {
        var scores = Turns
            .Where(t => t.Role == TurnRole.Learner && t.Evaluation != null)
            .OrderBy(t => t.Order)
            .TakeLast(3)
            .Select(t => t.Evaluation!.TotalScore())
            .ToList();
        if (scores.Count < 3) return false;
        return scores[2] <= scores[1] && scores[1] <= scores[0];
    }

    public ConversationTurn AddLearnerTurn(string content, TurnEvaluation evaluation)
    {
        var turn = new ConversationTurn(content, _turns.Count, evaluation);
        _turns.Add(turn);

        FinalGrade = evaluation.ComputeGrade(TotalTargets);
        RoundCount++;
        return turn;
    }

    public ConversationTurn AddSystemTurn(string content, IReadOnlyList<FeedbackTarget> feedbackTargets)
    {
        var turn = new ConversationTurn(content, _turns.Count, feedbackTargets);
        _turns.Add(turn);
        return turn;
    }

    public IReadOnlyList<FeedbackTarget> SelectFeedbackTargets(int maxItems = 2)
    {
        var latestEvaluation = Turns[^1].Evaluation!;

        var lastSurfacedGrade = BuildLastSurfacedGradeMap();
        var targets = new List<FeedbackTarget>();

        foreach (var key in latestEvaluation.MisconceptionsTriggeredKeys)
        {
            targets.Add(new FeedbackTarget(key, TargetType.Misconception, 0, lastSurfacedGrade.ContainsKey(key)));
            if (targets.Count >= maxItems) return targets;
        }

        var subpar = latestEvaluation.Assessments
            .Where(a => a.Grade < 2)
            .Select(a =>
            {
                bool surfaced = lastSurfacedGrade.TryGetValue(a.Key, out var prevGrade);
                bool improved = surfaced && a.Grade > prevGrade;
                bool stagnant = surfaced && !improved;
                return (a.Key, a.Type, a.Grade, NeedsSupport: stagnant,
                    GroupOrder: improved ? 0 : !surfaced ? 1 : 2);
            })
            .OrderBy(x => x.GroupOrder)
            .ThenBy(x => x.Grade == -1 ? 0 : x.Grade == 1 ? 1 : 2);

        foreach (var item in subpar)
        {
            targets.Add(new FeedbackTarget(item.Key, item.Type, item.Grade, item.NeedsSupport));
            if (targets.Count >= maxItems) return targets;
        }

        return targets;
    }

    private Dictionary<string, int> BuildLastSurfacedGradeMap()
    {
        var result = new Dictionary<string, int>();
        foreach (var systemTurn in Turns
            .Where(t => t.Role == TurnRole.System && t.FeedbackTargets.Count > 0)
            .OrderByDescending(t => t.Order))
        {
            foreach (var target in systemTurn.FeedbackTargets)
            {
                if (!result.ContainsKey(target.Key))
                    result[target.Key] = target.Grade;
            }
        }
        return result;
    }

    public void Complete()
    {
        Status = AttemptStatus.Completed;
        CompletedAt = DateTime.UtcNow;
    }

    public void Abandon()
    {
        Status = AttemptStatus.Abandoned;
        CompletedAt = DateTime.UtcNow;
    }

    public void Expire()
    {
        Status = AttemptStatus.Expired;
        CompletedAt = DateTime.UtcNow;
    }

    public bool IsGoodEnough()
    {
        return FinalGrade > 0.9;
    }
}
