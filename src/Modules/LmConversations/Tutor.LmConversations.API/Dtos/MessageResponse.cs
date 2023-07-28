using Tutor.LmConversations.API.Dtos.Integration.Response;

namespace Tutor.LmConversations.API.Dtos;

public class MessageResponse
{
    // TODO: da li sve prebaciti da su serijalizovani string -> onda ovo prebaciti u Content
    public string NewMessage { get; set; }
    public List<LmKeywordDto>? Keywords { get; set; }
    public List<LmQaDto>? QuestionAnswers { get; set; }
}
