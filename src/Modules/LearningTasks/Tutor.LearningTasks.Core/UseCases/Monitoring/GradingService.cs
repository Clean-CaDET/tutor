using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.LearningTaskProgress;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Monitoring;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
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

        var tasks = _taskRepository.GetByUnit(unitId);
        var taskProgresses = _progressRepository.GetByTasks(tasks.Select(t => t.Id).ToList(), learnerId);
        return MapToDto(taskProgresses);
    }

    public Result<TaskProgressDto> SubmitGrade(int unitId, int progressId, StepProgressDto stepProgress, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var taskProgress = _progressRepository.Get(progressId);
        if (taskProgress == null)
            return Result.Fail(FailureCode.NotFound);

        var evaluations = stepProgress.Evaluations!.Select(_mapper.Map<StandardEvaluation>).ToList();
        taskProgress.SubmitGrade(stepProgress.StepId, evaluations, stepProgress.Comment!);
        return Update(taskProgress);
    }
}
