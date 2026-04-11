using AutoMapper;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.Mappers;

public class ConversationProfile : Profile
{
    public ConversationProfile()
    {
        CreateMap<ConversationAttemptDto, ConversationAttempt>().ReverseMap()
            .ForMember(d => d.Status, opt => opt.MapFrom(s => s.Status.ToString()));
        CreateMap<ConversationTurnDto, ConversationTurn>().ReverseMap()
            .ForMember(d => d.Role, opt => opt.MapFrom(s => s.Role.ToString()));
    }
}
