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
    protected readonly IMapper _mapper;

    public BaseApiController(IMapper mapper = null)
    {
        _mapper = mapper;
    }

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

    protected ActionResult CreateResponse(Result result, Func<ActionResult> onSuccess = null, Func<List<IError>, ActionResult> onFailure = null)
    {
        if (onSuccess is null) onSuccess = Ok;
        if (onFailure is null) onFailure = CreateErrorResponse;

        if (result.IsSuccess)
        {
            return onSuccess();
        }
        return onFailure(result.Errors);
    }

    protected ActionResult CreateResponse<T>(Result<T> result, Func<T, ActionResult> onSuccess = null, Func<List<IError>, ActionResult> onFailure = null)
        where T : class
    {
        if (onSuccess is null) onSuccess = Ok;
        if (onFailure is null) onFailure = CreateErrorResponse;

        if (result.IsSuccess)
        {
            return onSuccess(result.Value);
        }
        return onFailure(result.Errors);
    }

    protected ActionResult CreateResponse<TIn, TOut>(Result<TIn> result, Func<TOut, ActionResult> onSuccess = null, Func<List<IError>, ActionResult> onFailure = null)
        where TOut : class
    {
        if (onSuccess is null) onSuccess = Ok;
        if (onFailure is null) onFailure = CreateErrorResponse;

        if (result.IsSuccess)
        {
            return onSuccess(_mapper.Map<TOut>(result.Value));
        }
        return onFailure(result.Errors);
    }

    protected ActionResult CreateResponse<TIn, TOut>(Result<List<TIn>> result, Func<List<TOut>, ActionResult> onSuccess = null, Func<List<IError>, ActionResult> onFailure = null)
        where TIn : class
    {
        if (onSuccess is null) onSuccess = Ok;
        if (onFailure is null) onFailure = CreateErrorResponse;

        if (result.IsSuccess)
        {
            return onSuccess(result.Value.Select(_mapper.Map<TOut>).ToList());
        }
        return onFailure(result.Errors);
    }

    protected ActionResult CreateResponse<TIn, TOut>(Result<PagedResult<TIn>> result, Func<PagedResult<TOut>, ActionResult> onSuccess = null, Func<List<IError>, ActionResult> onFailure = null)
        where TIn : class
    {
        if (onSuccess is null) onSuccess = Ok;
        if (onFailure is null) onFailure = CreateErrorResponse;

        if (result.IsSuccess)
        {
            var items = result.Value.Results.Select(_mapper.Map<TOut>).ToList();
            return onSuccess(new PagedResult<TOut>(items, result.Value.TotalCount));
        }
        return onFailure(result.Errors);
    }
}