using AutoMapper;
using Tutor.Core.EnrollmentModel;

namespace Tutor.Web.Mappings.Enrollments;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<LearnerGroup, GroupDto>();
    }
}