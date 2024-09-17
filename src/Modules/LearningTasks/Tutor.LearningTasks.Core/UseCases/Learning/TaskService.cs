using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.Tasks;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Learning;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Core.UseCases.Learning;

public class TaskService : ITaskService
{
    private readonly ILearningTaskRepository _taskRepository;
    private readonly ITaskProgressRepository _progressRepository;
    private readonly IAccessServices _accessServices;
    private readonly IMapper _mapper;

    public TaskService(ILearningTaskRepository taskRepository, ITaskProgressRepository progressRepository,
        IAccessServices accessServices, IMapper mapper)
    {
        _taskRepository = taskRepository;
        _progressRepository = progressRepository;
        _accessServices = accessServices;
        _mapper = mapper;
    }

    public Result<LearningTaskDto> Get(int id, int unitId, int learnerId)
    {
        if (!_accessServices.IsEnrolledInUnit(unitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        var learningTask = _taskRepository.Get(id);
        if(learningTask == null)
            return Result.Fail(FailureCode.NotFound);

        return _mapper.Map<LearningTaskDto>(learningTask);
    }

    public Result<List<ProgressDto>> GetByUnit(int unitId, int learnerId)
    {
        if (!_accessServices.IsEnrolledInUnit(unitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        var tasks = _taskRepository.GetNonTemplateByUnit(unitId);
        var result = new List<ProgressDto>();
        foreach (var task in tasks)
        {
            ProgressDto progressDto = new ProgressDto { Id = task.Id, Order = task.Order, Name = task.Name!,
                Status = string.Empty, TotalSteps = task.Steps!.Count(s => s.ParentId == 0) };
            TaskProgress? taskProgress = _progressRepository.GetByTask(task.Id, learnerId);
            if (taskProgress != null) {
                progressDto.Status = taskProgress.Status.ToString();
                progressDto.CompletedSteps = taskProgress.StepProgresses!.Count(s => s.Status == StepStatus.Answered || s.Status == StepStatus.Graded);
            }
            result.Add(progressDto);
        }
        return result;
    }
}