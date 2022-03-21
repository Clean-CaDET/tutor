using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.DomainModel.KnowledgeComponents.MoveOn;
using Tutor.Infrastructure.Database.EventStore;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    public class KCDatabaseRepository : IKCRepository
    {
        private readonly TutorContext _dbContext;
        private readonly IEventStore _eventStore;
        private readonly IMoveOnCriteria _moveOnCriteria;

        public KCDatabaseRepository(TutorContext dbContext, IEventStore eventStore, IMoveOnCriteria moveOnCriteria)
        {
            _dbContext = dbContext;
            _eventStore = eventStore;
            _moveOnCriteria = moveOnCriteria;
        }

        public List<Unit> GetUnits()
        {
            return _dbContext.Units.ToList();
        }

        private void LoadKCs(List<KnowledgeComponent> parentKCs, int learnerId)
        {
            foreach (var knowledgeComponent in parentKCs)
            {
                _dbContext.Entry(knowledgeComponent).Collection(kc => kc.KnowledgeComponents).Load();
                _dbContext.Entry(knowledgeComponent)
                    .Collection(kc => kc.KnowledgeComponentMasteries).Query().Where(m => m.LearnerId == learnerId).Load();
                LoadKCs(knowledgeComponent.KnowledgeComponents, learnerId);
            }
        }

        public Unit GetUnit(int id, int learnerId)
        {
            var unit = _dbContext.Units.Where(unit => unit.Id == id).Include(u => u.KnowledgeComponents).FirstOrDefault();
            LoadKCs(unit?.KnowledgeComponents, learnerId);
            return unit;
        }

        public KnowledgeComponent GetKnowledgeComponent(int id)
        {
            return _dbContext.KnowledgeComponents.FirstOrDefault(l => l.Id == id);
        }

        public List<InstructionalEvent> GetInstructionalEventsByKnowledgeComponent(int id)
        {
            var query = _dbContext.InstructionalEvents
                .Where(ae => ae.KnowledgeComponentId == id);
            return query.ToList();
        }

        public KnowledgeComponentMastery GetKnowledgeComponentMastery(int learnerId, int knowledgeComponentId)
        {
            var kcm = _dbContext.KcMastery
                .Include(kcm => kcm.KnowledgeComponent)
                .ThenInclude(kc => kc.AssessmentEvents)
                .ThenInclude(ae => ae.Submissions.Where(sub => sub.LearnerId == learnerId))
                .FirstOrDefault(kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponent.Id == knowledgeComponentId);
            kcm.MoveOnCriteria = _moveOnCriteria;
            return kcm;
        }

        public void UpdateKCMastery(KnowledgeComponentMastery kcMastery)
        {
            _dbContext.KcMastery.Attach(kcMastery);
            _dbContext.SaveChanges();

            _eventStore.Save(kcMastery);
        }

        public List<KnowledgeComponent> GetAllKnowledgeComponents()
        {
            return _dbContext.KnowledgeComponents.ToList();
        }

        public KnowledgeComponentMastery GetKnowledgeComponentMasteryByAssessmentEvent(int learnerId, int assessmentEventId)
        {
            var assessmentEvent = _dbContext.AssessmentEvents.FirstOrDefault(ae => ae.Id == assessmentEventId);
            if (assessmentEvent == null)
                return null;
            return GetKnowledgeComponentMastery(learnerId, assessmentEvent.KnowledgeComponentId);
        }
    }
}