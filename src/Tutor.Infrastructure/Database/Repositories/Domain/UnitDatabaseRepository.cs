using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel.Course;
using Tutor.Core.DomainModel.KnowledgeComponents;

namespace Tutor.Infrastructure.Database.Repositories.Domain
{
    public class UnitDatabaseRepository : IUnitRepository
    {
        private readonly TutorContext _dbContext;

        public UnitDatabaseRepository(TutorContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Unit GetUnit(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Unit> GetUnits()
        {
            return _dbContext.Units.ToList();
        }

        public KnowledgeComponent GetKnowledgeComponent(int id)
        {
            return _dbContext.KnowledgeComponents.FirstOrDefault(l => l.Id == id);
        }
    }
}