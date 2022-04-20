namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public class KcMasteryStatistics
    {
        public double Mastery { get; }
        public int TotalCount { get; }
        public int CompletedCount { get; }
        public int AttemptedCount { get; }
        public bool IsSatisfied { get; }

        public KcMasteryStatistics(double mastery, int totalCount, int completedCount, int attemptedCount, bool isSatisfied)
        {
            Mastery = mastery;
            TotalCount = totalCount;
            CompletedCount = completedCount;
            AttemptedCount = attemptedCount;
            IsSatisfied = isSatisfied;
        }
    }
}