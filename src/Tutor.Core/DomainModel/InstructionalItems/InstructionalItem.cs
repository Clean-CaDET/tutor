namespace Tutor.Core.DomainModel.InstructionalItems
{
    public class InstructionalItem
    {
        public int Id { get; private set; }
        public int KnowledgeComponentId { get; private set; }
        public int Order { get; private set; }
        protected InstructionalItem() {}

        protected InstructionalItem(int id, int knowledgeComponentId)
        {
            Id = id;
            KnowledgeComponentId = knowledgeComponentId;
        }
    }
}