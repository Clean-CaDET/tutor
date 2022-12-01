using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholder;

public class LearnerService : CrudService<Learner>, ILearnerService
{
    public LearnerService(ICrudRepository<Learner> crudRepository) : base(crudRepository) {}
}