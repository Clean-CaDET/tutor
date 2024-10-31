using AutoMapper;
using FluentResults;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.API.Public.Monitoring;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.API.Internal;

namespace Tutor.Courses.Core.UseCases.Monitoring;

public class CourseMonitoringService : ICourseMonitoringService
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IInternalLearnerService _learnerService;
    private readonly IWeeklyFeedbackRepository _feedbackRepository;

    public CourseMonitoringService(IMapper mapper, ICourseRepository courseRepository, IGroupRepository groupRepository, 
        IInternalLearnerService learnerService, IWeeklyFeedbackRepository feedbackRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
        _groupRepository = groupRepository;
        _learnerService = learnerService;
        _feedbackRepository = feedbackRepository;
    }

    public Result<List<CourseDto>> GetActiveCourses()
    {
        var courses = _courseRepository.GetActiveAndStarted();
        return courses.Select(_mapper.Map<CourseDto>).ToList();
    }

    public Result<List<GroupDto>> GetGroupFeedback(int courseId)
    {
        var groups = _groupRepository.GetCourseGroups(courseId);
        var learnerDtos = GetLearners(groups);
        PopulateWeeklyFeedback(courseId, learnerDtos);
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

    private void PopulateWeeklyFeedback(int courseId, List<LearnerDto> learnerDtos)
    {
        var feedbackByLearner = _feedbackRepository.GetByCourse(courseId).GroupBy(f => f.LearnerId);
        foreach (var grouping in feedbackByLearner)
        {
            var relatedLearner = learnerDtos.Find(l => l.Id == grouping.Key);
            if (relatedLearner == null) continue;
            relatedLearner.WeeklyFeedback = grouping.Select(_mapper.Map<WeeklyFeedbackDto>).OrderBy(f => f.WeekEnd).ToList();
        }
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
}