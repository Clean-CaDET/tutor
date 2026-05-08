using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public class ScoreResponseDto
{
    public List<ScoredTargetDto>? Assessments { get; set; }
    public List<string>? MisconceptionsTriggeredKeys { get; set; }

    public Result<RoundEvaluation> ToEvaluation(ConceptRecord record)
    {
        if (Assessments == null) return Result.Fail("Assessments missing.");

        var kpKeys = record.KeyPropositions.Select(kp => kp.Key).ToHashSet();
        var krKeys = record.KeyRelations.Select(kr => kr.Key).ToHashSet();
        var allKeys = kpKeys.Union(krKeys).ToHashSet();

        var returnedKeys = Assessments.Select(a => a.Key).ToHashSet();
        if (!returnedKeys.SetEquals(allKeys)) return Result.Fail("Incomplete or unknown keys in assessments.");
        if (Assessments.Any(a => a.Grade is < -1 or > 2)) return Result.Fail("Grade out of range.");

        var scoredTargets = CreateScoredTargets(kpKeys, krKeys);
        if (scoredTargets.IsFailed) return Result.Fail(scoredTargets.Errors);

        var misconceptions = MisconceptionsTriggeredKeys ?? [];
        var validCmKeys = record.CommonMisconceptions.Select(cm => cm.Key).ToHashSet();
        if (misconceptions.Any(k => !validCmKeys.Contains(k))) return Result.Fail("Unknown misconception key.");

        return new RoundEvaluation(scoredTargets.Value, misconceptions);
    }

    private Result<List<ScoredTarget>> CreateScoredTargets(HashSet<string> kpKeys, HashSet<string> krKeys)
    {
        var scoredTargets = new List<ScoredTarget>();
        foreach (var dto in Assessments!)
        {
            TargetType? type = dto.Type.ToLowerInvariant() switch
            {
                "proposition" => TargetType.Proposition,
                "relation" => TargetType.Relation,
                _ => null
            };
            switch (type)
            {
                case null:
                    return Result.Fail($"Unknown type '{dto.Type}'.");
                case TargetType.Proposition when !kpKeys.Contains(dto.Key):
                    return Result.Fail($"Key '{dto.Key}' typed as proposition but is a relation.");
                case TargetType.Relation when !krKeys.Contains(dto.Key):
                    return Result.Fail($"Key '{dto.Key}' typed as relation but is a proposition.");
            }
            scoredTargets.Add(new ScoredTarget(dto.Key, type.Value, dto.Grade, dto.Evidence ?? ""));
        }
        return scoredTargets;
    }
}

public class ScoredTargetDto
{
    public string Key { get; set; } = "";
    public string Type { get; set; } = "";
    public string Evidence { get; set; } = "";
    public int Grade { get; set; }
}