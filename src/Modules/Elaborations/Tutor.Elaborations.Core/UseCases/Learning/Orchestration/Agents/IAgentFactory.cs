namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration.Agents;

public interface IAgentFactory
{
    IAgentJson   CreateIntentClassifier();
    IAgentJson   CreateTurnScorer();
    IAgentJson   CreateClosingScorer();
    IAgentStream CreateProbe();
    IAgentStream CreateScaffolding();
    IAgentStream CreateCritique();
    IAgentStream CreateClarification();
    IAgentStream CreateSummary();
}
