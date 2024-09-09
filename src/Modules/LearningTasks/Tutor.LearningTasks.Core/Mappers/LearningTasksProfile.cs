using AutoMapper;
using Tutor.LearningTasks.API.Dtos.Tasks;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Core.Mappers;

public class LearningTasksProfile : Profile
{
    public LearningTasksProfile()
    {
        CreateMap<ActivityDto, Activity>()
            .AfterMap((src, dest) => dest.CalculateMaxPoints()).ReverseMap();
        CreateMap<ExampleDto, Example>().ReverseMap();
        CreateMap<SubmissionFormatDto, SubmissionFormat>().ReverseMap();
        CreateMap<StandardDto, Standard>().ReverseMap();
        CreateMap<LearningTaskDto, LearningTask>()
            .AfterMap((src, dest) => dest.CalculateMaxPoints()).ReverseMap();
    }
}
