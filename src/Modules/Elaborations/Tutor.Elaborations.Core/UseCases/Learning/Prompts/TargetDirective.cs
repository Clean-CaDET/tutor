using Tutor.Elaborations.Core.UseCases.Learning.Orchestration;

namespace Tutor.Elaborations.Core.UseCases.Learning.Prompts;

/// <summary>
/// A <see cref="ProbeDirective"/> with the target statement pre-resolved into text.
/// The orchestrator resolves the text once per turn so prompt builders never reach into the task definition.
/// </summary>
public sealed record TargetDirective(
    ProbeTargetType Type,
    string Key,
    int Level,
    string Statement);
