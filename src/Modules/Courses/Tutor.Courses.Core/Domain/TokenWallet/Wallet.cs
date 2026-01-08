using FluentResults;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.Courses.Core.Domain.TokenWallet.Events;

namespace Tutor.Courses.Core.Domain.TokenWallet;

public class Wallet : EventSourcedAggregateRoot
{
    public int LearnerId { get; private set; }
    public int CourseId { get; private set; }
    public int TotalAllowance { get; private set; }
    public int TotalSpent { get; private set; }
    public int RemainingBalance => TotalAllowance - TotalSpent;

    private Wallet() { }

    public Wallet(int learnerId, int courseId, int initialAllowance)
    {
        LearnerId = learnerId;
        CourseId = courseId;
        Causes(new WalletInitialized { InitialAllowance = initialAllowance });
    }

    public Result<TokenSpendingResult> SpendTokens(TokenSpendingRequest request)
    {
        if (RemainingBalance < request.TotalTokens)
        {
            Causes(new TokenSpendingBlocked
            {
                UnitId = request.UnitId,
                RequestedTokens = request.TotalTokens,
                FeatureType = request.FeatureType,
                BlockReason = "Insufficient token balance"
            });
            return Result.Fail<TokenSpendingResult>("Insufficient token balance");
        }

        Causes(new TokensSpent
        {
            UnitId = request.UnitId,
            PromptTokens = request.PromptTokens,
            CompletionTokens = request.CompletionTokens,
            FeatureType = request.FeatureType,
            EntityId = request.EntityId,
            PromptSummary = request.PromptSummary
        });

        return Result.Ok(new TokenSpendingResult(RemainingBalance));
    }

    public Result DepositTokens(int amount, string reason)
    {
        if (amount <= 0) return Result.Fail("Deposit amount must be positive");

        Causes(new TokensDeposited { Amount = amount, Reason = reason });
        return Result.Ok();
    }

    protected override void Apply(DomainEvent @event)
    {
        if (@event is not WalletEvent walletEvent)
            throw new EventSourcingException("Unexpected event type: " + @event.GetType());

        walletEvent.LearnerId = LearnerId;
        walletEvent.CourseId = CourseId;

        When((dynamic)walletEvent);
    }

    private void When(WalletInitialized @event)
    {
        TotalAllowance = @event.InitialAllowance;
        TotalSpent = 0;
    }

    private void When(TokensSpent @event)
    {
        TotalSpent += @event.TotalTokens;
    }

    private void When(TokensDeposited @event)
    {
        TotalAllowance += @event.Amount;
    }

    private void When(TokenSpendingBlocked @event)
    {
        // Event recorded for observability, no state change
    }
}
