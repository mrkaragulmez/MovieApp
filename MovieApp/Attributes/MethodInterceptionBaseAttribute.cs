using Castle.DynamicProxy;
using System;
using System.Diagnostics;

namespace MovieApp.Attributes
{
    [AttributeUsage(validOn: AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; }
        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}
