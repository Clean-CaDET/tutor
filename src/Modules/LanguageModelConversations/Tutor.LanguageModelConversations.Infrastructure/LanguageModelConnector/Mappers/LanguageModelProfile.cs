using AutoMapper;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Mappers;

public class LanguageModelProfile : Profile
{
    public LanguageModelProfile()
    {
        CreateMap<Response.LanguageModelMessageDto, LanguageModelMessage>()
            .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Data.Content))
            .ForMember(dest => dest.SenderType, opt => opt.MapFrom(src => (SenderType)src.Type));
        CreateMap<LanguageModelMessage, Response.LanguageModelMessageDto>()
            .ForPath(dest => dest.Data.Content, opt => opt.MapFrom(src => src.Content))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => (Response.LanguageModelSenderType)src.SenderType));
    }
}
