namespace Tutor.KnowledgeComponents.Core.Domain.Knowledge.AssessmentItems.MultiChoiceQuestions;

public class Mcq : AssessmentItem
{
    public string Text { get; private set; }
    public List<string> PossibleAnswers { get; private set; }
    public string CorrectAnswer { get; private set; }
    public string Feedback { get; private set; }

    protected override void ClearSolution()
    {
        CorrectAnswer = string.Empty;
        Feedback = string.Empty;
    }

    public override Evaluation Evaluate(Submission submission)
    {
        if (submission is McqSubmission mcqSubmission) return EvaluateMcq(mcqSubmission);
        throw new ArgumentException("Incorrect submission supplied to SAQ with ID " + Id);
    }

    private McqEvaluation EvaluateMcq(McqSubmission saqSubmission)
    {
        var correctness = saqSubmission.Answer.Equals(CorrectAnswer) ? 1 : 0;
        return new McqEvaluation(correctness, CorrectAnswer, Feedback);
    }
}