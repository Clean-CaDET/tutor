using Microsoft.EntityFrameworkCore;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery;
using Tutor.KnowledgeComponents.Core.Domain.KnowledgeMastery.MoveOn;

namespace Tutor.KnowledgeComponents.Infrastructure.Database.Repositories;

public class KnowledgeMasteryDatabaseRepository : IKnowledgeMasteryRepository
{
    private readonly KnowledgeComponentsContext _dbContext;
    private readonly IEventStore _eventStore;
    private readonly IMoveOnCriteria _moveOnCriteria;

    public KnowledgeMasteryDatabaseRepository(KnowledgeComponentsContext dbContext, IEventStore eventStore, IMoveOnCriteria moveOnCriteria)
    {
        _dbContext = dbContext;
        _eventStore = eventStore;
        _moveOnCriteria = moveOnCriteria;
    }

    public KnowledgeComponentMastery? GetBare(int knowledgeComponentId, int learnerId)
    {
        var kcm = _dbContext.KcMasteries
            .Include(kcm => kcm.SessionTracker)
            .FirstOrDefault(kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponentId == knowledgeComponentId);
        kcm?.Initialize();
        return kcm;
    }

    public KnowledgeComponentMastery? GetFull(int knowledgeComponentId, int learnerId)
    {
        var kcm = _dbContext.KcMasteries
            .Include(kcm => kcm.SessionTracker)
            .Include(kcm => kcm.AssessmentItemMasteries)
            .FirstOrDefault(kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponentId == knowledgeComponentId);
        if (kcm == null) return null;

        kcm.MoveOnCriteria = _moveOnCriteria;
        kcm.Initialize();
        return kcm;
    }

    public KnowledgeComponentMastery? GetFullByAssessmentItem(int assessmentItemId, int learnerId)
    {
        var assessmentItem = _dbContext.AssessmentItems.FirstOrDefault(ae => ae.Id == assessmentItemId);
        return assessmentItem == null ? null : GetFull(assessmentItem.KnowledgeComponentId, learnerId);
    }

    public List<KnowledgeComponentMastery> GetBareByKcs(List<int> kcIds, int learnerId)
    {
        var kcms = _dbContext.KcMasteries
            .Include(kcm => kcm.SessionTracker)
            .Where(kcm => kcm.LearnerId == learnerId && kcIds.Contains(kcm.KnowledgeComponentId)).ToList();
        foreach (var kcm in kcms) kcm.Initialize();
        return kcms;
    }

    public void Update(KnowledgeComponentMastery kcMastery)
    {
        _dbContext.KcMasteries.Attach(kcMastery);
        _eventStore.Save(kcMastery);
    }

    public void Create(KnowledgeComponentMastery kcMastery)
    {
        _dbContext.KcMasteries.Add(kcMastery);
        _eventStore.Save(kcMastery);
    }

    public List<KnowledgeComponentMastery> GetByLearnersAndUnit(int unitId, int[] learnerIds)
    {
        var kcIds = _dbContext.KnowledgeComponents
            .Where(kc => kc.KnowledgeUnitId == unitId)
            .Select(kc => kc.Id);

        return _dbContext.KcMasteries
            .Where(kcm => learnerIds.Contains(kcm.LearnerId) && kcIds.Contains(kcm.KnowledgeComponentId))
            .Include(kcm => kcm.AssessmentItemMasteries)
            .Include(kcm => kcm.SessionTracker)
            .ToList();
    }
}