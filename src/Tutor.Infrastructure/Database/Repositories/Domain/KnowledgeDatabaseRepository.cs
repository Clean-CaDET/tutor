using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    internal class KnowledgeDatabaseRepository : IKnowledgeRepository
    {
        private readonly TutorContext _dbContext;
        public KnowledgeDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public KnowledgeUnit GetUnitWithKcs(int unitId)
        {
            var unit = _dbContext.KnowledgeUnits
                .Where(u => u.Id == unitId)
                .Include(u => u.KnowledgeComponents).FirstOrDefault();
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
    }
}
