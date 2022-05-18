using Castle.DynamicProxy;
using MovieApp.Aspects;
using MovieApp.Attributes;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MovieApp.Interceptions
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(System.Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            List<MethodInterceptionBaseAttribute> classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();
            IEnumerable<MethodInterceptionBaseAttribute> methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderByDescending(x => x.Priority).ToArray();
        }
    }
}
