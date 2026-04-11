using System.Text.Json;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shouldly;
using Tutor.API.Controllers.Learner.Learning.Elaboration;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.API.Dtos.Conversations;
using Tutor.Elaborations.API.Public.Learning;
using Tutor.Elaborations.Infrastructure.Database;

namespace Tutor.Elaborations.Tests.Integration.Learning;

// Test data layout:
// CET -1: Encapsulation (Basics), Unit -1 (1 KP: -10)
// CET -2: Encapsulation (Members), Unit -1 (2 KPs: -20, -21)
// CET -3: Encapsulation (Basics — Unit 2), Unit -2 (1 KP: -30)
// CET -5: Encapsulation (Members — Unit 2), Unit -2 (2 KPs: -50, -51) — isolated for StartConversation
// CET -6: Encapsulation (Invariants), Unit -2 (3 KPs: -60, -61, -62) — isolated for Start+Submit flow
// CET -7: Polymorphism Mechanics, Unit -2 (2 KPs: -70, -71 + KR -370) — isolated
// Learner -2: enrolled in Units -1, -2 | Learner -3: enrolled in Units -1, -2
// Learner -1: NOT enrolled | Learner -4: exhausted wallet
// Attempt -3: Learner -3, CET -1, InProgress (2 turns — for conflict + eval failure tests)
// Attempt -4: Learner -3, CET -2, InProgress (KP -20 covered — completion test)
// Attempt -5: Learner -2, CET -2, InProgress (9 learner turns — hard cap seed)
// Attempt -6: Learner -3, CET -3, InProgress (5 substantive turns — soft cap seed)
// Attempt -7: Learner -3, CET -5, InProgress (isolated for abandon test)
[Collection("Sequential")]
public class ConversationTurnTests : BaseElaborationsIntegrationTest
{
    public ConversationTurnTests(ElaborationsTestFactory factory) : base(factory) { }

    [Fact]
    public async Task Starts_conversation_with_first_turn()
    {
        Factory.MockChatService.Reset();
        Factory.SetupDefaultMocks();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitTurnRequestDto { Content = "Encapsulation bundles data and methods." };

        var tokens = await CollectStreamAsync(controller.StartConversation(-5, dto, CancellationToken.None));

        tokens.Count.ShouldBeGreaterThan(1);
        var metadata = JsonSerializer.Deserialize<SubmitTurnResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("InProgress");
        metadata.AttemptId.ShouldBeGreaterThan(0);
        Factory.MockChatService.Verify(x => x.CompleteAsync(
            It.Is<CompletionRequest>(r => r.MaxTokens == 1024), It.IsAny<CancellationToken>()), Times.Once);

        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        dbContext.ChangeTracker.Clear();
        var attempt = dbContext.ConversationAttempts.Include(a => a.Turns)
            .FirstOrDefault(a => a.ConceptElaborationTaskId == -5 && a.LearnerId == -2 && a.Status == 0);
        attempt.ShouldNotBeNull();
        attempt.Turns.Count.ShouldBeGreaterThanOrEqualTo(2);
    }

