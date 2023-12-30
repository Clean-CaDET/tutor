using AutoMapper;
using Tutor.LearningTasks.API.Dtos.Activities;
using Tutor.LearningTasks.Core.Domain.Activites;

namespace Tutor.LearningTasks.Core.Mappers;

public class ActivitiesProfile : Profile
{
    public ActivitiesProfile()
    {
        CreateMap<ActivityDto, Activity>();
        CreateMap<Activity, ActivityDto>();
        CreateMap<GuidanceDto, Guidance>();
        CreateMap<Guidance, GuidanceDto>();
        CreateMap<ExampleDto, Example>();
        CreateMap<Example, ExampleDto>();
        CreateMap<SubactivityDto, Subactivity>();
        CreateMap<Subactivity, SubactivityDto>();
    }

}
