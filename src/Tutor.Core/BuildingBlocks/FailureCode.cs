using FluentResults;

namespace Tutor.Core.BuildingBlocks;

public static class FailureCode
{
    public static readonly IError NotEnrolledInUnit = new Error("Not enrolled in unit.");
    public static readonly IError InvalidAssessmentSubmission = new Error("Invalid assessment submission.");

    public static readonly IError NotFound = new Error("Accessed resource not found.");
}