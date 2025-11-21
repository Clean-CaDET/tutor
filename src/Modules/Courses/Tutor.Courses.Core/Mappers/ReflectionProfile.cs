using AutoMapper;
using Tutor.Courses.API.Dtos.Reflections;
using Tutor.Courses.Core.Domain.Reflections;

namespace Tutor.Courses.Core.Mappers;

public class ReflectionProfile : Profile
{
    public ReflectionProfile()
    {
        CreateMap<ReflectionDto, Reflection>()
            .ForMember(dest => dest.KnowledgeUnitId, opt => opt.MapFrom(src => src.UnitId))
            .ReverseMap()
            .ForMember(dest => dest.UnitId, opt => opt.MapFrom(src => src.KnowledgeUnitId));
        CreateMap<ReflectionQuestionDto, ReflectionQuestion>().ReverseMap();
        CreateMap<ReflectionAnswerDto, ReflectionAnswer>().ReverseMap();
        CreateMap<ReflectionQuestionAnswerDto, ReflectionQuestionAnswer>().ReverseMap();
    }
}