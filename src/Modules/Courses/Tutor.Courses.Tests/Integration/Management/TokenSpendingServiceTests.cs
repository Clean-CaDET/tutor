using Microsoft.Extensions.DependencyInjection;
using Shouldly;
using Tutor.Courses.API.Dtos.TokenWallet;
using Tutor.Courses.API.Internal;
using Tutor.Courses.Infrastructure.Database;

namespace Tutor.Courses.Tests.Integration.Management;

[Collection("Sequential")]
public class TokenSpendingServiceTests : BaseCoursesIntegrationTest
{
    public TokenSpendingServiceTests(CoursesTestFactory factory) : base(factory) { }

    [Fact]
    public void Spends_tokens_successfully()
    {
        using var scope = Factory.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<ITokenSpendingService>();
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var request = new TokenSpendingRequestDto
        {
            LearnerId = -1,
            CourseId = -1,
            UnitId = -1,
            PromptTokens = 100,
            CompletionTokens = 50,
            FeatureType = "Kc",
            EntityId = 1,
            PromptSummary = "Test AI interaction"
        };

        var result = service.SpendTokens(request);

        result.IsSuccess.ShouldBeTrue();
        result.Value.TokensSpent.ShouldBe(150);
        result.Value.RemainingBalance.ShouldBe(1999850);

        dbContext.ChangeTracker.Clear();
        var wallet = dbContext.TokenWallets.FirstOrDefault(w => w.LearnerId == -1 && w.CourseId == -1);
        wallet.ShouldNotBeNull();
        wallet.TotalSpent.ShouldBe(150);
        wallet.RemainingBalance.ShouldBe(1999850);
    }

    [Fact]
    public void Tracks_multiple_spending_transactions()
    {
        using var scope = Factory.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<ITokenSpendingService>();
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        // First spending
        var request1 = new TokenSpendingRequestDto
        {
            LearnerId = -1,
            CourseId = -1,
            UnitId = -1,
            PromptTokens = 100,
            CompletionTokens = 50,
            FeatureType = "Kc",
            EntityId = 1
        };

        var result1 = service.SpendTokens(request1);
        result1.IsSuccess.ShouldBeTrue();
        result1.Value.RemainingBalance.ShouldBe(1999850);

        // Second spending
        var request2 = new TokenSpendingRequestDto
        {
            LearnerId = -1,
            CourseId = -1,
            UnitId = -1,
            PromptTokens = 200,
            CompletionTokens = 100,
            FeatureType = "Task",
            EntityId = 2
        };

        var result2 = service.SpendTokens(request2);
        result2.IsSuccess.ShouldBeTrue();
        result2.Value.TokensSpent.ShouldBe(300);
        result2.Value.RemainingBalance.ShouldBe(1999550);

        dbContext.ChangeTracker.Clear();
        var wallet = dbContext.TokenWallets.FirstOrDefault(w => w.LearnerId == -1 && w.CourseId == -1);
        wallet.ShouldNotBeNull();
        wallet.TotalSpent.ShouldBe(450);
    }

    [Fact]
    public void Fails_when_insufficient_balance()
    {
        using var scope = Factory.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<ITokenSpendingService>();
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var request = new TokenSpendingRequestDto
        {
            LearnerId = -1,
            CourseId = -1,
            UnitId = -1,
            PromptTokens = 3000000, // More than available balance
            CompletionTokens = 0,
            FeatureType = "Kc",
            EntityId = 1
        };

        var result = service.SpendTokens(request);

        result.IsFailed.ShouldBeTrue();
        result.Errors[0].Message.ShouldContain("Insufficient");

        dbContext.ChangeTracker.Clear();
        var wallet = dbContext.TokenWallets.FirstOrDefault(w => w.LearnerId == -1 && w.CourseId == -1);
        wallet.ShouldNotBeNull();
        wallet.TotalSpent.ShouldBe(0); // No change

        // Verify blocking event was recorded
        var blockingEvent = dbContext.WalletEvents
            .Where(e => e.LearnerId == -1 && e.CourseId == -1)
            .OrderByDescending(e => e.TimeStamp)
            .FirstOrDefault();
        blockingEvent.ShouldNotBeNull();
    }

    [Fact]
    public void Fails_when_wallet_not_found()
    {
        using var scope = Factory.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<ITokenSpendingService>();

        var request = new TokenSpendingRequestDto
        {
            LearnerId = -999,
            CourseId = -999,
            UnitId = -1,
            PromptTokens = 100,
            CompletionTokens = 50,
            FeatureType = "Kc"
        };

        var result = service.SpendTokens(request);

        result.IsFailed.ShouldBeTrue();
        result.Errors[0].Message.ShouldContain("wallet");
    }

    [Fact]
    public void Fails_when_invalid_feature_type()
    {
        using var scope = Factory.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<ITokenSpendingService>();
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        var request = new TokenSpendingRequestDto
        {
            LearnerId = -1,
            CourseId = -1,
            UnitId = -1,
            PromptTokens = 100,
            CompletionTokens = 50,
            FeatureType = "InvalidType"
        };

        var result = service.SpendTokens(request);

        result.IsFailed.ShouldBeTrue();
        result.Errors[0].Message.ShouldContain("Invalid feature type");
    }

    [Fact]
    public void Records_spending_with_different_feature_types()
    {
        using var scope = Factory.Services.CreateScope();
        var service = scope.ServiceProvider.GetRequiredService<ITokenSpendingService>();
        var dbContext = scope.ServiceProvider.GetRequiredService<CoursesContext>();
        dbContext.Database.BeginTransaction();

        // Spend for KC
        var kcRequest = new TokenSpendingRequestDto
        {
            LearnerId = -1,
            CourseId = -1,
            UnitId = -1,
            PromptTokens = 50,
            CompletionTokens = 25,
            FeatureType = "Kc",
            EntityId = 1
        };
        var kcResult = service.SpendTokens(kcRequest);
        kcResult.IsSuccess.ShouldBeTrue();

        // Spend for Task
        var taskRequest = new TokenSpendingRequestDto
        {
            LearnerId = -1,
            CourseId = -1,
            UnitId = -1,
            PromptTokens = 100,
            CompletionTokens = 50,
            FeatureType = "Task",
            EntityId = 2
        };
        var taskResult = service.SpendTokens(taskRequest);
        taskResult.IsSuccess.ShouldBeTrue();

        // Spend for Reflection
        var reflectionRequest = new TokenSpendingRequestDto
        {
            LearnerId = -1,
            CourseId = -1,
            UnitId = -1,
            PromptTokens = 150,
            CompletionTokens = 75,
            FeatureType = "Reflection",
            EntityId = 3
        };
        var reflectionResult = service.SpendTokens(reflectionRequest);
        reflectionResult.IsSuccess.ShouldBeTrue();

        dbContext.ChangeTracker.Clear();
        var wallet = dbContext.TokenWallets.FirstOrDefault(w => w.LearnerId == -1 && w.CourseId == -1);
        wallet.ShouldNotBeNull();
        wallet.TotalSpent.ShouldBe(450); // 75 + 150 + 225
    }
}
