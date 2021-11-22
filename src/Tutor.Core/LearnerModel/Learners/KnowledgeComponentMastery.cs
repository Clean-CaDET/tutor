namespace Tutor.Core.LearnerModel.Learners
{
    public class KnowledgeComponentMastery
    {
        public int Id { get; private set; }
        public double Mastery { get; private set; }
        public int KnowledgeComponentId { get; private set; }
        public int LearnerId { get; private set; }
    }
}