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
            .Select(r => r.Evaluation.ComputeTotalScore())
            .ToList();
        if (scores.Count < 3) return false;
        return scores[2] <= scores[1] && scores[1] <= scores[0];
    }

    public void BeginRound(string elaboration, RoundEvaluation evaluation)
    {
        _rounds.Add(new ConversationRound(_rounds.Count, elaboration, evaluation));
        FinalGrade = evaluation.ComputeGrade(TotalTargets);
    }

    public void CompleteRound(string feedbackContent, IReadOnlyList<Probe> probes)
    {
        _rounds[^1].Complete(feedbackContent, probes);
    }

    public IReadOnlyList<Probe> SelectProbes(int maxItems = 2)
    {
        var excludedProbes = GetExcludedProbes();
        var activeProbes = GetRecentActiveProbes(2);
        var deficientTargets = _rounds[^1].Evaluation.GetDeficientTargets(excludedProbes);
        var probes = new List<Probe>();

        probes.AddRange(CreateMomentumProbes(deficientTargets, activeProbes));
        if (probes.Count >= maxItems) return probes.Take(maxItems).ToList();

        probes.AddRange(CreateStagnantProbes(deficientTargets, activeProbes));
        if (probes.Count >= maxItems) return probes.Take(maxItems).ToList();

        probes.AddRange(CreateNewProbes(deficientTargets, activeProbes));

        return probes.Take(maxItems).ToList();
    }

    private static List<Probe> CreateMomentumProbes(List<ScoredTarget> deficientTargets, List<Probe> activeProbes)
    {
        var result = new List<Probe>();
        foreach (var target in deficientTargets)
        {
            var related = activeProbes.Find(p => p.ScoredTarget.SameTarget(target));
            if (related?.ScoredTarget.Grade < target.Grade)
                result.Add(new Probe(target, 0));
        }
        return result;
    }

    private static List<Probe> CreateStagnantProbes(List<ScoredTarget> deficientTargets, List<Probe> activeProbes)
    {
        var result = new List<Probe>();
        foreach (var target in deficientTargets)
        {
            var related = activeProbes.Find(p => p.ScoredTarget.SameTarget(target));
            if (related == null || related.ScoredTarget.Grade < target.Grade) continue;
            result.Add(related.ScoredTarget.Grade == target.Grade
                ? new Probe(target, related.StagnantCount + 1)
                : new Probe(target, 0));
        }
        return result;
    }

    private static List<Probe> CreateNewProbes(List<ScoredTarget> deficientTargets, List<Probe> activeProbes)
    {
        var result = new List<Probe>();
        foreach (var target in deficientTargets)
        {
            if (activeProbes.Find(p => p.ScoredTarget.SameTarget(target)) == null)
                result.Add(new Probe(target, 0));
        }
        return result;
    }

    private List<Probe> GetRecentActiveProbes(int lookBack)
    {
        var result = new List<Probe>();
        foreach (var round in _rounds.SkipLast(1).Reverse().Take(lookBack))
        {
            foreach (var probe in round.Probes)
            {
                if (probe.IsStalled()) continue;
                if (result.Any(p => p.ScoredTarget.SameTarget(probe.ScoredTarget))) continue;
                result.Add(probe);
            }
        }
        return result;
    }

    private List<Probe> GetExcludedProbes()
    {
        var result = new List<Probe>();
        foreach (var round in _rounds.SkipLast(1).Reverse())
        {
            foreach (var probe in round.Probes.Where(p => p.IsStalled()))
            {
                if (!result.Any(p => p.ScoredTarget.SameTarget(probe.ScoredTarget)))
                    result.Add(probe);
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

    public bool IsGoodEnough() => FinalGrade > 0.9;

    public bool IsWeak() => FinalGrade < 0.25;

    public bool HasImproved(double? threshold = 0.05)
    {
        if (_rounds.Count < 2) return false;
        var previousGrade = _rounds[^2].Evaluation.ComputeGrade(TotalTargets);
        return FinalGrade - previousGrade > threshold;
    }

    public bool HasGreatlyImproved() => HasImproved(0.25);
}
