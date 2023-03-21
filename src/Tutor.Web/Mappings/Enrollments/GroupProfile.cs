using AutoMapper;
using System;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeMastery;

namespace Tutor.Web.Mappings.Enrollments;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<LearnerGroup, GroupDto>();
        CreateMap<GroupDto, LearnerGroup>();

        CreateMap<KnowledgeComponentMastery, KcmProgressDto>()
            .ForMember(dest => dest.DurationOfAllSessionsInMinutes, opt => opt.MapFrom(src =>
                (src.SessionTracker.DurationOfAllSessions.Hours * 60) +
                src.SessionTracker.DurationOfAllSessions.Minutes))
            .ForMember(dest => dest.DurationOfAllPausesInMinutes, opt => opt.MapFrom(src =>
                (src.SessionTracker.DurationOfAllPauses.Hours * 60) +
                src.SessionTracker.DurationOfAllPauses.Minutes));

        CreateMap<UnitEnrollment, UnitEnrollmentDto>()
            .ForMember(dest => dest.Status, 
                opt => opt.MapFrom(
                    src => Enum.GetName(src.Status)));
    }
}