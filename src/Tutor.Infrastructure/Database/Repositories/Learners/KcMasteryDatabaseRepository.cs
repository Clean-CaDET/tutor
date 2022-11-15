﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.BuildingBlocks.EventSourcing;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.Knowledge.AssessmentItems;
using Tutor.Core.Domain.Knowledge.AssessmentItems.ArrangeTasks;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges;
using Tutor.Core.Domain.Knowledge.AssessmentItems.Challenges.FulfillmentStrategies;
using Tutor.Core.Domain.Knowledge.AssessmentItems.MultiResponseQuestions;
using Tutor.Core.Domain.Knowledge.KnowledgeComponents;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.KnowledgeMastery.MoveOn;

namespace Tutor.Infrastructure.Database.Repositories.Learners
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
        
        public List<KnowledgeUnit> GetEnrolledAndActiveUnits(int courseId, int learnerId)
        {
            return _dbContext.UnitEnrollments
                .Where(ue => ue.LearnerId.Equals(learnerId)
                             && ue.KnowledgeUnit.Course.Id.Equals(courseId)
                             && ue.Status.Equals(EnrollmentStatus.Active))
                .Include(ue => ue.KnowledgeUnit)
                .Select(ue => ue.KnowledgeUnit).ToList();
        }

        public KnowledgeUnit GetUnitWithKcs(int unitId, int learnerId)
        {
            var unit = _dbContext.UnitEnrollments
                .Where(e => e.LearnerId == learnerId && e.KnowledgeUnit.Id == unitId)
                .Include(e => e.KnowledgeUnit)
                .ThenInclude(u => u.KnowledgeComponents)
                .Select(e => e.KnowledgeUnit).FirstOrDefault();

            return unit;
        }

        public KnowledgeComponentMastery GetBasicKcMastery(int knowledgeComponentId, int learnerId)
        {
            var kcm = _dbContext.KcMasteries
                .Include(kcm => kcm.KnowledgeComponent)
                .Include(kcm => kcm.SessionTracker)
                .FirstOrDefault(kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponent.Id == knowledgeComponentId);
            kcm?.Initialize();
            return kcm;
        }
        public List<KnowledgeComponentMastery> GetBasicKcMasteries(List<int> kcIds, int learnerId)
        {
            var kcms = _dbContext.KcMasteries.Include(kcm => kcm.SessionTracker)
                .Where(kcm => kcm.LearnerId == learnerId && kcIds.Contains(kcm.KnowledgeComponent.Id)).ToList();
            foreach (var kcm in kcms) kcm.Initialize();
            return kcms;
        }

        public KnowledgeComponentMastery GetFullKcMastery(int knowledgeComponentId, int learnerId)
        {
            var kcm = _dbContext.KcMasteries
                .Include(kcm => kcm.SessionTracker)
                .Include(kcm => kcm.AssessmentItemMasteries)
                .Include(kcm => kcm.KnowledgeComponent)
                .ThenInclude(kc => kc.InstructionalItems)
                .FirstOrDefault(kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponent.Id == knowledgeComponentId);
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
    }
}