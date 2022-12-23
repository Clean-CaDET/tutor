using System.Linq;
using AutoMapper;
using Tutor.Core.Domain.CourseIteration;
using Tutor.Core.Domain.KnowledgeMastery;
using Tutor.Core.Domain.Stakeholders;

namespace Tutor.Web.Mappings.CourseIteration;

public class GroupProfile : Profile
{
    public GroupProfile()
    {
        CreateMap<LearnerGroup, GroupDto>();
        CreateMap<GroupDto, LearnerGroup>();

        CreateMap<Learner, LearnerProgressDto>()
            .ForMember(dest => dest.Learner, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.KnowledgeComponentProgress,
                opt => opt.MapFrom(src => src.KnowledgeComponentMasteries));

        CreateMap<KnowledgeComponentMastery, KcmProgressDto>()
            .ForMember(dest => dest.DurationOfFinishedSessionsInMinutes, opt => opt.MapFrom(src =>
                (src.SessionTracker.DurationOfFinishedSessions.Hours * 60) +
                src.SessionTracker.DurationOfFinishedSessions.Minutes));
    }
}