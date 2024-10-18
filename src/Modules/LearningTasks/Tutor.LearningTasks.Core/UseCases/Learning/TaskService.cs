using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.TaskProgress;
using Tutor.LearningTasks.API.Dtos.Tasks;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Learning;
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

    public Result<List<TaskProgressSummaryDto>> GetByUnit(int unitId, int learnerId)
    {
        if (!_accessServices.IsEnrolledInUnit(unitId, learnerId))
            return Result.Fail(FailureCode.Forbidden);

        var tasks = _taskRepository.GetNonTemplateByUnit(unitId);
        var taskIds = tasks.Select(t => t.Id).ToList();
        var taskProgresses = _progressRepository.GetByTasks(taskIds, learnerId);

        var result = tasks.Select(task => new TaskProgressSummaryDto
        {
            Id = task.Id,
            Order = task.Order,
            Name = task.Name!,
            Status = string.Empty,
            TotalSteps = task.Steps!.Count(s => s.ParentId == 0),
            CompletedSteps = 0,
            MaxPoints = task.MaxPoints
        }).ToList();

        foreach (var progress in taskProgresses)
        {
            var progressDto = result.FirstOrDefault(r => r.Id == progress.LearningTaskId);
            if (progressDto != null)
            {
                progressDto.Status = progress.Status.ToString();
                progressDto.CompletedSteps = progress.StepProgresses!.Count(s => s.IsCompleted());
                progressDto.TotalScore = progress.TotalScore;
            }
        }
        return Result.Ok(result);
    }
}