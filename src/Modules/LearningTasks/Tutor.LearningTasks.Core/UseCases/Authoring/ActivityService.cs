using AutoMapper;
using FluentResults;
using Tutor.BuildingBlocks.Core.UseCases;
using Tutor.LearningTasks.API.Dtos.Activities;
using Tutor.LearningTasks.API.Public;
using Tutor.LearningTasks.API.Public.Authoring;
using Tutor.LearningTasks.Core.Domain.Activities;
using Tutor.LearningTasks.Core.Domain.RepositoryInterfaces;

namespace Tutor.LearningTasks.Core.UseCases.Authoring;

public class ActivityService : CrudService<ActivityDto, Activity>, IActivityService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IExampleRepository _exampleRepository;
    private readonly IAccessServices _accessServices;

    public ActivityService(IActivityRepository activityRepository, IExampleRepository exampleRepository, IAccessServices accessServices,
        ILearningTasksUnitOfWork unitOfWork, IMapper mapper) : base(activityRepository, unitOfWork, mapper)
    {
        _activityRepository = activityRepository;
        _exampleRepository = exampleRepository;
        _accessServices = accessServices;
    }

    public Result<ActivityDto> GetWithExamples(int id)
    {
        return MapToDto(_activityRepository.GetWithExamples(id));
    }

    public Result<List<ActivityDto>> GetWithExamplesByCourse(int courseId)
    {
        List<Activity> activities = _activityRepository.GetCourseActivitiesWithExamples(courseId);
        return MapToDto(activities);
    }

    public Result<ActivityDto> Create(ActivityDto activity, int instructorId)
    {
        if (!_accessServices.IsCourseOwner(activity.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        if (activity.Subactivities?.Any(subactivity => Get(subactivity.ChildId).IsFailed) == true)
            return Result.Fail(FailureCode.NotFound);

        return Create(activity);
    }

    public Result<ActivityDto> Update(ActivityDto activity, int instructorId)
    {
        if (!_accessServices.IsCourseOwner(activity.CourseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        if (activity.Subactivities?.Any(subactivity => Get(subactivity.ChildId).IsFailed) == true)
            return Result.Fail(FailureCode.NotFound);
        
        DeleteOldExamples(activity.Id);

        return Update(activity);
    }

    private void DeleteOldExamples(int activityId)
    {
        List<Example> examples = _exampleRepository.GetActivityExamples(activityId);
        examples.ForEach(_exampleRepository.Delete);
    }

    public Result Delete(int id, int courseId, int instructorId)
    {
        bool isSubactivity = GetWithExamplesByCourse(courseId).Value.Any(activity => 
        activity.Subactivities?.Any(subactivity => subactivity.ChildId == id) == true);
        if(isSubactivity)
            return Result.Fail(FailureCode.InvalidArgument);
        
        if (!_accessServices.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Delete(id);
    }
}
