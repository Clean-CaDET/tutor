using Tutor.Elaborations.API.Internal;
using Tutor.Elaborations.Core.Domain.ElaborationTasks;

namespace Tutor.Elaborations.Core.UseCases.Monitoring;

public class ElaborationTaskQuerier : IElaborationTaskQuerier
{
    private readonly IElaborationTaskRepository _taskRepository;

    public ElaborationTaskQuerier(IElaborationTaskRepository taskRepository)
    {
        _taskRepository = taskRepository;
    }

    public int CountByUnit(int unitId)
    {
        return _taskRepository.GetByUnit(unitId).Count;
    }
}
