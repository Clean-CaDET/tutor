using FluentResults;
using Tutor.BuildingBlocks.AI.Core.Guardrails;

namespace Tutor.BuildingBlocks.AI.Infrastructure.Guardrails;

/// <summary>
/// Combines multiple output guardrails, collecting violations from all. Fails fast on service errors.
/// </summary>
public class CompositeOutputGuardrail : IOutputGuardrail
{
    private readonly IEnumerable<IOutputGuardrail> _guardrails;

    public CompositeOutputGuardrail(IEnumerable<IOutputGuardrail> guardrails)
    {
        _guardrails = guardrails;
    }

    public async Task<Result<GuardrailResult>> ValidateAsync(string output, string? originalInput = null, CancellationToken cancellationToken = default)
    {
        var allViolations = new List<GuardrailViolation>();

        foreach (var guardrail in _guardrails)
        {
            var result = await guardrail.ValidateAsync(output, originalInput, cancellationToken);
            if (result.IsFailed)
            {
                return result;
            }

            if (!result.Value.IsValid)
            {
                allViolations.AddRange(result.Value.Violations);
            }
        }

        return allViolations.Count > 0
            ? Result.Ok(GuardrailResult.Invalid(allViolations.ToArray()))
            : Result.Ok(GuardrailResult.Valid());
    }
}
