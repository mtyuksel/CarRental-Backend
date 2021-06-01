using CarRental.Core.CrossCuttingConcerns.Caching;
using CarRental.Core.Utilities.Interceptors;
using CarRental.Core.Utilities.IoC;
using Castle.DynamicProxy;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CarRental.Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            string proxyName = invocation.Proxy.ToString();
            string serviceInterfaceName = proxyName.Split('.').Last().Replace("Proxy", "");
            var methodName = string.Format($"{serviceInterfaceName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";

            if (_cacheManager.IsAdded(key))
            {
                var test = _cacheManager.Get(key);
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }

            invocation.Proceed();

            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
