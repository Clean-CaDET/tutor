using Tutor.Elaborations.Core.Domain.ConceptRecords;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public sealed record AgentConfig(
    Func<ConceptRecord, string> BuildSystemPrompt,
    int MaxTokens,
    double Temperature,
    int? HistoryWindow = null);
