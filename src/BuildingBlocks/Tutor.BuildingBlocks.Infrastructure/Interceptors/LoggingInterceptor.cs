using FluentResults;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using Tutor.BuildingBlocks.Core.UseCases;
using System.Dynamic;

namespace Tutor.BuildingBlocks.Infrastructure.Interceptors;

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
            if (!PropertyExists(result, "IsSuccess") || result.IsSuccess)
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
            var result = Result.Fail(FailureCode.Internal).WithError(rootError);
            invocation.ReturnValue = result;
            _logger.LogError("Call: {@Class}.{@Method}. Error: {@Errors}.",
                invocation.TargetType, invocation.Method.Name, result.Errors);
        }
    }

    private static bool PropertyExists(dynamic invocationResult, string  propertyName)
    {
        if (invocationResult is ExpandoObject)
            return ((IDictionary<string, object>)invocationResult).ContainsKey(propertyName);

        return invocationResult.GetType().GetProperty(propertyName) != null;
    }
}
