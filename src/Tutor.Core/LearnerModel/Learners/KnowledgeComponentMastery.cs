namespace Tutor.Core.LearnerModel.Learners
{
    public class KnowledgeComponentMastery
    {
        public int Id { get; private set; }
        public double Mastery { get; private set; }
        public int KnowledgeComponentId { get; private set; }
        public int LearnerId { get; private set; }

        public KnowledgeComponentMastery(int knowledgeComponentId, int learnerId)
        {
            Mastery = 0.0;
            KnowledgeComponentId = knowledgeComponentId;
            LearnerId = learnerId;
        }

        public void SetMastery(double increment)
        {
            Mastery += increment;
        }
    }
}