using System.Collections.Immutable;
using Tutor.Courses.Core.Domain.TokenWallet.Events;

namespace Tutor.Courses.Infrastructure.Database.EventStore.Wallet;

public static class WalletEventSerializationConfiguration
{
    public static readonly IImmutableDictionary<Type, string> EventRelatedTypes = new Dictionary<Type, string>
    {
        { typeof(WalletInitialized), "WalletInitialized" },
        { typeof(TokensDeposited), "TokensDeposited" },
        { typeof(TokensSpent), "TokensSpent" }
    }.ToImmutableDictionary();
}
