namespace Tutor.Core.DomainModel.AssessmentEvents.Challenges
{
    public class ChallengeSubmission : Submission
    {
        public string[] SourceCode { get; private set; }
    }
}