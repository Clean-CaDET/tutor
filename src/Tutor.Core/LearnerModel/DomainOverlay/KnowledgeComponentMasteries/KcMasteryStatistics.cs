namespace Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries
{
    public class KcMasteryStatistics
    {
        public double Mastery { get; }
        public int TotalCount { get; }
        public int PassedCount { get; }
        public int CompletedCount { get; }
        public bool IsSatisfied { get; }

        public KcMasteryStatistics(double mastery, int totalCount, int passedCount, int completedCount, bool isSatisfied)
        {
            Mastery = mastery;
            TotalCount = totalCount;
            PassedCount = passedCount;
            CompletedCount = completedCount;
            IsSatisfied = isSatisfied;
        }
    }
}