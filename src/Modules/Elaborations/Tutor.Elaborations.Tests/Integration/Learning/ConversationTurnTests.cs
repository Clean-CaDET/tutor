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
// CET -1: Encapsulation (Basics), Unit -1      — KPs: P1 (P1 carries a misconception)
// CET -2: Encapsulation (Members), Unit -1     — KPs: P1, P2 (both carry a misconception)
// CET -3: Encapsulation (Basics — Unit 2), -2  — KPs: P1
// CET -5: Encapsulation (Members — Unit 2), -2 — KPs: P1, P2 — isolated for StartConversation
// CET -6: Encapsulation (Invariants), Unit -2  — KPs: P1, P2, P3 — isolated for Start+Submit flow
// CET -7: Polymorphism Mechanics, Unit -2      — KPs: P1, P2
// Learner -2: enrolled in Units -1, -2 | Learner -3: enrolled in Units -1, -2
// Learner -1: NOT enrolled | Learner -4: exhausted wallet
// Attempt -1: Learner -2, CET -1, Completed   (for conflict / cannot-submit tests)
// Attempt -3: Learner -3, CET -1, InProgress, RoundCount=1 (conflict + eval failure tests)
// Attempt -4: Learner -3, CET -2, InProgress, RoundCount=1 (completion test)
// Attempt -5: Learner -2, CET -2, InProgress, RoundCount=3 (hard cap test — MaxRounds=4)
// Attempt -7: Learner -3, CET -5, InProgress  (isolated for abandon test)
[Collection("Sequential")]
public class ConversationTurnTests : BaseElaborationsIntegrationTest
{
    public ConversationTurnTests(ElaborationsTestFactory factory) : base(factory) { }

