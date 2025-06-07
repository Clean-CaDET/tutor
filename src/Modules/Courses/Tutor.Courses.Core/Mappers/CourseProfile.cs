using AutoMapper;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.Core.Domain;

namespace Tutor.Courses.Core.Mappers;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseDto, Course>().ReverseMap();
        CreateMap<KnowledgeUnitDto, KnowledgeUnit>().ReverseMap();

        CreateMap<UnitProgressRatingDto, UnitProgressRating>().ReverseMap();
        CreateMap<UnitFeedbackRequest, UnitFeedbackRequestDto>();
    }
}