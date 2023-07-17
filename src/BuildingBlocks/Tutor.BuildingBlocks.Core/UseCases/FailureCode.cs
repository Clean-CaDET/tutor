using FluentResults;

namespace Tutor.BuildingBlocks.Core.UseCases;

public static class FailureCode
{
    // TODO: Rework this
    public static readonly IError NotEnrolledInUnit = new Error("Not enrolled in unit.");
    public static readonly IError InvalidAssessmentSubmission = new Error("Invalid assessment submission.");
    public static readonly IError DuplicateUsername = new Error("Duplicate username.");

    public static readonly IError InvalidArgument = new Error("Invalid data supplied.");
    public static readonly IError NotFound = new Error("Accessed resource not found.");
    public static readonly IError Forbidden = new Error("Access to resource is restricted.");
    public static readonly IError Conflict = new Error("Database persistence conflict exception.");

    public static readonly IError InternalServerError = new Error("Internal server error, unhandled exception.");
}