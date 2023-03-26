using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Tutor.Web.Extensions
{
    public static class ResultToResponseExtensions
    {
        // return result.CreateResponse(Ok, CreateErrorResponse);
        public static ActionResult CreateResponse (
            this Result result, 
            Func<ActionResult> onSuccess, Func<List<IError>, ActionResult> onFailure)
        {
            return result.IsSuccess ? onSuccess() : onFailure(result.Errors);
        }

        public static ActionResult CreateResponse<T>(
            this Result<T> result,
            Func<T, ActionResult> onSuccess, Func<List<IError>, ActionResult> onFailure)
        {
            return result.IsSuccess ? onSuccess(result.Value) : onFailure(result.Errors);
        }
    }
}
