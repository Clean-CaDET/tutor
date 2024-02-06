using AutoMapper;
using Tutor.LearningTasks.API.Dtos.Activities;
using Tutor.LearningTasks.Core.Domain.Activities;

namespace Tutor.LearningTasks.Core.Mappers;

public class ActivitiesProfile : Profile
{
    public ActivitiesProfile()
    {
        CreateMap<ActivityDto, Activity>().ReverseMap();
        CreateMap<GuidanceDto, Guidance>().ReverseMap();
        CreateMap<ExampleDto, Example>().ReverseMap();
        CreateMap<ActivityStandardDto, ActivityStandard>().ReverseMap();
        CreateMap<SubactivityDto, Subactivity>().ReverseMap();
    }
}