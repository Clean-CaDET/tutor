using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using Tutor.Core.BuildingBlocks;
using Castle.DynamicProxy;
using FluentResults;
using System;

namespace Tutor.Infrastructure.Interceptors
{
    public class LoggingInterceptor : IInterceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            invocation.Proceed();
            try
            {
                dynamic result = invocation.ReturnValue;
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Call: {@Class}.{@Method}. Ok.", 
                        invocation.TargetType, invocation.Method.Name);
                }
                else
                {
                    var errors = (List<IError>)result.Errors;
                    _logger.LogWarning("Call: {@Class}.{@Method}. Fail: {@Errors}.",
                        invocation.TargetType, invocation.Method.Name, errors);
                }
            }
            catch (Exception e)
            {
                Error rootError = new Error(e.Message).CausedBy(e);
                var result = Result.Fail(FailureCode.InternalServerError).WithError(rootError);
                invocation.ReturnValue = result;
                _logger.LogError("Call: {@Class}.{@Method}. Error: {@Errors}.",
                    invocation.TargetType, invocation.Method.Name, result.Errors);
            }
        }
    }
}
