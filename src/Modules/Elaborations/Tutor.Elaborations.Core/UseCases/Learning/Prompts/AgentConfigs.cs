using Tutor.Elaborations.Core.UseCases.Learning.Prompts.Agents;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

public static class AgentConfigs
{
    public static readonly IReadOnlyDictionary<AgentKind, AgentConfig> ByKind = new Dictionary<AgentKind, AgentConfig>
    {
        [AgentKind.IntentClassifier] = new(IntentPrompt.Build,       MaxTokens:   64, Temperature: 0.0, HistoryWindow: 6),
        [AgentKind.Scorer]           = new(ScorerPrompt.Build,       MaxTokens: 1024, Temperature: 0.0),
        [AgentKind.Probe]            = new(ProbePrompt.Build,        MaxTokens:  256, Temperature: 0.7),
        [AgentKind.Scaffolding]      = new(ScaffoldingPrompt.Build,  MaxTokens:  512, Temperature: 0.7),
        [AgentKind.Critique]         = new(CritiquePrompt.Build,     MaxTokens:  512, Temperature: 0.7),
        [AgentKind.Clarification]    = new(ClarificationPrompt.Build,MaxTokens:  256, Temperature: 0.5),
        [AgentKind.Redirect]         = new(RedirectPrompt.Build,     MaxTokens:  128, Temperature: 0.7),
        [AgentKind.MetaHelp]         = new(MetaHelpPrompt.Build,     MaxTokens:  256, Temperature: 0.5),
        [AgentKind.Closing]          = new(ClosingPrompt.Build,      MaxTokens:  128, Temperature: 0.5),
        [AgentKind.Summary]          = new(SummaryPrompt.Build,      MaxTokens:  256, Temperature: 0.5),
    };
}
