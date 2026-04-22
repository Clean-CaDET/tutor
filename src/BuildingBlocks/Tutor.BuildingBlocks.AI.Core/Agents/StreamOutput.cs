namespace Tutor.BuildingBlocks.AI.Core.Agents;

/// <summary>
/// Output of a streaming agent call. Either a content token or a terminal failure.
/// </summary>
public abstract record StreamOutput;

public sealed record StreamToken(string Content) : StreamOutput;

public sealed record StreamFailure(string Reason) : StreamOutput;
