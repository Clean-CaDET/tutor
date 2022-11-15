using System.Collections.Generic;

namespace Tutor.Core.Domain.Knowledge.KnowledgeComponents
{
    public interface IKnowledgeUnitRepository
    {
        KnowledgeUnit Get(int id);
        List<KnowledgeUnit> GetAll();

        List<KnowledgeUnit> GetByCourse(int courseId);
    }
}
