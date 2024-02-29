using AutoMapper;
using Tutor.LearningTasks.API.Dtos.LearningTasks;
using Tutor.LearningTasks.Core.Domain.LearningTasks;

namespace Tutor.LearningTasks.Core.Mappers;

public class LearningTasksProfile : Profile
{
    public LearningTasksProfile() 
    {
        CreateMap<LearningTaskDto, LearningTask>()
            .AfterMap((src, dest) => dest.CalculateMaxPoints()).ReverseMap();
        CreateMap<StepDto, Step>()
            .AfterMap((src, dest) => dest.CalculateMaxPoints()).ReverseMap();
        CreateMap<StandardDto, Standard>().ReverseMap();
        CreateMap<SubmissionFormatDto, SubmissionFormat>().ReverseMap();
    }
}