using AutoMapper;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Core.Mappers;

public class ConversationProfile : Profile
{
    public ConversationProfile() 
    {
        CreateMap<ConversationDto, Conversation>();
        CreateMap<Conversation, ConversationDto>();

        CreateMap<MessageRequest, ConversationMessageDto>()
            .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message));
        //CreateMap<MessageResponse, ConversationMessageDto>()
        //    .ForMember(dest => dest.Message, opt => opt.MapFrom(src => ConversationMapping(src)));
    }

    //private static string ConversationMapping(MessageResponse source)
    //{
    //    if (source.QuestionAnswers != null)
    //    {
    //        return JsonSerializer.Serialize(source.QuestionAnswers);
    //    }
    //    if (source.Keywords != null)
    //    {
    //        return JsonSerializer.Serialize(source.Keywords);
    //    }
    //    return source.NewMessage;
    //}
}
