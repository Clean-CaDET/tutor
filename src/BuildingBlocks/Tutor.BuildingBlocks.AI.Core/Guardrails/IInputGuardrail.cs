using FluentResults;

namespace Tutor.BuildingBlocks.AI.Core.Guardrails;

/// <summary>
/// Validates user input before sending it to an AI model (e.g., checking for harmful prompts, PII, jailbreak attempts).
/// </summary>
public interface IInputGuardrail
{
    Task<Result<GuardrailResult>> ValidateAsync(string input, CancellationToken cancellationToken = default);
}
