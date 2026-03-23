using FluentResults;

namespace Tutor.BuildingBlocks.AI.Core.Guardrails;

/// <summary>
/// Validates AI model output before returning it to users (e.g., checking for harmful content, policy violations, hallucinations).
/// </summary>
public interface IOutputGuardrail
{
    Task<Result<GuardrailResult>> ValidateAsync(string output, string? originalInput = null, CancellationToken cancellationToken = default);
}
