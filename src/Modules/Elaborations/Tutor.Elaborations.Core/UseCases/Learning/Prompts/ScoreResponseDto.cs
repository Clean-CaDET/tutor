using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public class ScoreResponseDto
{
    public List<ScoredTargetDto>? Assessments { get; set; }

    public Result<RoundEvaluation> ToEvaluation(ConceptRecord record)
    {
        if (Assessments == null) return Result.Fail("Assessments missing.");

        var kpByKey = record.KeyPropositions.ToDictionary(kp => kp.Key);

        var returnedKeys = Assessments.Select(a => a.Key).ToHashSet();
        if (!returnedKeys.SetEquals(kpByKey.Keys)) return Result.Fail("Incomplete or unknown keys in assessments.");
        if (Assessments.Any(a => a.Grade is < -2 or > 2)) return Result.Fail("Grade out of range.");

        foreach (var dto in Assessments.Where(a => a.Grade == -2))
        {
            if (kpByKey[dto.Key].Misconception == null)
                return Result.Fail($"Key '{dto.Key}' scored -2 but has no authored misconception.");
            if (string.IsNullOrWhiteSpace(dto.Evidence))
                return Result.Fail($"Key '{dto.Key}' scored -2 without evidence.");
        }

        var assessments = Assessments
            .Select(dto => new ScoredTarget(dto.Key, dto.Grade, dto.Evidence ?? ""))
            .ToList();
        return new RoundEvaluation(assessments);
    }
}

public class ScoredTargetDto
{
    public string Key { get; set; } = "";
    public string Evidence { get; set; } = "";
    public int Grade { get; set; }
}
