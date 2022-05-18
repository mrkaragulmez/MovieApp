using Castle.DynamicProxy;
using MovieApp.Attributes;
using System;
using System.Diagnostics;

namespace MovieApp.Interceptions
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {
        private Stopwatch _stopwatch;
        public MethodInterception()
        {
            _stopwatch = new Stopwatch();
        }
        public virtual void OnBefore(IInvocation invocation) => _stopwatch.Start();
        public virtual void OnAfter(IInvocation invocation) 
        {
            _stopwatch.Stop();
            Debug.WriteLine($"Done : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            _stopwatch.Reset();
        }
        public virtual void OnException(IInvocation invocation, Exception e) 
        { 
            Debug.WriteLine($"OnException : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
            Debug.WriteLine(e);
        }
        public virtual void OnSuccess(IInvocation invocation) 
        {
            Debug.WriteLine($"OnSuccess : {invocation.Method.DeclaringType.FullName}.{invocation.Method.Name}-->{_stopwatch.Elapsed.TotalSeconds}");
        }
        public override void Intercept(IInvocation invocation) 
        {
            var isSuccsess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccsess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccsess)
                {
                    OnSuccess(invocation);
                }
            }

            OnAfter(invocation);
        }
    }
}
