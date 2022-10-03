using AutoMapper;
using Tutor.Core.EnrollmentModel;

namespace Tutor.Web.Controllers.Instructors;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<LearnerGroup, GroupDto>();
    }
}