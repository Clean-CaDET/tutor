using AutoMapper;
using FluentResults;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Dtos.Reports;
using Tutor.Courses.API.Public.Supervision;
using Tutor.Courses.Core.Domain;
using Tutor.Courses.Core.Domain.RepositoryInterfaces;
using Tutor.Stakeholders.API.Internal;

namespace Tutor.Courses.Core.UseCases.Supervision;

public class CourseReportingService : ICourseReportingService
{
    private readonly IMapper _mapper;
    private readonly ICourseRepository _courseRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IInternalLearnerService _learnerService;
    private readonly IReportRepository _reportRepository;

    public CourseReportingService(IMapper mapper, ICourseRepository courseRepository,
        IGroupRepository groupRepository, IInternalLearnerService learnerService, IReportRepository reportRepository)
    {
        _mapper = mapper;
        _courseRepository = courseRepository;
        _groupRepository = groupRepository;
        _learnerService = learnerService;
        _reportRepository = reportRepository;
    }

    public Result<List<CourseDto>> GetStartedCourses()
    {
        var courses = _courseRepository.GetStarted();
        return courses.Select(_mapper.Map<CourseDto>).ToList();
    }

    public Result<List<GroupDto>> GetGroupedLearnersWithReports(int courseId)
    {
        var groups = _groupRepository.GetCourseGroups(courseId);
        var learnerDtos = GetLearners(groups);
        PopulateReports(learnerDtos);
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

    private void PopulateReports(List<LearnerDto> learners)
    {
        var learnerIds = learners.Select(l => l.Id).ToArray();
        var reportsByLearner = _reportRepository.GetByLearners(learnerIds).GroupBy(f => f.LearnerId);
        foreach (var grouping in reportsByLearner)
        {
            var relatedLearner = learners.Find(l => l.Id == grouping.Key);
            if (relatedLearner == null) continue;
            relatedLearner.Reports = grouping
                .Select(_mapper.Map<CourseReportDto>)
                .OrderByDescending(f => f.CourseId).ToList();
        }
    }

    private List<GroupDto> CreateGroupDtos(List<LearnerGroup> groups, List<LearnerDto> learners)
    {
        var groupDtos = new List<GroupDto>();
        foreach (var group in groups)
        {
            var groupDto = _mapper.Map<GroupDto>(group);
            groupDto.Learners = learners.Where(l => group.LearnerIds.Contains(l.Id)).ToList();
            groupDtos.Add(groupDto);
        }

        return groupDtos;
    }
}