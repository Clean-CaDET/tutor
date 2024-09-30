using AutoMapper;
using Tutor.Courses.API.Dtos.Enrollments;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.Core.Domain;
using Tutor.KnowledgeComponents.API.Dtos.Knowledge;
using Tutor.KnowledgeComponents.API.Dtos.KnowledgeAnalytics;
using Tutor.LearningTasks.API.Dtos.TaskAnalytics;
using Tutor.LearningTasks.API.Dtos.Tasks;

namespace Tutor.Courses.Core.Mappers;

public class MonitoringProfile : Profile
{
    public MonitoringProfile()
    {
        CreateMap<LearnerGroup, GroupDto>();
        CreateMap<GroupDto, LearnerGroup>();

        CreateMap<UnitEnrollment, EnrollmentDto>()
            .ForMember(dest => dest.Status,
                opt => opt.MapFrom(
                    src => Enum.GetName(src.Status)))
            .ForMember(dest => dest.AvailableFrom, 
                opt => opt.MapFrom(
                    src => src.Start));

        CreateMap<KnowledgeUnit, UnitHeaderDto>();
        CreateMap<KnowledgeComponentDto, KcHeaderDto>();
        CreateMap<LearningTaskDto, TaskHeaderDto>();
        
        CreateMap<InternalKcUnitSummaryStatisticsDto, PublicKcUnitSummaryStatisticsDto>();
        CreateMap<InternalKcProgressStatisticsDto, PublicKcProgressStatisticsDto>();
        
        CreateMap<InternalTaskUnitSummaryStatisticsDto, PublicTaskUnitSummaryStatisticsDto>();
        CreateMap<InternalTaskProgressStatisticsDto, PublicTaskProgressStatisticsDto>();

        CreateMap<WeeklyFeedback, WeeklyFeedbackDto>().ReverseMap();
    }
}