using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.API.Dtos.Integration.Response;
using Tutor.LanguageModelConversations.API.Interfaces;
using Tutor.LanguageModelConversations.Infrastructure.Database;

namespace Tutor.LanguageModelConversations.Tests.Integration;

public class LmConversationTests : BaseLanguageModelConversationsIntegrationTest
{
    public LmConversationTests(LanguageModelConversationsTestFactory factory) : base(factory) { }

    [Fact]
    public void Retrieves_conversation()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-1");

        var result = ((OkObjectResult)controller.Get(-1).Result)?.Value as ConversationDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.LearnerId.ShouldBe(-1);
        result.ContextId.ShouldBe(-1);
        result.Messages.ShouldNotBeNull();
        result.Messages.Count.ShouldBe(2);
        result.Messages[0].Sender.ShouldBe(SenderType.Learner);
        result.Messages[0].Message.ShouldBe("Korisnicka poruka");
        result.Messages[1].Sender.ShouldBe(SenderType.Lm);
        result.Messages[1].Message.ShouldBe("Odgovor");
    }

    [Fact]
    public void Does_not_retrieves_conversation_invalid_context_id()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-1");

        var result = (ObjectResult)controller.Get(1).Result;

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(404);
    }

    [Theory]
    [MemberData(nameof(NewConversationMessages))]
    public async void Saves_new_conversation(string learnerId, MessageRequest messageRequest, MessageResponse expectedResponse)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, learnerId);
        var dbContext = scope.ServiceProvider.GetRequiredService<LanguageModelConversationsContext>();
        dbContext.Database.BeginTransaction();

        var response = await controller.SendMessage(messageRequest);
        var result = ((OkObjectResult)response.Result)?.Value as MessageResponse;

        dbContext.ChangeTracker.Clear();

        result.ShouldNotBeNull();
        result.NewMessage.ShouldNotBeNull();
        if (expectedResponse.QuestionAnswers != null)
        {
            result.QuestionAnswers.ShouldNotBeNull();
            result.QuestionAnswers.Count.ShouldBe(expectedResponse.QuestionAnswers.Count);
        }
        if (expectedResponse.Keywords != null)
        {
            result.Keywords.ShouldNotBeNull();
            result.Keywords.Count.ShouldBe(expectedResponse.Keywords.Count);
        }
        var storedConversation = dbContext.Conversations.SingleOrDefault(c => c.Id == messageRequest.ConversationId);
        storedConversation.ShouldNotBeNull();
        storedConversation.LearnerId.ShouldBe(int.Parse(learnerId));
        storedConversation.ContextId.ShouldBe(messageRequest.ContextId);
        storedConversation.LmMessages.ShouldNotBeNull();
        storedConversation.LmMessages.Count.ShouldBe(3);
    }

    [Theory]
    [MemberData(nameof(UpdateConversationMessages))]
    public async void Updates_existing_conversation(string learnerId, MessageRequest messageRequest, MessageResponse expectedResponse)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, learnerId);
        var dbContext = scope.ServiceProvider.GetRequiredService<LanguageModelConversationsContext>();
        var storedConversation = dbContext.Conversations.SingleOrDefault(c => c.Id == messageRequest.ConversationId);
        storedConversation.ShouldNotBeNull();
        var contentCount = storedConversation.LmMessages.Count;
        dbContext.Database.BeginTransaction();

        var response = await controller.SendMessage(messageRequest);
        var result = ((OkObjectResult)response.Result)?.Value as MessageResponse;

        dbContext.ChangeTracker.Clear();

        result.ShouldNotBeNull();
        result.NewMessage.ShouldNotBeNull();
        if (expectedResponse.QuestionAnswers != null)
        {
            result.QuestionAnswers.ShouldNotBeNull();
            result.QuestionAnswers.Count.ShouldBe(expectedResponse.QuestionAnswers.Count);
        }
        if (expectedResponse.Keywords != null)
        {
            result.Keywords.ShouldNotBeNull();
            result.Keywords.Count.ShouldBe(expectedResponse.Keywords.Count);
        }
        var updatedConversation = dbContext.Conversations.SingleOrDefault(c => c.Id == messageRequest.ConversationId);
        updatedConversation.ShouldNotBeNull();
        updatedConversation.LearnerId.ShouldBe(int.Parse(learnerId));
        updatedConversation.ContextId.ShouldBe(messageRequest.ContextId);
        updatedConversation.LmMessages.ShouldNotBeNull();
        updatedConversation.LmMessages.Count.ShouldBe(contentCount + 3);

    }

    private static LanguageModelConversationsController CreateController(IServiceScope scope, string id)
    {
        return new LanguageModelConversationsController(scope.ServiceProvider.GetRequiredService<IConversationService>())
        {
            ControllerContext = BuildContext(id, "learner")
        };
    }

    public static IEnumerable<object[]> NewConversationMessages() => new List<object[]>
    {
        new object[]
        {
            "1",
            new MessageRequest { ConversationId = 1, ContextId = 1, Type = MessageType.LectureQuestions },
            new MessageResponse
            { QuestionAnswers = new List<LmQaDto>
                { new LmQaDto { Question = "q", Answer = "a" }, new LmQaDto { Question = "q", Answer = "a" }, new LmQaDto { Question = "q", Answer = "a" } }
            }
        },
        new object[]
        {
            "1",
            new MessageRequest { ConversationId = 1, ContextId = 1, Type = MessageType.Keywords },
            new MessageResponse
            { Keywords = new List<LmKeywordDto>
                { new LmKeywordDto { Keyword = "k", Explanation = "e" }, new LmKeywordDto { Keyword = "k", Explanation = "e" } , new LmKeywordDto { Keyword = "k", Explanation = "e" } }
            }
        },
        new object[]
        {
            "1",
            new MessageRequest { ConversationId = 1, ContextId = 1, Type = MessageType.Summarize },
            new MessageResponse {}
        },
        new object[]
        {
            "1",
            new MessageRequest { ConversationId = 1, ContextId = 1, Type = MessageType.SimilarTask },
            new MessageResponse {}
        },
        new object[]
        {
            "1",
            new MessageRequest { ConversationId = 1, ContextId = 1, Type = MessageType.SimilarTask, TaskId = 1 },
            new MessageResponse {}
        },
        new object[]
        {
            "1",
            new MessageRequest { ConversationId = 1, ContextId = 1, Type = MessageType.OpenEnded, Message = "new message" },
            new MessageResponse {}
        },
        new object[]
        {
            "1",
            new MessageRequest { ConversationId = 1, ContextId = 1, Type = MessageType.OpenEnded, TaskId = 1, Message = "new message" },
            new MessageResponse {}
        }
    };

    public static IEnumerable<object[]> UpdateConversationMessages() => new List<object[]>
    {
        new object[]
        {
            "-1",
            new MessageRequest { ConversationId = -1, ContextId = -1, Type = MessageType.LectureQuestions },
            new MessageResponse
            { QuestionAnswers = new List<LmQaDto>
                { new LmQaDto { Question = "q", Answer = "a" }, new LmQaDto { Question = "q", Answer = "a" }, new LmQaDto { Question = "q", Answer = "a" } }
            }
        },
        new object[]
        {
            "-1",
            new MessageRequest { ConversationId = -1, ContextId = -1, Type = MessageType.Keywords },
            new MessageResponse
            { Keywords = new List<LmKeywordDto>
                { new LmKeywordDto { Keyword = "k", Explanation = "e" }, new LmKeywordDto { Keyword = "k", Explanation = "e" } , new LmKeywordDto { Keyword = "k", Explanation = "e" } }
            }
        },
        new object[]
        {
            "-1",
            new MessageRequest { ConversationId = -1, ContextId = -1, Type = MessageType.Summarize },
            new MessageResponse {}
        },
        new object[]
        {
            "-1",
            new MessageRequest { ConversationId = -1, ContextId = -1, Type = MessageType.SimilarTask },
            new MessageResponse {}
        },
        new object[]
        {
            "-1",
            new MessageRequest { ConversationId = -1, ContextId = -1, Type = MessageType.SimilarTask, TaskId = 1 },
            new MessageResponse {}
        },
        new object[]
        {
            "-1",
            new MessageRequest { ConversationId = -1, ContextId = -1, Type = MessageType.OpenEnded, Message = "new message" },
            new MessageResponse {}
        },
        new object[]
        {
            "-1",
            new MessageRequest { ConversationId = -1, ContextId = -1, Type = MessageType.OpenEnded, TaskId = 1, Message = "new message" },
            new MessageResponse {}
        }
    };
}