using FluentResults;

namespace Tutor.BuildingBlocks.AI.Core.Guardrails;

public interface IOutputGuardrail
{
    Task<Result<GuardrailResult>> ValidateAsync(string output, string? originalInput = null, CancellationToken cancellationToken = default);
}
