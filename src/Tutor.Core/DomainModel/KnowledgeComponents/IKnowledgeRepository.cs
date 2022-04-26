namespace Tutor.Core.DomainModel.KnowledgeComponents
{
    public interface IKnowledgeRepository
    {
        public KnowledgeUnit GetUnitWithKcs(int unitId);
    }
}
