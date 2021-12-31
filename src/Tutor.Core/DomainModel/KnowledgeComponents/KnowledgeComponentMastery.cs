namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public class KnowledgeComponentMastery
    {
        public int Id { get; private set; }
        public double Mastery { get; private set; }
        public int KnowledgeComponentId { get; private set; }
        public int LearnerId { get; private set; }

        public KnowledgeComponentMastery(int knowledgeComponentId)
        {
            Mastery = 0.0;
            KnowledgeComponentId = knowledgeComponentId;
        }

        public void IncreaseMastery(double increment)
        {
            Mastery += increment;
        }
    }
}