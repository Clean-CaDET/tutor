using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptElaborationTasks;
using Tutor.Elaborations.Core.Domain.Conversations;

namespace Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

public class TurnOrchestrator
{
    private readonly IEvaluationAgent _evaluationAgent;
    private readonly IDialogueAgent _dialogueAgent;
    private readonly ISummaryAgent _summaryAgent;

    public TurnOrchestrator(IEvaluationAgent evaluationAgent,
        IDialogueAgent dialogueAgent, ISummaryAgent summaryAgent)
    {
        _evaluationAgent = evaluationAgent;
        _dialogueAgent = dialogueAgent;
        _summaryAgent = summaryAgent;
    }

    public async Task<Result<EvaluationResult>> EvaluateAsync(string content,
        List<ConversationTurn> history, ConceptElaborationTask task,
        CancellationToken ct)
    {
        return await _evaluationAgent.EvaluateAsync(content, history, task, ct);
    }

    public IAsyncEnumerable<string> StreamDialogueAsync(TurnEvaluation evaluation,
        List<ConversationTurn> history, ConceptElaborationTask task,
        ConversationState state, CancellationToken ct)
    {
        return _dialogueAgent.StreamAsync(evaluation, history, task, state, ct);
    }

    public async Task<Result<string>> SummarizeAsync(ConversationAttempt attempt,
        ConceptElaborationTask task, CancellationToken ct)
    {
        return await _summaryAgent.SummarizeAsync(attempt, task, ct);
    }
}
