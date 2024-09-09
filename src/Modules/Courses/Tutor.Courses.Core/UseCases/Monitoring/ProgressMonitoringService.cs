using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.KnowledgeComponents.API.Internal;
using Tutor.LearningTasks.API.Dtos.Tasks;
using Tutor.LearningTasks.API.Internal;

namespace Tutor.Courses.Core.UseCases.Monitoring;

public class ProgressMonitoringService : IProgressMonitoringService
{
    private readonly IMapper _mapper;
    private readonly IOwnedCourseRepository _ownedCourseRepository;
    private readonly IUnitEnrollmentRepository _enrollmentRepository;
    private readonly IUnitProgressRatingRepository _ratingRepository;
    private readonly ITaskQuerier _taskQuerier;
    private readonly IKcProgressMonitor _kcProgressMonitor;
    private readonly ITaskProgressMonitor _taskProgressMonitor;

    public ProgressMonitoringService(IMapper mapper,
        IOwnedCourseRepository ownedCourseRepository, IUnitEnrollmentRepository enrollmentRepository,
        IUnitProgressRatingRepository ratingRepository, ITaskQuerier taskQuerier,
        IKcProgressMonitor kcProgressMonitor, ITaskProgressMonitor taskProgressMonitor)
    {
        _mapper = mapper;
        _ownedCourseRepository = ownedCourseRepository;
        _enrollmentRepository = enrollmentRepository;
        _ratingRepository = ratingRepository;
        _taskQuerier = taskQuerier;
        _kcProgressMonitor = kcProgressMonitor;
        _taskProgressMonitor = taskProgressMonitor;
    }

    public Result<List<UnitHeaderDto>> GetWeeklyUnitsWithTasksAndKcs(int instructorId, int learnerId, int courseId, DateTime weekEnd)
    {
        if (!_ownedCourseRepository.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var unitHeaders = GetUnitHeaders(learnerId, courseId, weekEnd);
        var unitIds = unitHeaders.Select(u => u.Id).ToList();
        var tasks = _taskQuerier.GetByUnits(unitIds);

        if(tasks.IsSuccess) PopulateTaskHeaders(unitHeaders, tasks.Value);

        return unitHeaders;
    }

    private List<UnitHeaderDto> GetUnitHeaders(int learnerId, int courseId, DateTime weekEnd)
    {
        var enrollments = _enrollmentRepository.GetStartedInDateRange(learnerId, weekEnd.AddDays(-8), weekEnd);
        var unitHeaders = enrollments
            .Where(e => e.KnowledgeUnit.CourseId == courseId)
            .Select(e => _mapper.Map<UnitHeaderDto>(e.KnowledgeUnit)).ToList();
        return unitHeaders;
    }

    private void PopulateTaskHeaders(List<UnitHeaderDto> unitHeaders, List<LearningTaskDto> tasks)
    {
        foreach (var unitHeader in unitHeaders)
        {
            unitHeader.Tasks = tasks
                .Where(t => t.UnitId == unitHeader.Id)
                .Select(_mapper.Map<TaskHeaderDto>)
                .ToList();
        }
    }

    public Result<List<UnitProgressRatingDto>> GetRecentRatingsForUnits(int instructorId, int[]? unitIds, DateTime weekEnd)
    {
        if (unitIds == null || unitIds.Length == 0) return Result.Fail(FailureCode.InvalidArgument);
        if (!_ownedCourseRepository.IsUnitOwner(unitIds[0], instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var ratings = _ratingRepository.GetInDateRangeForUnits(unitIds, weekEnd.AddDays(-8), weekEnd.AddDays(8));
        return ratings.Select(_mapper.Map<UnitProgressRatingDto>).ToList();
    }

    public Result<List<UnitProgressStatisticsDto>> GetKcAndTaskProgressAndWarnings(int instructorId, int[]? unitIds, int learnerId, int[] groupMemberIds)
    {
        if (unitIds == null || unitIds.Length == 0) return Result.Fail(FailureCode.InvalidArgument);
        if (!_ownedCourseRepository.IsUnitOwner(unitIds[0], instructorId))
            return Result.Fail(FailureCode.Forbidden);

        var kcUnitSummaryStatistics = _mapper.Map<PublicKcUnitSummaryStatisticsDto>(_kcProgressMonitor.GetProgress(learnerId, unitIds).Value);
        var taskUnitSummaryStatistics = _mapper.Map<PublicTaskUnitSummaryStatisticsDto>(_taskProgressMonitor.GetProgress(learnerId, unitIds, groupMemberIds).Value);

        return unitIds.Select(id => new UnitProgressStatisticsDto
        {
            UnitId = id,
            KcStatistics = kcUnitSummaryStatistics,
            TaskStatistics = taskUnitSummaryStatistics
        }).ToList();
    }
}