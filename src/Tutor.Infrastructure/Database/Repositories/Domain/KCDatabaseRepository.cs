using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentItems;
using Tutor.Core.DomainModel.AssessmentItems.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentItems.Challenges;
using Tutor.Core.DomainModel.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.DomainModel.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.DomainModel.InstructionalItems;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries;
using Tutor.Core.LearnerModel.DomainOverlay.KnowledgeComponentMasteries.MoveOn;
using Tutor.Infrastructure.Database.EventStore;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    public class KcDatabaseRepository : IKcRepository
    {
        private readonly TutorContext _dbContext;
        private readonly IEventStore _eventStore;
        private readonly IMoveOnCriteria _moveOnCriteria;

        public KcDatabaseRepository(TutorContext dbContext, IEventStore eventStore, IMoveOnCriteria moveOnCriteria)
        {
            _dbContext = dbContext;
            _eventStore = eventStore;
            _moveOnCriteria = moveOnCriteria;
        }

        public List<Unit> GetUnits()
        {
            return _dbContext.Units.ToList();
        }

        private void LoadKcHierarchy(List<KnowledgeComponent> parentKCs)
        {
            foreach (var knowledgeComponent in parentKCs)
            {
                _dbContext.Entry(knowledgeComponent).Collection(kc => kc.KnowledgeComponents).Load();
                LoadKcHierarchy(knowledgeComponent.KnowledgeComponents);
            }
        }

        public Unit GetUnitWithKcs(int id)
        {
            var unit = _dbContext.Units.Where(unit => unit.Id == id).Include(u => u.KnowledgeComponents).FirstOrDefault();
            LoadKcHierarchy(unit?.KnowledgeComponents);
            return unit;
        }

        public KnowledgeComponent GetKnowledgeComponent(int id)
        {
            return _dbContext.KnowledgeComponents.FirstOrDefault(l => l.Id == id);
        }

        public List<InstructionalItem> GetInstructionalItems(int knowledgeComponentId)
        {
            var query = _dbContext.InstructionalItems
                .Where(ie => ie.KnowledgeComponentId == knowledgeComponentId)
                .OrderBy(ie => ie.Order);
            return query.ToList();
        }

        public KnowledgeComponentMastery GetKnowledgeComponentMastery(int learnerId, int knowledgeComponentId)
        {
            var kcm = _dbContext.KcMasteries
                .Include(kcm => kcm.KnowledgeComponent)
                .ThenInclude(kc => kc.AssessmentItems)
                .ThenInclude(ae => ae.Submissions.Where(sub => sub.LearnerId == learnerId))
                .FirstOrDefault(kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponent.Id == knowledgeComponentId);
            kcm.MoveOnCriteria = _moveOnCriteria;
            return kcm;
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

        public KnowledgeComponentMastery GetKnowledgeComponentMasteryByAssessmentItem(int learnerId, int assessmentItemId)
        {
            var assessmentItem = _dbContext.AssessmentItems.FirstOrDefault(ae => ae.Id == assessmentItemId);
            return assessmentItem == null ? null : GetKnowledgeComponentMastery(learnerId, assessmentItem.KnowledgeComponentId);
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

        public List<KnowledgeComponentMastery> GetKnowledgeComponentMasteries(List<int> kcIds, int learnerId)
        {
            return _dbContext.KcMasteries.Where(kcm => kcm.LearnerId == learnerId && kcIds.Contains(kcm.KnowledgeComponent.Id)).ToList();
        }
    }
}