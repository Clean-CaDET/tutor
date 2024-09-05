using AutoMapper;
using Tutor.Courses.API.Dtos.Enrollments;
using Tutor.Courses.API.Dtos.Groups;
using Tutor.Courses.API.Dtos.Monitoring;
using Tutor.Courses.Core.Domain;
using Tutor.LearningTasks.API.Dtos.LearningTasks;

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
        CreateMap<LearningTaskDto, TaskHeaderDto>();
    }
}