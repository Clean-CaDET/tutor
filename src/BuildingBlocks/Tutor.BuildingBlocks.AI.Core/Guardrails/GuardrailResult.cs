namespace Tutor.BuildingBlocks.AI.Core.Guardrails;

/// <summary>
/// Result of validating content against safety and policy rules.
/// </summary>
public record GuardrailResult(bool IsValid, IReadOnlyList<GuardrailViolation> Violations)
{
    public static GuardrailResult Valid() => new(true, []);
    public static GuardrailResult Invalid(GuardrailViolation[] violations) => new(false, violations);
}

public record GuardrailViolation(string Category, string Reason);