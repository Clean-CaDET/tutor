using AutoMapper;
using Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel;
using Tutor.Web.Controllers.Domain.DTOs.Enrollment;

namespace Tutor.Web.Controllers.Domain;

public class EnrollmentProfile : Profile
{
    public EnrollmentProfile()
    {
        CreateMap<LearnerGroup, GroupDto>();
    }
}