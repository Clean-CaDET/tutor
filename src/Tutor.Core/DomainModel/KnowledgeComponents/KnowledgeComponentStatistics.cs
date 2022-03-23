namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KnowledgeComponentStatistics
    {
        public double Mastery { get; }
        public int NumberOfAssessmentEvents { get; }
        public int NumberOfCompletedAssessmentEvents { get; }
        public int NumberOfTriedAssessmentEvents { get; }
        public bool IsSatisfied { get; }

        public KnowledgeComponentStatistics(double mastery, int numberOfAssessmentEvents,
            int numberOfCompletedAssessmentEvents, int numberOfTriedAssessmentEvents, bool isSatisfied)
        {
            Mastery = mastery;
            NumberOfAssessmentEvents = numberOfAssessmentEvents;
            NumberOfCompletedAssessmentEvents = numberOfCompletedAssessmentEvents;
            NumberOfTriedAssessmentEvents = numberOfTriedAssessmentEvents;
            IsSatisfied = isSatisfied;
        }
    }
}