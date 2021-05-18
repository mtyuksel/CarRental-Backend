using CarRental.Core.CrossCuttingConcerns.Caching;
using CarRental.Core.CrossCuttingConcerns.Caching.Microsoft;
using CarRental.Core.CrossCuttingConcerns.Caching.Redis;
using CarRental.Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using System.Diagnostics;

namespace CarRental.Core.DependencyResolvers
{
    public class CoreModule : ICoreModule
    {
        IConfiguration _config;

        public CoreModule(IConfiguration config)
        {
            this._config = config;
        }

        public void Load(IServiceCollection serviceCollection)
        {
            serviceCollection.AddMemoryCache();
            serviceCollection.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            //serviceCollection.AddSingleton<IConnectionMultiplexer>(provider =>
            //ConnectionMultiplexer.Connect(_config.GetSection("RedisConnectionString").Value));

            serviceCollection.AddSingleton<ICacheManager, MemoryCacheManager>();
            serviceCollection.AddSingleton<Stopwatch>();
        }
    }
}
