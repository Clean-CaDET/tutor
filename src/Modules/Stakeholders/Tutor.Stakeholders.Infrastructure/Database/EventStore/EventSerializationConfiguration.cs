using System.Collections.Immutable;
using Tutor.Stakeholders.Core.Domain.Events;

namespace Tutor.Stakeholders.Infrastructure.Database.EventStore;

public static class EventSerializationConfiguration
{
    public static readonly IImmutableDictionary<Type, string> EventRelatedTypes = new Dictionary<Type, string>
    {
        { typeof(WalletCreated), "WalletCreated" },
        { typeof(TokensAdded), "TokensAdded" },
        { typeof(TokensDeducted), "TokensDeducted" }
    }.ToImmutableDictionary();
}