using System.Collections.Generic;
using System.Linq;
using Tutor.Core.DomainModel;
using Tutor.Core.DomainModel.Units;

namespace Tutor.Infrastructure.Database.Repositories
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

        public UnitKnowledgeComponent GetKnowledgeComponent(int id)
        {
            return _dbContext.UnitKnowledgeComponents.FirstOrDefault(l => l.Id == id);
        }
    }
}