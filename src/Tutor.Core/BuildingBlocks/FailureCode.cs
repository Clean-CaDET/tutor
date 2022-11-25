using FluentResults;

namespace Tutor.Core.BuildingBlocks;

public static class FailureCode
{
    public static readonly IError NoActiveEnrollment = new Error("Not enrolled in unit.");
    public static readonly IError NoKnowledgeComponent = new Error("KC does not exist.");
}