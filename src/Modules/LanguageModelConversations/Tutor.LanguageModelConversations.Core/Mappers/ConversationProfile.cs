using AutoMapper;
using System.Text.Json;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.API.Dtos.Integration.Response;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.Mappers;

public class ConversationProfile : Profile
{
    public ConversationProfile() 
    {
        CreateMap<ConversationDto, Conversation>();
        CreateMap<Conversation, ConversationDto>();

        // TODO: mozda i ovo serijalizovati u string cist i onda front da deserijalizuje
            // proveriti
        CreateMap<LmResponse, MessageResponse>()
            .ForMember(dest => dest.NewMessage, opt => opt.MapFrom(src => src.Messages.Last().Data.Content));
        CreateMap<LmKeywordResponse, MessageResponse>()
            .ForMember(dest => dest.NewMessage, opt => opt.MapFrom(src => src.Messages.Last().Data.Content))
            .ForMember(dest => dest.Keywords, opt => opt.MapFrom(src => src.Keywords));
        CreateMap<LmQaResponse, MessageResponse>()
            .ForMember(dest => dest.NewMessage, opt => opt.MapFrom(src => src.Messages.Last().Data.Content))
            .ForMember(dest => dest.QuestionAnswers, opt => opt.MapFrom(src => src.QuestionAnswers));

        CreateMap<MessageRequest, ConversationMessageDto>()
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
        CreateMap<MessageResponse, ConversationMessageDto>()
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => ConversationMapping(src)));
    }

    private static string ConversationMapping(MessageResponse source)
    {
        if (source.QuestionAnswers != null)
        {
            return JsonSerializer.Serialize(source.QuestionAnswers);
        }
        if (source.Keywords != null)
        {
            return JsonSerializer.Serialize(source.Keywords);
        }
        return source.NewMessage;
    }
}
