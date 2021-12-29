using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.AssessmentEvents;
using Tutor.Core.DomainModel.AssessmentEvents.ArrangeTasks;
using Tutor.Core.DomainModel.AssessmentEvents.MultiResponseQuestions;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.Learners;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    public class KCDatabaseRepository : IKCRepository
    {
        private readonly TutorContext _dbContext;

        public KCDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Unit> GetUnits()
        {
            var units = _dbContext.Units.Include(u => u.KnowledgeComponents).ToList();
            foreach (var unit in units)
            {
                LoadKCs(unit.KnowledgeComponents);
            }
            
            return units;
        }

        private void LoadKCs(List<KnowledgeComponent> parentKCs)
        {
            foreach (var knowledgeComponent in parentKCs)
            {
                _dbContext.Entry(knowledgeComponent).Collection(kc => kc.KnowledgeComponents).Load();
                LoadKCs(knowledgeComponent.KnowledgeComponents);
            }
        }

        public Unit GetUnit(int id)
        {
            var unit = _dbContext.Units.Where(unit => unit.Id == id).Include(u => u.KnowledgeComponents).FirstOrDefault();
            LoadKCs(unit?.KnowledgeComponents);
            return unit;
        }

        public KnowledgeComponent GetKnowledgeComponent(int id)
        {
            return _dbContext.KnowledgeComponents.FirstOrDefault(l => l.Id == id);
        }

        public List<AssessmentEvent> GetAssessmentEventsByKnowledgeComponent(int id)
        {
            var query = _dbContext.AssessmentEvents
                .Where(ae => ae.KnowledgeComponentId == id)
                .Include(ae => (ae as Mrq).Items)
                .Include(lo => (lo as ArrangeTask).Containers)
                .ThenInclude(c => c.Elements);
            return query.ToList();
        }
        
        public List<AssessmentEvent> GetAssessmentEventsByKnowledgeComponentAndLearner(int knowledgeComponentId,
            int learnerId)
        {
            var query = _dbContext.AssessmentEvents
                .Where(ae => ae.KnowledgeComponentId == knowledgeComponentId)
                .Include(ae => ae.Submissions.Where(sub => sub.LearnerId == learnerId));
            return query.ToList();
        }

        public List<InstructionalEvent> GetInstructionalEventsByKnowledgeComponent(int id)
        {
            var query = _dbContext.InstructionalEvents
                .Where(ae => ae.KnowledgeComponentId == id);
            return query.ToList();
        }

        public KnowledgeComponentMastery GetKnowledgeComponentMastery(int learnerId, int knowledgeComponentId)
        {
            return _dbContext.KcMastery.FirstOrDefault
                (kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponentId == knowledgeComponentId);
        }

        public void UpdateKCMastery(KnowledgeComponentMastery kcMastery)
        {
            _dbContext.KcMastery.Attach(kcMastery);
            _dbContext.SaveChanges();
        }
    }
}