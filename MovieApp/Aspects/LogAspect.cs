using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;
using MovieApp.Interceptions;
using System;
using System.Diagnostics;

namespace MovieApp.Aspects
{
    public class LogAspect : MethodInterception
    {
        public override void OnSuccess(IInvocation invocation)
        {
            //_logger.LogInformation(invocation.Method.Name, invocation.ReturnValue);
        }
        public override void OnException(IInvocation invocation, Exception ex)
        {
            //_logger.LogError(ex.Message, invocation.ReturnValue);
        }
    }
}
