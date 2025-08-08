using FluentResults;
using Tutor.BuildingBlocks.Core.EventSourcing;
using Tutor.Stakeholders.Core.Domain.Events;

namespace Tutor.Stakeholders.Core.Domain;

public class Wallet : EventSourcedAggregateRoot
{
    public int AvailableTokens { get; private set; }
    public int LearnerId { get; private set; }

    private Wallet() { }

    public Wallet(int learnerId, int initialTokens = 0)
    {
        LearnerId = learnerId;
        Causes(new WalletCreated { InitialTokens = initialTokens });
    }

    public Result AddTokens(int amount)
    {
        Causes(new TokensAdded { Amount = amount });
        return Result.Ok();
    }

    public Result DeductTokens(int amount)
    {
        if (amount <= 0)
            return Result.Fail("Amount must be positive");

        if (AvailableTokens < amount)
            return Result.Fail("Insufficient tokens");

        Causes(new TokensDeducted { Amount = amount });
        return Result.Ok();
    }

    protected override void Apply(DomainEvent @event)
    {
        if (@event is not WalletEvent walletEvent) 
            throw new EventSourcingException("Unexpected event type: " + @event.GetType());

        walletEvent.LearnerId = LearnerId;
        When((dynamic)walletEvent);
    }

    private void When(WalletCreated @event)
    {
        AvailableTokens = @event.InitialTokens;
    }

    private void When(TokensAdded @event)
    {
        AvailableTokens += @event.Amount;
    }

    private void When(TokensDeducted @event)
    {
        AvailableTokens -= @event.Amount;
    }
}