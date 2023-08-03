using FluentResults;

namespace Tutor.BuildingBlocks.Core.UseCases;

public static class FailureCode
{
    public static readonly IError NotEnrolledInUnit = new Error("Not enrolled in unit.")
        .WithMetadata("code", 403)
        .WithMetadata("subCode", "kc1");
    public static readonly IError InvalidAssessmentSubmission = new Error("Invalid assessment submission.")
        .WithMetadata("code", 400)
        .WithMetadata("subCode", "kc2");
    public static readonly IError DuplicateUsername = new Error("Duplicate username.")
        .WithMetadata("code", 400)
        .WithMetadata("subCode", "s1");

    public static readonly IError InvalidArgument = new Error("Invalid data supplied.")
        .WithMetadata("code", 400);
    public static readonly IError Forbidden = new Error("Access to resource is restricted.")
        .WithMetadata("code", 403);
    public static readonly IError NotFound = new Error("Accessed resource not found.")
        .WithMetadata("code", 404);
    public static readonly IError Conflict = new Error("Database persistence conflict exception.")
        .WithMetadata("code", 409);
}