using System;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Web.Controllers;

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
        return Problem(statusCode: code, detail: string.Join(";", errors));
    }

    protected ActionResult CreateResponse(Result result, Func<ActionResult> onSuccess, Func<List<IError>, ActionResult> onFailure)
    {
        if (result.IsSuccess)
        {
            return onSuccess();
        }
        return onFailure(result.Errors);
    }

    protected ActionResult CreateResponse<T>(Result<T> result, Func<T, ActionResult> onSuccess, Func<List<IError>, ActionResult> onFailure)
    {
        if (result.IsSuccess)
        {
            return onSuccess(result.Value);
        }
        return onFailure(result.Errors);
    }
}