using AutoMapper;
using Tutor.Core.DomainModel.KnowledgeComponents;
using Tutor.Core.LearnerModel.DomainOverlay.EnrollmentModel;
using Tutor.Web.Controllers.Domain.DTOs.Enrollment;

namespace Tutor.Web.Controllers.Domain;

public class EnrollmentProfile : Profile
{
    public EnrollmentProfile()
    {
        CreateMap<Course, CourseDto>();
        CreateMap<LearnerGroup, GroupDto>();
    }
}