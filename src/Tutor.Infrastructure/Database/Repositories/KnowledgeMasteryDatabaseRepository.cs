using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.KnowledgeMastery.MoveOn;

namespace Tutor.Infrastructure.Database.Repositories;

public class KnowledgeMasteryDatabaseRepository : IKnowledgeMasteryRepository
{
    private readonly TutorContext _dbContext;
    private readonly IEventStore _eventStore;
    private readonly IMoveOnCriteria _moveOnCriteria;

    public KnowledgeMasteryDatabaseRepository(TutorContext dbContext, IEventStore eventStore, IMoveOnCriteria moveOnCriteria)
    {
        _dbContext = dbContext;
        _eventStore = eventStore;
        _moveOnCriteria = moveOnCriteria;
    }

    public KnowledgeComponentMastery GetBare(int knowledgeComponentId, int learnerId)
    {
        var kcm = _dbContext.KcMasteries
            .Include(kcm => kcm.SessionTracker)
            .FirstOrDefault(kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponentId == knowledgeComponentId);
        kcm?.Initialize();
        return kcm;
    }

    public KnowledgeComponentMastery GetFull(int knowledgeComponentId, int learnerId)
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

    public KnowledgeComponentMastery GetFullForAssessmentItem(int assessmentItemId, int learnerId)
    {
        var assessmentItem = _dbContext.AssessmentItems.FirstOrDefault(ae => ae.Id == assessmentItemId);
        return assessmentItem == null ? null : GetFull(assessmentItem.KnowledgeComponentId, learnerId);
    }

    public List<KnowledgeComponentMastery> GetAllBareForLearnerAndKcs(List<int> kcIds, int learnerId)
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
    }

    public int Count(int kcId)
    {
        return _dbContext.KcMasteries.Count(m => m.KnowledgeComponentId == kcId);
    }
}