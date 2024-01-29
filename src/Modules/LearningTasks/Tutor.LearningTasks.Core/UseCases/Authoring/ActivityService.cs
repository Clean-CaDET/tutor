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
    private readonly IAccessServices _accessServices;

    public ActivityService(IActivityRepository activityRepository, IAccessServices accessServices,
        ILearningTasksUnitOfWork unitOfWork, IMapper mapper) : base(activityRepository, unitOfWork, mapper)
    {
        _activityRepository = activityRepository;
        _accessServices = accessServices;
    }

    public Result<List<ActivityDto>> GetByCourse(int courseId)
    {
        List<Activity> activities = _activityRepository.GetCourseActivities(courseId);
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

        return Update(activity);
    }

    public Result Delete(int id, int courseId, int instructorId)
    {
        bool isSubactivity = GetByCourse(courseId).Value.Any(activity => 
        activity.Subactivities?.Any(subactivity => subactivity.ChildId == id) == true);
        if(isSubactivity)
            return Result.Fail(FailureCode.InvalidArgument);
        
        if (!_accessServices.IsCourseOwner(courseId, instructorId))
            return Result.Fail(FailureCode.Forbidden);

        return Delete(id);
    }
}
