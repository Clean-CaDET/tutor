using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.AI.Core.Conversations;
using Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;
using Tutor.Elaborations.Core.UseCases.Learning.Prompts;

namespace Tutor.Elaborations.Infrastructure.Agents;

public class AgentFactory : IAgentFactory
{
    private readonly IAiChatService _chatService;
    private readonly ITurnUsageTracker _usageTracker;
    private readonly ILogger<AgentJson> _jsonLogger;
    private readonly ILogger<AgentStream> _streamLogger;

    public AgentFactory(IAiChatService chatService, ITurnUsageTracker usageTracker,
        ILogger<AgentJson> jsonLogger, ILogger<AgentStream> streamLogger)
    {
        _chatService = chatService;
        _usageTracker = usageTracker;
        _jsonLogger = jsonLogger;
        _streamLogger = streamLogger;
    }

    public IAgentJson   CreateIntentClassifier() => Json(AgentKind.IntentClassifier);
    public IAgentJson   CreateTurnScorer()       => Json(AgentKind.TurnScorer);
    public IAgentJson   CreateClosingScorer()    => Json(AgentKind.ClosingScorer);
    public IAgentStream CreateProbe()            => Stream(AgentKind.Probe);
    public IAgentStream CreateScaffolding()      => Stream(AgentKind.Scaffolding);
    public IAgentStream CreateCritique()         => Stream(AgentKind.Critique);
    public IAgentStream CreateClarification()    => Stream(AgentKind.Clarification);
    public IAgentStream CreateSummary()          => Stream(AgentKind.Summary);

    private IAgentJson Json(AgentKind kind) => new AgentJson(kind, _chatService, _jsonLogger);
    private IAgentStream Stream(AgentKind kind) => new AgentStream(kind, _chatService, _usageTracker, _streamLogger);
}
