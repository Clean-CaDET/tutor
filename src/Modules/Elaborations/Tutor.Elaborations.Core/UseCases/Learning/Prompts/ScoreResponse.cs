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

        var scoredTargets = new List<ScoredTarget>();
        foreach (var dto in Assessments)
        {
            ScoredTargetType? type = dto.Type.ToLowerInvariant() switch
            {
                "proposition" => ScoredTargetType.Proposition,
                "relation" => ScoredTargetType.Relation,
                _ => null
            };
            if (type == null) return Result.Fail($"Unknown type '{dto.Type}'.");
            if (type == ScoredTargetType.Proposition && !kpKeys.Contains(dto.Key))
                return Result.Fail($"Key '{dto.Key}' typed as proposition but is a relation.");
            if (type == ScoredTargetType.Relation && !krKeys.Contains(dto.Key))
                return Result.Fail($"Key '{dto.Key}' typed as relation but is a proposition.");

            if (dto.Grade > 0)
                scoredTargets.Add(new ScoredTarget(dto.Key, type.Value, dto.Grade));
        }

        var misconceptions = MisconceptionsTriggeredKeys ?? [];
        var validCmKeys = record.CommonMisconceptions.Select(cm => cm.Key).ToHashSet();
        if (misconceptions.Any(k => !validCmKeys.Contains(k))) return Result.Fail("Unknown misconception key.");

        var concerns = scoredTargets.Count(a => a.Grade == 1) + misconceptions.Count;
        return new TurnEvaluation(scoredTargets, misconceptions, hasMultipleConcerns: concerns >= 2);
    }
}
