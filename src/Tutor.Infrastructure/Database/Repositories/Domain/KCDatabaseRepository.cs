using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.InstructionalEvents;
using Tutor.Core.DomainModel.KnowledgeComponents;

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
            return _dbContext.KcMastery
                .Include(kcm => kcm.KnowledgeComponent)
                .ThenInclude(kc => kc.AssessmentEvents)
                .ThenInclude(ae => ae.Submissions.Where(sub => sub.LearnerId == learnerId))
                .FirstOrDefault(kcm => kcm.LearnerId == learnerId && kcm.KnowledgeComponent.Id == knowledgeComponentId);
        }

        public void UpdateKCMastery(KnowledgeComponentMastery kcMastery)
        {
            _dbContext.KcMastery.Attach(kcMastery);
            _dbContext.SaveChanges();
        }

        public List<KnowledgeComponent> GetAllKnowledgeComponents()
        {
            return _dbContext.KnowledgeComponents.ToList();
        }
    }
}