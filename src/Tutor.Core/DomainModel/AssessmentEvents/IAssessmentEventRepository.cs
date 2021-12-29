namespace Tutor.Core.DomainModel.AssessmentEvents
{
    public interface IAssessmentEventRepository
    {
        AssessmentEvent GetAssessmentEvent(int assessmentEventId);
        void SaveSubmission(Submission submission);

        Submission FindSubmissionWithMaxCorrectness(Submission submission);
    }
}
