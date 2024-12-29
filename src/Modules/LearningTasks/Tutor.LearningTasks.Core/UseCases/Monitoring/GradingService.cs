﻿using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.TaskProgress;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Monitoring;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Core.UseCases.Monitoring;

public class GradingService : BaseService<TaskProgressDto, TaskProgress>, IGradingService
{
    private readonly ITaskProgressRepository _progressRepository;
    private readonly ILearningTaskRepository _taskRepository;
    private readonly IAccessServices _accessServices;
    private readonly ILearningTasksUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GradingService(ITaskProgressRepository progressRepository, ILearningTaskRepository taskRepository, IAccessServices accessServices,
        ILearningTasksUnitOfWork unitOfWork, IMapper mapper) : base(mapper)
    {
        _progressRepository = progressRepository;
        _taskRepository = taskRepository;
        _accessServices = accessServices;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public Result<List<TaskProgressDto>> GetByUnitAndLearner(int unitId, int learnerId, int instructorId)
    {
        if (!_accessServices.IsUnitOwner(unitId, instructorId)) return Result.Fail(FailureCode.Forbidden);

        var tasks = _taskRepository.GetNonTemplateByUnit(unitId);
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
        _progressRepository.UpdateEvents(taskProgress);
        var result = _unitOfWork.Save();
        if (result.IsFailed) return result;
        return MapToDto(taskProgress);
    }

    public Result<List<TaskProgressDto>> GetGroupSummaries(int[] unitIds, int[] groupMemberIds, int instructorId)
    {
        if (unitIds.Length == 0 || groupMemberIds.Length == 0) return Result.Ok(new List<TaskProgressDto>());
        if (!_accessServices.IsUnitOwner(unitIds[0], instructorId)) return Result.Fail(FailureCode.Forbidden);

        var tasks = _taskRepository.GetNonTemplateByUnits(unitIds);
        var taskProgresses = _progressRepository.GetByTasksAndGroup(tasks.Select(t => t.Id).ToArray(), groupMemberIds);
        return MapToDto(taskProgresses);
    }
}
