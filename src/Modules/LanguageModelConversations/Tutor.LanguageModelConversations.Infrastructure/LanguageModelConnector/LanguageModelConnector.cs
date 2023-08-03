using AutoMapper;
using FluentResults;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.Core.Domain;
using Tutor.LanguageModelConversations.Core.UseCases;

namespace Tutor.LanguageModelConversations.Infrastructure.LanguageModelConnector;

public class LanguageModelConnector : ILanguageModelConnector
{

    private readonly IMapper _mapper;

    public LanguageModelConnector(IMapper mapper)
    {
        _mapper = mapper;
    }
    // TODO: razmotriti uvodjenje jos jedne metode koja ce raditi odabir dobre metode i mapiranje povratne vrednosti
    // Pros: manje dupliranja koda, delegacija odabira poziva iz servisa u konektor
    // Cons: nece biti pobrojane konkretne metode u interfejsu
    public async Task<Result<LanguageModelMessage>> TopicConversationAsync(string message, string text, ContextType context, List<LanguageModelMessage>? previousMessages)
    {
        var request = new Request.LanguageModelDto()
        {
            Message = message,
            Text = text,
            Context = context,
            // mora maper ovde da se nekako pozove
            // kako ja da pristupim maperu koji se injektuje u servis?
            // ovo nije servis
            // ali je klasa, tako da moze biti injektovana
            // TODO: srediti mapiranje i prosledjivati prethodne poruke
            //PreviousMessages = previousMessages
        };
        var response = await RequestHandler.PostAndReadAsync<Response.LanguageModelDto, Request.LanguageModelDto>(LanguageModelEndpoints.TopicConversation, request);
        // vratiti premapirano
        return null;
    }

    public async Task<Result<LanguageModelMessage>> GenerateSimilarAsync(string text, ContextType context)
    {
        var request = new Request.LanguageModelDto()
        {
            Text = text,
            Context = context
        };
        var response = await RequestHandler.PostAndReadAsync<Response.LanguageModelDto, Request.LanguageModelDto>(LanguageModelEndpoints.GenerateSimilar, request);
        // vratiti premapirano
        return null;
    }

    public async Task<Result<LanguageModelMessage>> SummarizeAsync(string text)
    {
        var request = new Request.LanguageModelDto()
        {
            Text = text
        };
        var response = await RequestHandler.PostAndReadAsync<Response.LanguageModelDto, Request.LanguageModelDto>(LanguageModelEndpoints.Summarize, request);
        // vratiti premapirano
        return null;
    }

    public async Task<Result<List<LanguageModelMessage>>> ExtractKeywordsAsync(string text)
    {
        var request = new Request.LanguageModelDto()
        {
            Text = text
        };
        var response = await RequestHandler.PostAndReadAsync<Response.LanguageModelDto, Request.LanguageModelDto>(LanguageModelEndpoints.ExtractKeywords, request);
        if (response.IsFailed)
            return Result.Fail(response.Errors);

        var messages = _mapper.Map<List<LanguageModelMessage>>(response.Value);
        messages.ForEach(message => message.MessageType = Core.Domain.MessageType.Predefined);
        // totalno nepovezana vrednost sa domenskim modelom jedne poruke, vezana za ceo deo konverzacije
        // ja bih vracala tuple ponovo ovde
        // ili bih isla na out parametar za broj tokena, mozda je cistije
        var tokensUsed = response.Value.TokensUsed;
        return messages;
    }

    public async Task<Result<LanguageModelMessage>> GenerateQuestionsAsync(string text)
    {
        var request = new Request.LanguageModelDto()
        {
            Text = text
        };
        var response = await RequestHandler.PostAndReadAsync<Response.LanguageModelDto, Request.LanguageModelDto>(LanguageModelEndpoints.GenerateQuestions, request);
        // vratiti premapirano
        return null;
    }
}
