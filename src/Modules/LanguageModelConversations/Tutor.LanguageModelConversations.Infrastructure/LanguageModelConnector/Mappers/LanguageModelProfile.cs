using AutoMapper;
using Tutor.LanguageModelConversations.Core.Domain;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector.Mappers;

public class LanguageModelProfile : Profile
{
    public LanguageModelProfile()
    {
        CreateMap<Response.LanguageModelDto, IEnumerable<LanguageModelMessage>>()
            .ConvertUsing<LanguageModelMessageConverter>();
    }
}
