using CarRental.Core.Aspects.Autofac.Caching;
using Castle.DynamicProxy;
using System;
using System.Linq;
using System.Reflection;

namespace CarRental.Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            //classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger)));

            if (method.Name.ToLower().Contains("delete") || method.Name.ToLower().Contains("update"))
            {
                string methodFullName = method.ReflectedType.FullName;
                var methodName = string.Format($"{methodFullName.Substring(0, methodFullName.IndexOf("`1"))}" + ".Get");

                classAttributes.Add(new CacheRemoveAspect(methodName));
            }

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}
