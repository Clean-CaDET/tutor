using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.DomainServices;

public class RuleAssessmentFeedbackGenerator : IAssessmentFeedbackGenerator
{
    public Result<Feedback> CreateFeedback(AssessmentItemMastery existingMastery, AssessmentItem item, Submission submission)
    {
        Evaluation evaluation;

        try
        {
            evaluation = item.Evaluate(submission);
        }
        catch
        {
            return Result.Fail(FailureCode.InvalidAssessmentSubmission);
        }

        if (IsPassed(existingMastery, evaluation)) return CreateSolution(evaluation);
        if (IsSecondReattempt(submission)) return CreateCorrectness(evaluation.CorrectnessLevel);

        if (IsFirstSubmission(existingMastery)) return CreatePump(evaluation.CorrectnessLevel);
        if (AnyHintsRemain(existingMastery, item)) return CreateHint(existingMastery, item, evaluation.CorrectnessLevel);

        if (IsFirstAttempt(submission)) return CreatePump(evaluation.CorrectnessLevel);

        return CreateSolution(evaluation);
    }

    private static bool IsPassed(AssessmentItemMastery existingMastery, Evaluation evaluation)
    {
        return existingMastery.IsPassed || evaluation.Correct;
    }

    private static Feedback CreateSolution(Evaluation evaluation)
    {
        return new Feedback(FeedbackType.Solution, null, evaluation);
    }

    private static bool IsSecondReattempt(Submission submission)
    {
        return submission.ReattemptCount > 1;
    }

    private static Feedback CreateCorrectness(double correctnessLevel)
    {
        return new Feedback(FeedbackType.Correctness, null, new Evaluation(correctnessLevel));
    }

    private static bool IsFirstSubmission(AssessmentItemMastery existingMastery)
    {
        return existingMastery.SubmissionCount == 0;
    }

    private static Feedback CreatePump(double correctnessLevel)
    {
        return new Feedback(FeedbackType.Pump, null, new Evaluation(correctnessLevel));
    }

    private static bool AnyHintsRemain(AssessmentItemMastery existingMastery, AssessmentItem item)
    {
        if (item.Hints == null) return false;
        return item.Hints.Count > existingMastery.HintRequestCount;
    }

    private static Feedback CreateHint(AssessmentItemMastery existingMastery, AssessmentItem item, double correctnessLevel)
    {
        return new Feedback(FeedbackType.Hint, item.Hints[existingMastery.HintRequestCount], new Evaluation(correctnessLevel));
    }

    private static bool IsFirstAttempt(Submission submission)
    {
        return submission.ReattemptCount == 0;
    }
}