    [Fact]
    public async Task Starts_conversation_with_first_turn()
    {
        Factory.MockChatService.Reset();
        Factory.SetupEvaluationMock([("P1", 0), ("P2", 0)]);
        Factory.SetupDialogueMock();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitElaborationRequestDto { Elaboration = "Encapsulation bundles data and methods." };

        var tokens = await CollectStreamAsync(controller.StartConversation(-5, dto, CancellationToken.None));

        tokens.Count.ShouldBeGreaterThan(1);
        var metadata = JsonSerializer.Deserialize<SubmitElaborationResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("InProgress");
        metadata.AttemptId.ShouldBeGreaterThan(0);
        Factory.MockChatService.Verify(x => x.CompleteAsync(
            It.Is<CompletionRequest>(r => r.MaxTokens == 2048), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Submission_completes_when_all_targets_adequate()
    {
        // CET -2 has P1, P2. Attempt -4 has RoundCount=1. Submit with all grade 2 → Completed.
        Factory.MockChatService.Reset();
        Factory.SetupEvaluationMock([("P1", 2), ("P2", 2)]);
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dto = new SubmitElaborationRequestDto { Elaboration = "Covers both propositions adequately." };

        var tokens = await CollectStreamAsync(controller.SubmitElaboration(-4, dto, CancellationToken.None));

        var metadata = JsonSerializer.Deserialize<SubmitElaborationResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("Completed");
    }

    [Fact]
    public async Task Hard_cap_expires_attempt()
    {
        // Attempt -5: CET -2, RoundCount=3, MaxRounds=4. Next submission hits cap → Expired.
        Factory.MockChatService.Reset();
        Factory.SetupEvaluationMock([("P1", 0), ("P2", 0)]);
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitElaborationRequestDto { Elaboration = "Attempt at the hard cap boundary." };

        var tokens = await CollectStreamAsync(controller.SubmitElaboration(-5, dto, CancellationToken.None));

        var metadata = JsonSerializer.Deserialize<SubmitElaborationResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("Expired");
    }

    [Fact]
    public async Task Submission_completes_when_all_kps_adequate()
    {
        // CET -7 (KPs P1, P2 = 2 targets). All grade 2 → Completed immediately.
        Factory.MockChatService.Reset();
        Factory.SetupEvaluationMock([("P1", 2), ("P2", 2)]);
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dto = new SubmitElaborationRequestDto
        {
            Elaboration = "A subclass can override a parent method, and the runtime selects the implementation by the actual type."
        };

        var tokens = await CollectStreamAsync(controller.StartConversation(-7, dto, CancellationToken.None));

        var metadata = JsonSerializer.Deserialize<SubmitElaborationResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("Completed");
    }

    [Fact]
    public async Task Start_then_submit_adds_turns_to_same_attempt()
    {
        // CET -6 (P1, P2, P3). Start creates attempt; submit reuses it.
        Factory.MockChatService.Reset();
        Factory.SetupEvaluationMock([("P1", 0), ("P2", 0), ("P3", 0)]);
        Factory.SetupDialogueMock();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dbContext = scope.ServiceProvider.GetRequiredService<ElaborationsContext>();
        var firstDto = new SubmitElaborationRequestDto { Elaboration = "First elaboration." };

        var firstTokens = await CollectStreamAsync(controller.StartConversation(-6, firstDto, CancellationToken.None));
        var firstMetadata = JsonSerializer.Deserialize<SubmitElaborationResponseDto>(firstTokens.Last());
        firstMetadata.ShouldNotBeNull();
        var attemptId = firstMetadata.AttemptId;

        dbContext.ChangeTracker.Clear();
        var roundCountAfterFirst = dbContext.ConversationAttempts
            .Include(a => a.Rounds).First(a => a.Id == attemptId).Rounds.Count;

        Factory.MockChatService.Reset();
        Factory.SetupEvaluationMock([("P1", 0), ("P2", 0), ("P3", 0)]);
        Factory.SetupDialogueMock();
        var secondDto = new SubmitElaborationRequestDto { Elaboration = "Revised elaboration." };

        var tokens = await CollectStreamAsync(controller.SubmitElaboration(attemptId, secondDto, CancellationToken.None));

        dbContext.ChangeTracker.Clear();
        var metadata = JsonSerializer.Deserialize<SubmitElaborationResponseDto>(tokens.Last());
        metadata.ShouldNotBeNull();
        metadata.Status.ShouldBe("InProgress");
        metadata.AttemptId.ShouldBe(attemptId);
        var reusedAttempt = dbContext.ConversationAttempts.Include(a => a.Rounds).First(a => a.Id == attemptId);
        reusedAttempt.Rounds.Count.ShouldBe(roundCountAfterFirst + 1);
    }

    [Fact]
    public async Task Start_unenrolled_fails()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-1");
        var dto = new SubmitElaborationRequestDto { Elaboration = "Should fail." };

        var tokens = await CollectStreamAsync(controller.StartConversation(-1, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(403);
    }

    [Fact]
    public async Task Start_insufficient_tokens_fails()
    {
        Factory.MockChatService.Reset();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-4");
        var dto = new SubmitElaborationRequestDto { Elaboration = "Should fail due to exhausted wallet." };

        var tokens = await CollectStreamAsync(controller.StartConversation(-1, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(402);
    }

    [Fact]
    public async Task Start_max_daily_attempts_fails()
    {
        Factory.MockChatService.Reset();
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitElaborationRequestDto { Elaboration = "Should fail due to daily limit." };

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
        var dto = new SubmitElaborationRequestDto { Elaboration = "Should trigger eval failure." };

        var tokens = await CollectStreamAsync(controller.SubmitElaboration(-3, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1, $"Got: [{string.Join("|", tokens)}]");
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(500);
    }

    [Fact]
    public async Task Start_nonexistent_task_fails()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitElaborationRequestDto { Elaboration = "Task does not exist." };

        var tokens = await CollectStreamAsync(controller.StartConversation(-999, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(404);
    }

    [Fact]
    public async Task Start_with_active_attempt_returns_conflict()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-3");
        var dto = new SubmitElaborationRequestDto { Elaboration = "Should conflict." };

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
        var dto = new SubmitElaborationRequestDto { Elaboration = "Attempt does not exist." };

        var tokens = await CollectStreamAsync(controller.SubmitElaboration(-999, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(404);
    }

    [Fact]
    public async Task Submit_wrong_learner_fails()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitElaborationRequestDto { Elaboration = "Not my attempt." };

        var tokens = await CollectStreamAsync(controller.SubmitElaboration(-4, dto, CancellationToken.None));

        tokens.Count.ShouldBe(1);
        var error = JsonSerializer.Deserialize<JsonElement>(tokens[0]);
        error.GetProperty("code").GetInt32().ShouldBe(403);
    }

    [Fact]
    public async Task Submit_completed_attempt_fails()
    {
        using var scope = Factory.Services.CreateScope();
        var controller = CreateController(scope, "-2");
        var dto = new SubmitElaborationRequestDto { Elaboration = "Attempt already done." };

        var tokens = await CollectStreamAsync(controller.SubmitElaboration(-1, dto, CancellationToken.None));

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
