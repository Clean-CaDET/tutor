using Tutor.KnowledgeComponents.API.Dtos.KnowledgeMastery;

namespace Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;

public interface IKnowledgeMasteryRepository
{
    KnowledgeComponentMastery GetBare(int knowledgeComponentId, int learnerId);
    KnowledgeComponentMastery GetFull(int knowledgeComponentId, int learnerId);
    KnowledgeComponentMastery GetFullByAssessmentItem(int assessmentItemId, int learnerId);
    List<KnowledgeComponentMastery> GetBareByKcs(List<int> kcIds, int learnerId);
    void Update(KnowledgeComponentMastery kcMastery);
    void Create(KnowledgeComponentMastery kcMastery);
    List<KnowledgeComponentMasteryDto> GetByLearnersAndUnit(int unitId, int[] learnerIds);

    /*public List<KnowledgeComponentMastery> GetMasteriesForLearnersAndUnit(int unitId, int[] learnerIds)
    {
        var kcIds = DbContext.KnowledgeComponents
            .Where(kc => kc.KnowledgeUnitId == unitId)
            .Select(kc => kc.Id);

        return DbContext.KcMasteries
            .Where(kcm => learnerIds.Contains(kcm.LearnerId) && kcIds.Contains(kcm.KnowledgeComponentId))
            .Include(kcm => kcm.AssessmentItemMasteries)
            .Include(kcm => kcm.SessionTracker)
            .ToList();
    }*/
}