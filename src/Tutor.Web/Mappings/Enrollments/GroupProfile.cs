using AutoMapper;
using Tutor.Core.Domain.CourseIteration;

namespace Tutor.Web.Mappings.Enrollments;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<LearnerGroup, GroupDto>();
    }
}