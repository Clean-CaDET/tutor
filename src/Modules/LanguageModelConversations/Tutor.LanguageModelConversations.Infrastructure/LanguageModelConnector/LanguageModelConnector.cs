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

    public async Task<Result<ConversationSegment>> TopicConversationAsync(string message, string text, ContextType context, List<LanguageModelMessage>? previousMessages)
    {
        var request = new Request.LanguageModelDto()
        {
            Message = message,
            Text = text,
            Context = context,
            PreviousMessages = _mapper.Map<List<Response.LanguageModelMessageDto>>(previousMessages)
        };
        return await ProcessLanguageModelRequestAsync(request, MessageType.TopicConversation);
    }

    public async Task<Result<ConversationSegment>> GenerateSimilarAsync(string text, ContextType context)
    {
        var request = new Request.LanguageModelDto()
        {
            Text = text,
            Context = context,
        };
        return await ProcessLanguageModelRequestAsync(request, MessageType.GenerateSimilar);
    }

    public async Task<Result<ConversationSegment>> SummarizeAsync(string text)
    {
        var request = new Request.LanguageModelDto()
        {
            Text = text,
        };
        return await ProcessLanguageModelRequestAsync(request, MessageType.Summarize);
    }

    public async Task<Result<ConversationSegment>> ExtractKeywordsAsync(string text)
    {
        var request = new Request.LanguageModelDto()
        {
            Text = text,
        };
        return await ProcessLanguageModelRequestAsync(request, MessageType.ExtractKeywords);
    }

    public async Task<Result<ConversationSegment>> GenerateQuestionsAsync(string text)
    {
        var request = new Request.LanguageModelDto()
        {
            Text = text,
        };
        return await ProcessLanguageModelRequestAsync(request, MessageType.GenerateQuestions);
    }

    private async Task<Result<ConversationSegment>> ProcessLanguageModelRequestAsync(Request.LanguageModelDto request, MessageType type)
    {
        var response = await RequestHandler.PostAndReadAsync<Response.LanguageModelDto, Request.LanguageModelDto>(LanguageModelConsts.Endpoints[type], request);
        if (response.IsFailed)
            return Result.Fail(response.Errors);

        var newMessages = response.Value.Messages.TakeLast(3);
        var messages = _mapper.Map<List<LanguageModelMessage>>(newMessages);
        messages.ForEach(message => message.MessageType = type);

        var tokensUsed = response.Value.TokensUsed;
        return new ConversationSegment(messages, tokensUsed);
    }
}
