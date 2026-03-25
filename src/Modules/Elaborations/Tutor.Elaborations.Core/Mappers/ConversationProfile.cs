using AutoMapper;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.Core.Domain.Conversations;
using Tutor.Elaborations.Core.Domain.ElaborationTasks;

namespace Tutor.Elaborations.Core.Mappers;

public class ConversationProfile : Profile
{
    public ConversationProfile()
    {
        CreateMap<ElaborationTaskDto, ElaborationTask>().ReverseMap()
            .ForMember(d => d.ExpectedLevel, opt => opt.MapFrom(s => s.ExpectedLevel.ToString()));
        CreateMap<ConversationAttemptDto, ConversationAttempt>().ReverseMap()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));
        CreateMap<ConversationTurnDto, ConversationTurn>().ReverseMap()
            .ForMember(d => d.Role, opt => opt.MapFrom(s => s.Role.ToString()));
    }
}
