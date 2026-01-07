using FluentResults;
using Tutor.BuildingBlocks.AI.Core.Guardrails;

namespace Tutor.BuildingBlocks.AI.Infrastructure.Guardrails;

public class CompositeInputGuardrail : IInputGuardrail
{
    private readonly IEnumerable<IInputGuardrail> _guardrails;

    public CompositeInputGuardrail(IEnumerable<IInputGuardrail> guardrails)
    {
        _guardrails = guardrails;
    }

    public async Task<Result<GuardrailResult>> ValidateAsync(
        string input,
        CancellationToken cancellationToken = default)
    {
        var allViolations = new List<GuardrailViolation>();

        foreach (var guardrail in _guardrails)
        {
            var result = await guardrail.ValidateAsync(input, cancellationToken);
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
