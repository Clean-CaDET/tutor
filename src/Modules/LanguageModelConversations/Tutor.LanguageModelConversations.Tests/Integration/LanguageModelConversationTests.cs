using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.API.Controllers.Learner;
using Tutor.LanguageModelConversations.API.Dtos;
using Tutor.LanguageModelConversations.API.Interfaces;
using Tutor.LanguageModelConversations.Core.Domain;
using Tutor.LanguageModelConversations.Infrastructure.Database;

namespace Tutor.LanguageModelConversations.Tests.Integration;

[Collection("Sequential")]
public class LanguageModelConversationTests : BaseLanguageModelConversationsIntegrationTest
{
    public LanguageModelConversationTests(LanguageModelConversationsTestFactory factory) : base(factory) { }

    [Fact]
    public void Retrieves_conversation()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var result = ((OkObjectResult)controller.GetByContext(0, -11).Result)?.Value as ConversationDto;

        result.ShouldNotBeNull();
        result.Id.ShouldBe(-1);
        result.LearnerId.ShouldBe(-2);
        result.ContextId.ShouldBe(-11);
        result.Messages.ShouldNotBeNull();
        result.Messages.Count.ShouldBe(2);
        result.Messages[0].Sender.ShouldBe(SenderType.Learner.ToString());
        result.Messages[0].Content.ShouldBe("Korisnicka poruka");
        result.Messages[1].Sender.ShouldBe(SenderType.LanguageModel.ToString());
        result.Messages[1].Content.ShouldBe("Odgovor");
    }

    [Fact]
    public void Does_not_retrieves_conversation_invalid_context_id()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");

        var result = (ObjectResult)controller.GetByContext(0, 1).Result;

        result.ShouldNotBeNull();
        result.StatusCode.ShouldBe(404);
    }

    [Theory]
    [MemberData(nameof(NewConversationMessages))]
    public async void Saves_new_conversation(MessageRequest messageRequest)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<LanguageModelConversationsContext>();
        dbContext.Database.BeginTransaction();

        var response = await controller.SendMessage(messageRequest);
        var result = ((OkObjectResult)response.Result)?.Value as MessageResponse;

        dbContext.ChangeTracker.Clear();

        result.ShouldNotBeNull();
        result.NewMessage.ShouldNotBeNull();
        var storedConversation = dbContext.Conversations.SingleOrDefault(c => c.Id == messageRequest.ConversationId);
        storedConversation.ShouldNotBeNull();
        storedConversation.LearnerId.ShouldBe(int.Parse("-2"));
        storedConversation.ContextId.ShouldBe(messageRequest.ContextId);
        storedConversation.Messages.ShouldNotBeNull();
        storedConversation.Messages.Count.ShouldBe(3);
    }

    [Theory]
    [MemberData(nameof(UpdateConversationMessages))]
    public async void Updates_existing_conversation(MessageRequest messageRequest)
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<LanguageModelConversationsContext>();
        var storedConversation = dbContext.Conversations.SingleOrDefault(c => c.Id == messageRequest.ConversationId);
        storedConversation.ShouldNotBeNull();
        var contentCount = storedConversation.Messages.Count;
        dbContext.Database.BeginTransaction();

        var response = await controller.SendMessage(messageRequest);
        var result = ((OkObjectResult)response.Result)?.Value as MessageResponse;

        dbContext.ChangeTracker.Clear();

        result.ShouldNotBeNull();
        result.NewMessage.ShouldNotBeNull();
        var updatedConversation = dbContext.Conversations.SingleOrDefault(c => c.Id == messageRequest.ConversationId);
        updatedConversation.ShouldNotBeNull();
        updatedConversation.LearnerId.ShouldBe(int.Parse("-2"));
        updatedConversation.ContextId.ShouldBe(messageRequest.ContextId);
        updatedConversation.Messages.ShouldNotBeNull();
        updatedConversation.Messages.Count.ShouldBe(contentCount + 3);
    }

    // TODO: dodati poseban test za sumarizaciju da je dobavi/ne dobavi iz baze (uz pisanje u bazu ako je ne dobavi

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
            new MessageRequest { ConversationId = 1, CourseId = -1, ContextId = -15, MessageType = "GenerateQuestions" }
        },
        new object[]
        {
            new MessageRequest { ConversationId = 1, CourseId = -1, ContextId = -15, MessageType = "ExtractKeywords" }
        },
        new object[]
        {
            new MessageRequest { ConversationId = 1, CourseId = -1, ContextId = -15, MessageType = "Summarize" }
        },
        new object[]
        {
            new MessageRequest { ConversationId = 1, CourseId = -1, ContextId = -15, MessageType = "GenerateSimilar" }
        },
        new object[]
        {
            new MessageRequest { ConversationId = 1, CourseId = -1, ContextId = -15, MessageType = "GenerateSimilar", TaskId = -153 }
        },
        new object[]
        {
            new MessageRequest { ConversationId = 1, CourseId = -1, ContextId = -15, MessageType = "TopicConversation", Message = "new message" }
        },
        new object[]
        {
            new MessageRequest { ConversationId = 1, CourseId = -1, ContextId = -15, MessageType = "TopicConversation", TaskId = -153, Message = "new message" }
        }
        // TODO: dodati po jedan test slucaj za saq i mcq
    };

    public static IEnumerable<object[]> UpdateConversationMessages() => new List<object[]>
    {

        new object[]
        {
            new MessageRequest { ConversationId = -1, CourseId = -1, ContextId = -11, MessageType = "GenerateQuestions" }
        },
        new object[]
        {
            new MessageRequest { ConversationId = -1, CourseId = -1, ContextId = -11, MessageType = "ExtractKeywords" }
        },
        new object[]
        {
            new MessageRequest { ConversationId = -1, CourseId = -1, ContextId = -11, MessageType = "Summarize" }
        },
        new object[]
        {
            new MessageRequest { ConversationId = -1, CourseId = -1, ContextId = -11, MessageType = "GenerateSimilar" }
        },
        new object[]
        {
            new MessageRequest { ConversationId = -2, CourseId = -1, ContextId = -14, MessageType = "GenerateSimilar", TaskId = -144 }
        },
        new object[]
        {
            new MessageRequest { ConversationId = -1, CourseId = -1, ContextId = -11, MessageType = "TopicConversation", Message = "new message" }
        },
        new object[]
        {
            new MessageRequest { ConversationId = -2, CourseId = -1, ContextId = -14, MessageType = "TopicConversation", TaskId = -144, Message = "new message" }
        }
    };
}