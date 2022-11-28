using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.KnowledgeMastery.MoveOn;

namespace Tutor.Infrastructure.Database.Repositories
{
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

        public KnowledgeComponentMastery GetBareKcMastery(int knowledgeComponentId, int learnerId)
        {
            var kcm = _dbContext.KcMasteries
                .Include(kcm => kcm.SessionTracker)
                .FirstOrDefault(kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponentId == knowledgeComponentId);
            kcm?.Initialize();
            return kcm;
        }
        public List<KnowledgeComponentMastery> GetBasicKcMasteries(List<int> kcIds, int learnerId)
        {
            var kcms = _dbContext.KcMasteries
                .Include(kcm => kcm.SessionTracker)
                .Where(kcm => kcm.LearnerId == learnerId && kcIds.Contains(kcm.KnowledgeComponentId)).ToList();
            foreach (var kcm in kcms) kcm.Initialize();
            return kcms;
        }

        public KnowledgeComponentMastery GetFullKcMastery(int knowledgeComponentId, int learnerId)
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

        public KnowledgeComponentMastery GetKcMasteryForAssessmentItem(int assessmentItemId, int learnerId)
        {
            var assessmentItem = _dbContext.AssessmentItems.FirstOrDefault(ae => ae.Id == assessmentItemId);
            return assessmentItem == null ? null : GetFullKcMastery(assessmentItem.KnowledgeComponentId, learnerId);
        }

        public void UpdateKcMastery(KnowledgeComponentMastery kcMastery)
        {
            _dbContext.KcMasteries.Attach(kcMastery);
            _dbContext.SaveChanges();

            _eventStore.Save(kcMastery);
        }
    }
}