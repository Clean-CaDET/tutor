using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Castle.DynamicProxy;
using FluentResults;
using System;

namespace Tutor.Infrastructure.Interceptors
{
    public class Logging : IInterceptor
    {
        private readonly ILogger<Logging> _logger;

        public Logging(ILogger<Logging> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            _logger.LogDebug("Calling method {@Class}.{@Method}.", 
                invocation.TargetType, invocation.Method.Name);
            invocation.Proceed();
            try
            {
                dynamic result = invocation.ReturnValue;
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Successful execution of method: {@Class}.{@Method}.", 
                        invocation.TargetType, invocation.Method.Name);
                }
                else
                {
                    var errors = (List<IError>)result.Errors;
                    _logger.LogWarning("Unsuccesful execution of method {@Class}.{@Method}, with errors: {@Errors}.",
                        invocation.TargetType, invocation.Method.Name, errors);
                }
            }
            catch (Exception e)
            {
                Error rootError = new Error(e.Message).CausedBy(e);
                var result = Result.Fail(FailureCode.InternalServerError).WithError(rootError);
                invocation.ReturnValue = result;
                _logger.LogError("Exception in execution of method {@Class}.{@Method}, with cause: {@Errors}.",
                    invocation.TargetType, invocation.Method.Name, result.Errors);
            }
        }
    }
}
