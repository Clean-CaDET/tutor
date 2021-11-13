namespace Tutor.Core.LearnerModel.Learners
{
    public class KnowledgeComponentProgress
    {
        public int Id { get; private set; }
        public double Progress { get; private set; }
        public int KnowledgeComponentId { get; private set; }
        public int LearnerId { get; private set; }

        public void UpgradeProgress() {}
    }
}