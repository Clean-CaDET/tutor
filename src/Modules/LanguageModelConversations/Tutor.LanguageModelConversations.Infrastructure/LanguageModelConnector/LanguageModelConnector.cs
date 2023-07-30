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

    public async Task<Result<IEnumerable<LanguageModelMessage>>> ExtractKeywordsAsync(string text)
    {
        var request = new Request.LanguageModelDto()
        {
            Text = text
        };
        var response = await RequestHandler.PostAndReadAsync<Response.LanguageModelDto, Request.LanguageModelDto>(LanguageModelEndpoints.ExtractKeywords, request);
        // vratiti premapirano
        if (response.IsFailed)
            return Result.Fail(response.Errors);
        var nesto = _mapper.Map<IEnumerable<LanguageModelMessage>>(response.Value);
        return (Result<IEnumerable<LanguageModelMessage>>)nesto;
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
