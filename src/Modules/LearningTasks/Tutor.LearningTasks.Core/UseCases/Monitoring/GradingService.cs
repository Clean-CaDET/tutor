using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.LearningTaskProgress;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Monitoring;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
using Tutor.LearningTasks.Core.Domain.LearningTasks;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Core.UseCases.Monitoring;

public class GradingService : CrudService<TaskProgressDto, TaskProgress>, IGradingService
{
    private readonly ITaskProgressRepository _progressRepository;
    private readonly ILearningTaskRepository _taskRepository;
    private readonly IAccessServices _accessServices;
    private readonly IMapper _mapper;

    public GradingService(ITaskProgressRepository progressRepository, ILearningTaskRepository taskRepository, IAccessServices accessServices,
        ILearningTasksUnitOfWork unitOfWork, IMapper mapper) : base(progressRepository, unitOfWork, mapper)
    {
        _progressRepository = progressRepository;
        _taskRepository = taskRepository;
        _accessServices = accessServices;
        _mapper = mapper;
    }

    public Result<List<TaskProgressDto>> GetByUnitAndLearner(int unitId, int learnerId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        List<LearningTask> tasks = _taskRepository.GetByUnit(unitId);
        List<TaskProgress> taskProgresses = new List<TaskProgress>();
        foreach(var task in tasks)
        {
            TaskProgress? taskProgress = _progressRepository.GetByTaskAndLearner(task.Id, learnerId);
            if (taskProgress != null)
                taskProgresses.Add(taskProgress);
        }
        return MapToDto(taskProgresses);
    }

    public Result<TaskProgressDto> SubmitGrade(int unitId, int progressId, StepProgressDto stepProgress, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var taskProgress = _progressRepository.Get(progressId);
        if (taskProgress == null)
            return Result.Fail(FailureCode.NotFound);

        List<StandardEvaluation> evaluations = stepProgress.Evaluations!.Select(e => _mapper.Map<StandardEvaluation>(e)).ToList();
        taskProgress.SubmitGrade(stepProgress.StepId, evaluations, stepProgress.Comment!);
        return Update(taskProgress);
    }
}
