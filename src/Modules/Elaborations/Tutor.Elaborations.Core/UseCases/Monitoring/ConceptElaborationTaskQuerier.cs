using Tutor.Elaborations.API.Internal;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Monitoring;

public class ConceptElaborationTaskQuerier : IConceptElaborationTaskQuerier
{
    private readonly IConceptElaborationTaskRepository _taskRepository;

    public ConceptElaborationTaskQuerier(IConceptElaborationTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public int CountByUnit(int unitId)
    {
        return _taskRepository.GetByUnit(unitId).Count;
    }
}
