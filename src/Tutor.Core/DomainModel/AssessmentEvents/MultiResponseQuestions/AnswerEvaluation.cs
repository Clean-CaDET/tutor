namespace Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions
{
    public class AnswerEvaluation
    {
        public MRQAnswer FullAnswer { get; }
        public bool SubmissionWasCorrect { get; }

        public AnswerEvaluation(MRQAnswer answer, bool isCorrect)
        {
            FullAnswer = answer;
            SubmissionWasCorrect = isCorrect;
        }
    }
}
