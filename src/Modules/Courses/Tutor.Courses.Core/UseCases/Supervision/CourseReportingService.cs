using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.API.Public.Supervision;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.Reflections;
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

    public Result<CourseDto> GetCourseWithGroupsAndUnits(int courseId)
    {
        var course = _courseRepository.GetWithUnits(courseId);
        if (course == null) return Result.Fail(FailureCode.NotFound);

        var courseDto = _mapper.Map<CourseDto>(course);
        var groups = _groupRepository.GetCourseGroups(courseId);
        var learnerDtos = GetLearners(groups);
        courseDto.Groups = CreateGroupDtos(groups, learnerDtos);
        return courseDto;
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

    public Result<CourseAchievementsDto> GetAchievements(int courseId, int learnerId)
    {
        var report = _courseRepository.GetReport(courseId, learnerId);
        var retVal = new CourseAchievementsDto
        {
            CourseId = courseId,
            LearnerId = learnerId,
            Report = report?.Report ?? string.Empty
        };

        var enrollments = _enrollmentRepository.GetEnrollments(courseId, learnerId);
        if (enrollments.Count == 0) return retVal;

        retVal.UnitAchievements = GenerateUnitAchievements(enrollments);
        retVal.TotalSatisfiedPercent =
            ToPercentage(retVal.UnitAchievements.Count(a => a.IsSatisfied), retVal.UnitAchievements.Count);
        retVal.TotalMeaningfulReflectionAnswerPercent =
            ToPercentage(retVal.UnitAchievements.Count(a => a.ContainsMeaningfulReflectionAnswer), retVal.UnitAchievements.Count);

        retVal.WeeklyFeedback = _feedbackRepository.GetByCourseAndLearner(courseId, learnerId)
            .Select(_mapper.Map<WeeklyFeedbackDto>)
            .ToList();

        return retVal;
    }

    private List<UnitAchievementsDto> GenerateUnitAchievements(List<UnitEnrollment> enrollments)
    {
        var unitIds = enrollments.Select(e => e.KnowledgeUnitId).ToArray();
        var reflections = _reflectionRepository.GetByUnitsWithQAndA(unitIds, enrollments[0].LearnerId);
        var meaningfulReflections = FindMeaningfulReflections(reflections, unitIds);

        var retVal = new List<UnitAchievementsDto>();
        foreach (var enrollment in enrollments)
        {
            var relatedReflections = meaningfulReflections[enrollment.KnowledgeUnitId];
            var unitAchievement = new UnitAchievementsDto
            {
                UnitId = enrollment.KnowledgeUnitId,
                IsSatisfied = enrollment.Status == EnrollmentStatus.Completed,
                MeaningfulReflections = relatedReflections,
                ContainsMeaningfulReflectionAnswer = relatedReflections.Count > 0
            };
            retVal.Add(unitAchievement);
        }
        return retVal;
    }

    private static Dictionary<int, List<MeaningfulReflectionDto>> FindMeaningfulReflections(
        List<Reflection> reflections, int[] unitIds)
    {
        var retVal = unitIds.ToDictionary(id => id, _ => new List<MeaningfulReflectionDto>());
        foreach (var reflection in reflections)
        {
            var openEndedQuestions = reflection.GetOpenEndedQuestions();
            foreach (var q in openEndedQuestions)
            {
                var answer = reflection.FindFirstMeaningfulAnswer(q);
                if (answer == null) continue;

                retVal[reflection.KnowledgeUnitId].Add(new MeaningfulReflectionDto
                {
                    ReflectionId = reflection.Id,
                    UnitId = reflection.KnowledgeUnitId,
                    Created = reflection.Submissions[0].Created,
                    Question = q.Text,
                    Answer = answer.Answer
                });
            }
        }

        return retVal;
    }

    private static int ToPercentage(int part, int total)
    {
        return (int) Math.Round(100.0 * part / total, 0);
    }
}