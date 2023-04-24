using System;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using AutoMapper;
using System.Linq;

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

    protected ActionResult CreateResponse<T, P>(Result<T> result, Func<P, ActionResult> onSuccess, Func<List<IError>, ActionResult> onFailure, IMapper mapper)
    {
        if (result.IsSuccess)
        {
            return onSuccess(mapper.Map<P>(result.Value));
        }
        return onFailure(result.Errors);
    }

    protected ActionResult CreateResponse<T, P>(Result<List<T>> result, Func<List<P>, ActionResult> onSuccess, Func<List<IError>, ActionResult> onFailure, IMapper mapper)
        where T : class
    {
        if (result.IsSuccess)
        {
            return onSuccess(result.Value.Select(mapper.Map<P>).ToList());
        }
        return onFailure(result.Errors);
    }

    protected ActionResult CreateResponse<T, P>(Result<PagedResult<T>> result, Func<PagedResult<P>, ActionResult> onSuccess, Func<List<IError>, ActionResult> onFailure, IMapper mapper)
        where T : class
    {
        if (result.IsSuccess)
        {
            var items = result.Value.Results.Select(mapper.Map<P>).ToList();
            return onSuccess(new PagedResult<P>(items, result.Value.TotalCount));
        }
        return onFailure(result.Errors);
    }
}