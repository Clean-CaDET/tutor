using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos.Reports;
using Tutor.Courses.API.Public.Supervision;
using Tutor.Courses.Core.Domain.Reflections;
using Tutor.Courses.Core.Domain.Report;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;

namespace Tutor.Courses.Core.UseCases.Supervision;

public class ReportService : CrudService<CourseReportDto, CourseReport>, IReportService
{
    private readonly IReportRepository _reportRepository;
    private readonly IWeeklyFeedbackRepository _feedbackRepository;
    private readonly IReflectionRepository _reflectionRepository;
    private readonly IUnitEnrollmentRepository _enrollmentRepository;

    public ReportService(IMapper mapper, ICoursesUnitOfWork uow, IReportRepository reportRepository,
        IWeeklyFeedbackRepository feedbackRepository, IReflectionRepository reflectionRepository,
        IUnitEnrollmentRepository enrollmentRepository) : base(reportRepository, uow, mapper)
    {
        _reportRepository = reportRepository;
        _feedbackRepository = feedbackRepository;
        _reflectionRepository = reflectionRepository;
        _enrollmentRepository = enrollmentRepository;
    }

    public Result<List<CourseReportDto>> GetMany(int[] learnerIds)
    {
        var reports = _reportRepository.GetByLearners(learnerIds);
        return reports.Select(MapToDto).ToList();
    }

    public Result<CourseReportDto> Get(int courseId, int learnerId)
    {
        var report = _reportRepository.Get(courseId, learnerId);
        if (report == null)
        {
            return RegenerateAchievements(courseId, learnerId);
        }
        return MapToDto(report);
    }

    public Result<CourseReportDto> RegenerateAchievements(int courseId, int learnerId)
    {
        var enrollments = _enrollmentRepository.GetEnrolledUnits(courseId, learnerId);
        if (enrollments.Count == 0)
        {
            return new CourseReportDto
            {
                CourseId = courseId,
                LearnerId = learnerId
            };
        }

        var unitIds = enrollments.Select(e => e.KnowledgeUnitId).ToArray();
        var reflections = _reflectionRepository.GetByUnitsWithQAndA(unitIds, learnerId);
        var feedback = _feedbackRepository.GetByCourseAndLearner(courseId, learnerId);

        var report = CourseReportFactory.CreateReport(courseId, learnerId, feedback, enrollments, reflections);
        return MapToDto(report);
    }
}