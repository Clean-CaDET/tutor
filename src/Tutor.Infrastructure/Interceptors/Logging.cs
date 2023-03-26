using Microsoft.Extensions.Logging;
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
            _logger.LogDebug($"Calling method {invocation.TargetType}.{invocation.Method.Name}.");
            invocation.Proceed();
            try
            {
                dynamic result = invocation.ReturnValue;
                if (result.IsSuccess)
                {
                    _logger.LogInformation("Successful execution of method");
                }
                else
                {
                    _logger.LogWarning("Unsuccesful execution of method + errors");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Unexpected exception happened, handling it + creating FluentResult error for end user");
                Error rootError = new Error(e.Message).CausedBy(e);
                invocation.ReturnValue = Result.Fail(FailureCode.InternalServerError).WithError(rootError);
            }
        }
    }
}
