namespace Tutor.BuildingBlocks.Core.LLM;

public enum AiRole { System, User, Assistant }
public sealed record LlmMessage(string Content, AiRole Role, DateTime CreatedAt);
public sealed record LlmResponse(LlmMessage Message, int? PromptTokens = null, int? CompletionTokens = null, string? FinishReason = null);