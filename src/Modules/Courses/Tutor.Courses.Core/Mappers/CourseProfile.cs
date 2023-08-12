using AutoMapper;
using Tutor.Courses.API.Dtos;
using Tutor.Courses.Core.Domain;

namespace Tutor.Courses.Core.Mappers;

public class CourseProfile : Profile
{
    public CourseProfile()
    {
        CreateMap<CourseDto, Course>();
        CreateMap<Course, CourseDto>();
        CreateMap<KnowledgeUnit, KnowledgeUnitDto>();
        CreateMap<KnowledgeUnitDto, KnowledgeUnit>();
    }
}