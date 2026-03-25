using FluentResults;
using Tutor.Elaborations.Core.Domain.ConceptRecords;
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
        List<ConversationTurn> history, ConceptRecord conceptRecord,
        CancellationToken ct)
    {
        return await _evaluationAgent.EvaluateAsync(content, history, conceptRecord, ct);
    }

    public IAsyncEnumerable<string> StreamDialogueAsync(TurnEvaluation evaluation,
        List<ConversationTurn> history, ConceptRecord conceptRecord,
        ConversationState state, CancellationToken ct)
    {
        return _dialogueAgent.StreamAsync(evaluation, history, conceptRecord, state, ct);
    }

    public async Task<Result<string>> SummarizeAsync(ConversationAttempt attempt,
        ConceptRecord conceptRecord, CancellationToken ct)
    {
        return await _summaryAgent.SummarizeAsync(attempt, conceptRecord, ct);
    }
}
