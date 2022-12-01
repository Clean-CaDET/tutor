using Tutor.Core.BuildingBlocks.Generics;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Core.UseCases.Management.Stakeholder;

public class InstructorService : CrudService<Instructor>, IInstructorService
{
    public InstructorService(ICrudRepository<Instructor> crudRepository) : base(crudRepository) {}
}