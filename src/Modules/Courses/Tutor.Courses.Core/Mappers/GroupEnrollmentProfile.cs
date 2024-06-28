using AutoMapper;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.Core.Domain;

namespace Tutor.Courses.Core.Mappers;

public class GroupEnrollmentProfile : Profile
{
    public GroupEnrollmentProfile()
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
    }
}