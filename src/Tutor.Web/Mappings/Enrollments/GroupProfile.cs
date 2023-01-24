using AutoMapper;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.Stakeholders;

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
                src.SessionTracker.DurationOfAllSessions.Minutes));
    }
}