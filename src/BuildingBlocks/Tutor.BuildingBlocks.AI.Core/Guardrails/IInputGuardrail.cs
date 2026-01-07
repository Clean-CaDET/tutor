using FluentResults;

namespace Tutor.BuildingBlocks.AI.Core.Guardrails;

public interface IInputGuardrail
{
    Task<Result<GuardrailResult>> ValidateAsync(string input, CancellationToken cancellationToken = default);
}
