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
            .ForMember(dest => dest.ActiveSessionInMinutes, opt => opt.MapFrom(src =>
                src.SessionTracker.DurationOfAllSessions.TotalMinutes - src.SessionTracker.DurationOfAllPauses.TotalMinutes));
        CreateMap<UnitEnrollment, UnitEnrollmentDto>()
            .ForMember(dest => dest.Status, 
                opt => opt.MapFrom(
                    src => Enum.GetName(src.Status)));
    }
}