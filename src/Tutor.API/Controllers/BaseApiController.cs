using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Tutor.BuildingBlocks.Core.UseCases;

namespace Tutor.API.Controllers;

[ApiController]
public class BaseApiController : ControllerBase
{
    protected ActionResult CreateErrorResponse(List<IError> errors)
    {
        var code = 500;
        if (errors.Contains(FailureCode.InvalidAssessmentSubmission)) code = 400;
        if (errors.Contains(FailureCode.InvalidArgument)) code = 400;
        if (errors.Contains(FailureCode.NotEnrolledInUnit)) code = 403;
        if (errors.Contains(FailureCode.Forbidden)) code = 403;
        if (errors.Contains(FailureCode.NotFound)) code = 404;
        if (errors.Contains(FailureCode.Conflict)) code = 409;
        if (errors.Contains(FailureCode.DuplicateUsername)) code = 400;
        return Problem(statusCode: code, detail: string.Join(";", errors));
    }

    protected ActionResult CreateResponse(Result result)
    {
        return result.IsSuccess ? Ok() : CreateErrorResponse(result.Errors);
    }

    protected ActionResult CreateResponse<T>(Result<T> result)
    {
        return result.IsSuccess ? Ok(result.Value) : CreateErrorResponse(result.Errors);
    }
}