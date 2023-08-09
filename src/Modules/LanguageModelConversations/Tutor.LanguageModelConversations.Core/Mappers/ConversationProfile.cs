using AutoMapper;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.Mappers;

public class ConversationProfile : Profile
{
    public ConversationProfile() 
    {
        CreateMap<LanguageModelMessage, MessageResponse>()
            .ForMember(dest => dest.NewMessage, opt => opt.MapFrom(src => src.Content));

        CreateMap<LanguageModelMessage, ConversationMessageDto>()
            .ForMember(dest => dest.Sender, opt => opt.MapFrom(src => src.SenderType));
        CreateMap<Conversation, ConversationDto>()
            .ForMember(dest => dest.Messages, opt => opt.MapFrom(src => src.Messages.Where(m => m.SenderType != SenderType.System)));
    }
}
