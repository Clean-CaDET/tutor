using AutoMapper;
using Tutor.LearningTasks.API.Dtos.TaskProgress;
using Tutor.LearningTasks.Core.Domain.LearningTaskProgress;

namespace Tutor.LearningTasks.Core.Mappers;

public class TaskProgressProfile : Profile
{
    public TaskProgressProfile()
    {
        CreateMap<TaskProgressDto, TaskProgress>().ReverseMap();
        CreateMap<StepProgressDto, StepProgress>().ReverseMap();
        CreateMap<StandardEvaluationDto, StandardEvaluation>().ReverseMap();
    }
}
