using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public class ScoreResponse
{
    public List<ScoredTargetDto>? Assessments { get; set; }
    public List<string>? MisconceptionsTriggeredKeys { get; set; }

    public class ScoredTargetDto
    {
        public string Key { get; set; } = "";
        public string Type { get; set; } = "";
        public int Grade { get; set; }
    }

    public Result<TurnEvaluation> ToEvaluation(ConceptRecord record)
    {
        if (Assessments == null) return Result.Fail("Assessments missing.");

        var kpKeys = record.KeyPropositions.Select(kp => kp.Key).ToHashSet();
        var krKeys = record.KeyRelations.Select(kr => kr.Key).ToHashSet();
        var allKeys = kpKeys.Union(krKeys).ToHashSet();

        var returnedKeys = Assessments.Select(a => a.Key).ToHashSet();
        if (!returnedKeys.SetEquals(allKeys)) return Result.Fail("Incomplete or unknown keys in assessments.");
        if (Assessments.Any(a => a.Grade is < 0 or > 3)) return Result.Fail("Grade out of range.");

        var creationResult = CreateScoredTargets(kpKeys, krKeys);
        if(creationResult.IsFailed) return Result.Fail(creationResult.Errors);
        var scoredTargets = creationResult.Value;

        var misconceptions = MisconceptionsTriggeredKeys ?? [];
        var validCmKeys = record.CommonMisconceptions.Select(cm => cm.Key).ToHashSet();
        if (misconceptions.Any(k => !validCmKeys.Contains(k))) return Result.Fail("Unknown misconception key.");

        var concerns = scoredTargets.Count(a => a.Grade == 1) + misconceptions.Count;
        return new TurnEvaluation(scoredTargets, misconceptions, hasMultipleConcerns: concerns >= 2);
    }

    private Result<List<ScoredTarget>> CreateScoredTargets(HashSet<string> kpKeys, HashSet<string> krKeys)
    {
        var scoredTargets = new List<ScoredTarget>();
        foreach (var dto in Assessments!)
        {
            ScoredTargetType? type = dto.Type.ToLowerInvariant() switch
            {
                "proposition" => ScoredTargetType.Proposition,
                "relation" => ScoredTargetType.Relation,
                _ => null
            };
            switch (type)
            {
                case null:
                    return Result.Fail($"Unknown type '{dto.Type}'.");
                case ScoredTargetType.Proposition when !kpKeys.Contains(dto.Key):
                    return Result.Fail($"Key '{dto.Key}' typed as proposition but is a relation.");
                case ScoredTargetType.Relation when !krKeys.Contains(dto.Key):
                    return Result.Fail($"Key '{dto.Key}' typed as relation but is a proposition.");
            }

            if (dto.Grade > 0)
                scoredTargets.Add(new ScoredTarget(dto.Key, type.Value, dto.Grade));
        }

        return scoredTargets;
    }
}
