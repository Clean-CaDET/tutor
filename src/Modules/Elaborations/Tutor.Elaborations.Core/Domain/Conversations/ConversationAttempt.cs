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
    private readonly List<ConversationRound> _rounds = new();
    public IReadOnlyList<ConversationRound> Rounds => _rounds.AsReadOnly();

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

    public bool IsHardCapReached() => _rounds.Count >= MaxRounds;

    public bool IsStagnating()
    {
        var scores = _rounds
            .TakeLast(3)
            .Select(r => r.Evaluation.TotalScore())
            .ToList();
        if (scores.Count < 3) return false;
        return scores[2] <= scores[1] && scores[1] <= scores[0];
    }

    public void BeginRound(string elaboration, TurnEvaluation evaluation)
    {
        _rounds.Add(new ConversationRound(_rounds.Count, elaboration, evaluation));
        FinalGrade = evaluation.ComputeGrade(TotalTargets);
    }

    public void CompleteCurrentRound(string feedbackContent, IReadOnlyList<FeedbackTarget> feedbackTargets)
    {
        _rounds[^1].Complete(feedbackContent, feedbackTargets);
    }

    public IReadOnlyList<FeedbackTarget> SelectFeedbackTargets(int maxItems = 2)
    {
        var excludedProbes = GetExcludedProbes();
        var activeProbes = GetRecentActiveProbes(2);
        var deficientTargets = _rounds[^1].Evaluation.GetDeficientTargets(excludedProbes);
        var targets = new List<FeedbackTarget>();

        targets.AddRange(CreateMomentumProbes(deficientTargets, activeProbes)); // Active probes where grade improved
        if (targets.Count >= maxItems) return targets.Take(maxItems).ToList();

        targets.AddRange(CreateStagnantProbes(deficientTargets, activeProbes)); // Active probes where grade did not improve
        if (targets.Count >= maxItems) return targets.Take(maxItems).ToList();

        targets.AddRange(CreateNewProbes(deficientTargets, activeProbes)); // No active probes

        return targets.Take(maxItems).ToList();
    }

    private static List<FeedbackTarget> CreateMomentumProbes(List<ScoredTarget> deficientTargets, List<FeedbackTarget> activeProbes)
    {
        var momentumProbes = new List<FeedbackTarget>();
        foreach (var target in deficientTargets)
        {
            var relatedProbe = activeProbes.Find(probe => probe.ScoredTarget.SameTarget(target));
            if (relatedProbe?.ScoredTarget.Grade < target.Grade)
            {
                momentumProbes.Add(new FeedbackTarget(target, 0));
            }
        }

        return momentumProbes;
    }

    private static List<FeedbackTarget> CreateStagnantProbes(List<ScoredTarget> deficientTargets, List<FeedbackTarget> activeProbes)
    {
        var stagnantProbes = new List<FeedbackTarget>();
        foreach (var target in deficientTargets)
        {
            var relatedProbe = activeProbes.Find(probe => probe.ScoredTarget.SameTarget(target));
            if (relatedProbe == null || relatedProbe.ScoredTarget.Grade < target.Grade) continue;
            if (relatedProbe.ScoredTarget.Grade == target.Grade)
            {
                stagnantProbes.Add(new FeedbackTarget(target, relatedProbe.ProbesWithoutGradeChangeCount + 1));
                continue;
            }
            stagnantProbes.Add(new FeedbackTarget(target, 0));
        }
        return stagnantProbes;
    }

    private static List<FeedbackTarget> CreateNewProbes(List<ScoredTarget> deficientTargets, List<FeedbackTarget> activeProbes)
    {
        var newProbes = new List<FeedbackTarget>();
        foreach (var target in deficientTargets)
        {
            var relatedProbe = activeProbes.Find(probe => probe.ScoredTarget.SameTarget(target));
            if (relatedProbe == null)
            {
                newProbes.Add(new FeedbackTarget(target, 0));
            }
        }

        return newProbes;
    }

    private List<FeedbackTarget> GetRecentActiveProbes(int lookBack)
    {
        var activeProbes = new List<FeedbackTarget>();
        foreach (var round in _rounds.SkipLast(1).Reverse().Take(lookBack))
        {
            foreach (var target in round.FeedbackTargets)
            {
                if (target.IsStalled()) continue;
                if (activeProbes.Any(p => p.ScoredTarget.SameTarget(target.ScoredTarget))) continue;
                activeProbes.Add(target);
            }
        }
        return activeProbes;
    }

    private List<FeedbackTarget> GetExcludedProbes()
    {
        var excludedProbes = new List<FeedbackTarget>();
        foreach (var round in _rounds.SkipLast(1).Reverse())
        {
            foreach (var target in round.FeedbackTargets.Where(t => t.IsStalled()))
            {
                if (!excludedProbes.Any(p => p.ScoredTarget.SameTarget(target.ScoredTarget)))
                    excludedProbes.Add(target);
            }
        }
        return excludedProbes;
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

    public bool IsGoodEnough() => FinalGrade > 0.9;
}
