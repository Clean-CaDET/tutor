namespace Tutor.Core.DomainModel.AssessmentItems.MultiChoiceQuestions;

public class McqEvaluation : Evaluation
{
    public string CorrectAnswer { get; }
    public string Feedback { get; set; }
    public McqEvaluation(double correctnessLevel, string correctAnswer, string feedback) : base(correctnessLevel)
    {
        CorrectAnswer = correctAnswer;
        Feedback = feedback;
    }

}