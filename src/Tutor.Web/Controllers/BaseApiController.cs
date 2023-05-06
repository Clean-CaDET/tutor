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
        if (errors.Contains(FailureCode.DuplicateUsername)) code = 400;
        if (errors.Contains(FailureCode.InvalidUserType)) code = 400;
        return Problem(statusCode: code, detail: string.Join(";", errors));
    }

    protected ActionResult CreateResponse(Result result)
    {
        if (result.IsSuccess)
        {
            return Ok();
        }
        return CreateErrorResponse(result.Errors);
    }

    protected ActionResult CreateResponse<T>(Result<T> result)
    {
        if (result.IsSuccess)
        {
            return Ok(result.Value);
        }
        return CreateErrorResponse(result.Errors);
    }

    protected ActionResult CreateResponse<TIn, TOut>(Result<TIn> result)
    {
        if (result.IsSuccess)
        {
            return Ok(_mapper.Map<TOut>(result.Value));
        }
        return CreateErrorResponse(result.Errors);
    }

    protected ActionResult CreateResponse<TIn, TOut>(Result<List<TIn>> result)
        where TIn : class
    {
        if (result.IsSuccess)
        {
            return Ok(result.Value.Select(_mapper.Map<TOut>).ToList());
        }
        return CreateErrorResponse(result.Errors);
    }

    protected ActionResult CreateResponse<TIn, TOut>(Result<PagedResult<TIn>> result)
        where TIn : class
    {
        if (result.IsSuccess)
        {
            var items = result.Value.Results.Select(_mapper.Map<TOut>).ToList();
            return Ok(new PagedResult<TOut>(items, result.Value.TotalCount));
        }
        return CreateErrorResponse(result.Errors);
    }
}