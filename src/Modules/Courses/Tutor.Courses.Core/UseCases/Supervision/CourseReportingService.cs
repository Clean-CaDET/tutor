using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Dtos.Reports;
using Tutor.Courses.API.Public.Supervision;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.Reflections;
using Tutor.Courses.Core.Domain.Report;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.API.Internal;

namespace Tutor.Courses.Core.UseCases.Supervision;

public class CourseReportingService : ICourseReportingService
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IInternalLearnerService _learnerService;
    private readonly IWeeklyFeedbackRepository _feedbackRepository;
    private readonly IReflectionRepository _reflectionRepository;
    private readonly IUnitEnrollmentRepository _enrollmentRepository;

    public CourseReportingService(IMapper mapper, ICourseRepository courseRepository, IGroupRepository groupRepository, 
        IInternalLearnerService learnerService, IWeeklyFeedbackRepository feedbackRepository,
        IReflectionRepository reflectionRepository, IUnitEnrollmentRepository enrollmentRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
        _groupRepository = groupRepository;
        _learnerService = learnerService;
        _feedbackRepository = feedbackRepository;
        _reflectionRepository = reflectionRepository;
        _enrollmentRepository = enrollmentRepository;
    }

    public Result<List<CourseDto>> GetStartedCourses()
    {
        var courses = _courseRepository.GetStarted();
        return courses.Select(_mapper.Map<CourseDto>).ToList();
    }

    public Result<List<GroupDto>> GetGroupedLearners(int courseId)
    {
        var groups = _groupRepository.GetCourseGroups(courseId);
        var learnerDtos = GetLearners(groups);
        return CreateGroupDtos(groups, learnerDtos);
    }

    private List<LearnerDto> GetLearners(List<LearnerGroup> groups)
    {
        var allLearnerIds = groups
            .SelectMany(g => g.LearnerIds)
            .Distinct()
            .ToList();
        var learners = _learnerService.GetMany(allLearnerIds);
        return learners.Value.Select(_mapper.Map<LearnerDto>).ToList();
    }

    private List<GroupDto> CreateGroupDtos(List<LearnerGroup> groups, List<LearnerDto> learnerDtos)
    {
        var groupDtos = new List<GroupDto>();
        foreach (var group in groups)
        {
            var groupDto = _mapper.Map<GroupDto>(group);
            groupDto.Learners = learnerDtos.Where(l => group.LearnerIds.Contains(l.Id)).ToList();
            groupDtos.Add(groupDto);
        }

        return groupDtos;
    }

    public Result<CourseReportDto> RegenerateReport(int courseId, int learnerId)
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
        return _mapper.Map<CourseReportDto>(report);
    }

    public Result<CourseReportDto> GetReport(int courseId, int learnerId)
    {
        throw new NotImplementedException();
    }

    public Result<CourseReportDto> CreateReport(CourseReportDto report)
    {
        throw new NotImplementedException();
    }

    public Result<CourseReportDto> UpdateReport(CourseReportDto report)
    {
        throw new NotImplementedException();
    }
}