using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.MoveOn;
using Tutor.Infrastructure.Database.EventStore;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    public class KcMasteryDatabaseRepository : IKcMasteryRepository
    {
        private readonly TutorContext _dbContext;
        private readonly IEventStore _eventStore;
        private readonly IMoveOnCriteria _moveOnCriteria;

        public KcMasteryDatabaseRepository(TutorContext dbContext, IEventStore eventStore, IMoveOnCriteria moveOnCriteria)
        {
            _dbContext = dbContext;
            _eventStore = eventStore;
            _moveOnCriteria = moveOnCriteria;
        }

        public List<Unit> GetEnrolledUnits(int learnerId)
        {
            return _dbContext.UnitEnrollments
                .Where(e => e.LearnerId == learnerId)
                .Include(e => e.Unit)
                .Select(e => e.Unit).ToList();
        }

        public Unit GetUnitWithKcs(int unitId, int learnerId)
        {
            var unit = _dbContext.UnitEnrollments
                .Where(e => e.LearnerId == learnerId && e.Unit.Id == unitId)
                .Include(e => e.Unit)
                .ThenInclude(u => u.KnowledgeComponents)
                .Select(e => e.Unit).FirstOrDefault();
            LoadKcHierarchy(unit?.KnowledgeComponents);
            return unit;
        }
        private void LoadKcHierarchy(List<KnowledgeComponent> parentKCs)
        {
            foreach (var knowledgeComponent in parentKCs)
            {
                _dbContext.Entry(knowledgeComponent).Collection(kc => kc.KnowledgeComponents).Load();
                LoadKcHierarchy(knowledgeComponent.KnowledgeComponents);
            }
        }

        public KnowledgeComponentMastery GetBasicKcMastery(int knowledgeComponentId, int learnerId)
        {
            var kcm = _dbContext.KcMasteries
                .Include(kcm => kcm.KnowledgeComponent)
                .FirstOrDefault(kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponent.Id == knowledgeComponentId);
            return kcm;
        }
        public List<KnowledgeComponentMastery> GetBasicKcMasteries(List<int> kcIds, int learnerId)
        {
            return _dbContext.KcMasteries.Where(kcm => kcm.LearnerId == learnerId && kcIds.Contains(kcm.KnowledgeComponent.Id)).ToList();
        }

        public KnowledgeComponentMastery GetFullKcMastery(int knowledgeComponentId,
            int learnerId)
        {
            var kcm = _dbContext.KcMasteries
                .Include(kcm => kcm.KnowledgeComponent)
                .ThenInclude(kc => kc.AssessmentItems)
                .ThenInclude(ae => ae.Submissions.Where(sub => sub.LearnerId == learnerId))
                .Include(kcm => kcm.KnowledgeComponent)
                .ThenInclude(kc => kc.InstructionalItems)
                .FirstOrDefault(kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponent.Id == knowledgeComponentId);
            kcm.MoveOnCriteria = _moveOnCriteria;
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

        public List<KnowledgeComponent> GetAllKnowledgeComponents()
        {
            return _dbContext.KnowledgeComponents.ToList();
        }

        public AssessmentItem GetDerivedAssessmentItem(int assessmentItemId)
        {
            return _dbContext.AssessmentItems
                .Where(ae => ae.Id == assessmentItemId)
                .Include(ae => (ae as Mrq).Items)
                .Include(ae => (ae as ArrangeTask).Containers)
                .ThenInclude(c => c.Elements)
                .Include(ae => (ae as Challenge).FulfillmentStrategies)
                .ThenInclude(s => (s as BannedWordsChecker).Hint)
                .Include(ae => (ae as Challenge).FulfillmentStrategies)
                .ThenInclude(s => (s as RequiredWordsChecker).Hint)
                .Include(ae => (ae as Challenge).FulfillmentStrategies)
                .ThenInclude(s => (s as BasicMetricChecker).Hint)
                .FirstOrDefault();
        }

        public Submission FindSubmissionWithMaxCorrectness(int assessmentItemId, int learnerId)
        {
            return _dbContext.Submissions.Where(sub => sub.AssessmentItemId == assessmentItemId && sub.LearnerId == learnerId)
                .OrderBy(sub => sub.CorrectnessLevel).LastOrDefault();
        }
    }
}