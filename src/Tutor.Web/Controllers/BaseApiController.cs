using FluentResults;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;

namespace Tutor.Web.Controllers
{
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected ActionResult CreateErrorResponse(List<IError> errors)
        {
            var code = 500;
            if (errors.Contains(FailureCode.NoActiveEnrollment)) code = 403;
            if (errors.Contains(FailureCode.NoKnowledgeComponent)) code = 404;
            if (errors.Contains(FailureCode.NoAssessmentItem)) code = 404;
            if (errors.Contains(FailureCode.InvalidAssessmentSubmission)) code = 400;
            return Problem(statusCode: code, detail: string.Join(";", errors));
        }
    }
}