    [Fact]
    public async Task All_propositions_covered_completes()
    {
        Factory.MockChatService.Reset();
        Factory.SetupEvaluationMock([-20, -21]);
        Factory.SetupDialogueMock();
        Factory.SetupSummaryMock("Completed conversation summary.");
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dto = new SubmitTurnRequestDto { Content = "Access modifiers control visibility of members." };

        var tokens = await CollectStreamAsync(controller.SubmitTurn(-4, dto, CancellationToken.None));

        var metadata = JsonSerializer.Deserialize<SubmitTurnResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("Completed");
        metadata.Summary.ShouldNotBeNullOrEmpty();
        Factory.MockChatService.Verify(x => x.CompleteAsync(
            It.Is<CompletionRequest>(r => r.MaxTokens == 256), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Hard_cap_reached_expires()
    {
        Factory.MockChatService.Reset();
        Factory.SetupEvaluationMock(propositionsCoveredIds: []);
        Factory.SetupDialogueMock();
        Factory.SetupSummaryMock("Expired due to hard cap.");
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitTurnRequestDto { Content = "Final turn attempt." };

        var tokens = await CollectStreamAsync(controller.SubmitTurn(-5, dto, CancellationToken.None));

        var metadata = JsonSerializer.Deserialize<SubmitTurnResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("Expired");
        metadata.Summary.ShouldNotBeNullOrEmpty();
    }

    [Fact]
    public async Task Soft_cap_reached_continues()
    {
        Factory.MockChatService.Reset();
        Factory.SetupEvaluationMock(propositionsCoveredIds: []);
        Factory.SetupDialogueMock();
        Factory.SetupSummaryMock();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dto = new SubmitTurnRequestDto { Content = "Sixth substantive turn." };

        var tokens = await CollectStreamAsync(controller.SubmitTurn(-6, dto, CancellationToken.None));

        tokens.Count.ShouldBeGreaterThan(1);
        var metadata = JsonSerializer.Deserialize<SubmitTurnResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("InProgress");

        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        dbContext.ChangeTracker.Clear();
        var attempt = dbContext.ConversationAttempts.Include(a => a.Turns)
            .First(a => a.Id == -6);
        attempt.Turns.Count(t => t.Role == 0 && t.IsSubstantive).ShouldBe(6);
    }

    [Fact]
    public async Task Start_unenrolled_fails()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-1");
        var dto = new SubmitTurnRequestDto { Content = "Should fail." };

        var tokens = await CollectStreamAsync(controller.StartConversation(-1, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(403);
    }

    [Fact]
    public async Task Start_insufficient_tokens_fails()
    {
        Factory.MockChatService.Reset();
        Factory.SetupDefaultMocks();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-4");
        var dto = new SubmitTurnRequestDto { Content = "Should fail due to exhausted wallet." };

        var tokens = await CollectStreamAsync(controller.StartConversation(-1, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(402);
    }

    [Fact]
    public async Task Start_max_daily_attempts_fails()
    {
        Factory.MockChatService.Reset();
        Factory.SetupDefaultMocks();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitTurnRequestDto { Content = "Should fail due to daily limit." };

        var tokens = await CollectStreamAsync(controller.StartConversation(-3, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(429);
    }

    [Fact]
    public async Task Submit_evaluation_failure_returns_error()
    {
        Factory.MockChatService.Reset();
        Factory.MockChatService.Setup(x => x.CompleteAsync(
                It.IsAny<CompletionRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(Result.Fail<CompletionResponse>("LLM unavailable"));
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dto = new SubmitTurnRequestDto { Content = "Should trigger eval failure." };

        var tokens = await CollectStreamAsync(controller.SubmitTurn(-3, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1, $"Got: [{string.Join("|", tokens)}]");
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(500);
    }

    [Fact]
    public async Task Start_nonexistent_task_fails()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitTurnRequestDto { Content = "Task does not exist." };

        var tokens = await CollectStreamAsync(controller.StartConversation(-999, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(404);
    }

    [Fact]
    public async Task Start_then_submit_adds_turns_to_same_attempt()
    {
        Factory.MockChatService.Reset();
        Factory.SetupDefaultMocks();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        var firstDto = new SubmitTurnRequestDto { Content = "First turn for reuse test." };
        var firstTokens = await CollectStreamAsync(controller.StartConversation(-6, firstDto, CancellationToken.None));

        var firstMetadata = JsonSerializer.Deserialize<SubmitTurnResponseDto>(firstTokens.Last());
        firstMetadata.ShouldNotBeNull();
        var attemptId = firstMetadata.AttemptId;
        attemptId.ShouldBeGreaterThan(0);

        dbContext.ChangeTracker.Clear();
        var createdAttempt = dbContext.ConversationAttempts.Include(a => a.Turns)
            .First(a => a.Id == attemptId);
        var turnCountAfterFirst = createdAttempt.Turns.Count;

        // Submit second turn — should add to the same attempt
        Factory.MockChatService.Reset();
        Factory.SetupDefaultMocks();
        var secondDto = new SubmitTurnRequestDto { Content = "Second turn for reuse test." };
        var tokens = await CollectStreamAsync(controller.SubmitTurn(attemptId, secondDto, CancellationToken.None));

        dbContext.ChangeTracker.Clear();
        var metadata = JsonSerializer.Deserialize<SubmitTurnResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("InProgress");
        metadata.AttemptId.ShouldBe(attemptId);
        var reusedAttempt = dbContext.ConversationAttempts.Include(a => a.Turns)
            .First(a => a.Id == attemptId);
        reusedAttempt.Turns.Count.ShouldBe(turnCountAfterFirst + 2);
    }

    [Fact]
    public async Task Start_with_active_attempt_returns_conflict()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dto = new SubmitTurnRequestDto { Content = "Should conflict." };

        var tokens = await CollectStreamAsync(controller.StartConversation(-1, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(409);
        error.GetProperty("attemptId").GetInt32().ShouldBe(-3);
    }

    [Fact]
    public async Task Submit_nonexistent_attempt_fails()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitTurnRequestDto { Content = "Attempt does not exist." };

        var tokens = await CollectStreamAsync(controller.SubmitTurn(-999, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(404);
    }

    [Fact]
    public async Task Submit_wrong_learner_fails()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitTurnRequestDto { Content = "Not my attempt." };

        var tokens = await CollectStreamAsync(controller.SubmitTurn(-4, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(403);
    }

    [Fact]
    public async Task Concept_with_relations_completes_when_relations_articulated()
    {
        // CET -7 (KPs -70, -71 + KR -370). Strict completion: covering both KPs is not enough.
        Factory.MockChatService.Reset();
        Factory.SetupEvaluationMock(
            propositionsCoveredIds: [-70, -71],
            relationsArticulatedIds: [-370],
            integrationScore: 3);
        Factory.SetupDialogueMock();
        Factory.SetupSummaryMock("Polymorphism mechanics summary.");
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dto = new SubmitTurnRequestDto
        {
            Content = "Override matters because the runtime picks the actual type's implementation."
        };

        var tokens = await CollectStreamAsync(controller.StartConversation(-7, dto, CancellationToken.None));

        var metadata = JsonSerializer.Deserialize<SubmitTurnResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("Completed");
        metadata.Summary.ShouldNotBeNullOrEmpty();
    }

    [Fact]
    public async Task Concept_with_relations_does_not_complete_when_only_KPs_covered()
    {
        // CET -7. Covering KPs but NOT articulating the relation should NOT complete.
        // Uses learner -2 so test doesn't collide with the "completes" test (also on CET -7).
        Factory.MockChatService.Reset();
        Factory.SetupEvaluationMock(
            propositionsCoveredIds: [-70, -71],
            relationsArticulatedIds: [],
            integrationScore: 1);
        Factory.SetupDialogueMock();
        Factory.SetupSummaryMock();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitTurnRequestDto
        {
            Content = "Override is a thing and runtime types exist, but I won't say how they connect."
        };

        var tokens = await CollectStreamAsync(controller.StartConversation(-7, dto, CancellationToken.None));

        var metadata = JsonSerializer.Deserialize<SubmitTurnResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("InProgress");
    }

    [Fact]
    public async Task Submit_completed_attempt_fails()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitTurnRequestDto { Content = "Attempt already done." };

        var tokens = await CollectStreamAsync(controller.SubmitTurn(-1, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(409);
    }

    private static ConversationController CreateController(IServiceScope scope, string learnerId)
    {
        return new ConversationController(scope.ServiceProvider.GetRequiredService<IConversationService>())
        {
            ControllerContext = BuildContext(learnerId, "learner")
        };
    }

    private static async Task<List<string>> CollectStreamAsync(IAsyncEnumerable<string> stream)
    {
        var tokens = new List<string>();
        await foreach (var token in stream)
            tokens.Add(token);
        return tokens;
    }
}
