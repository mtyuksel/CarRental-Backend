using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace CarRental.Core.CrossCuttingConcerns.Caching.Redis
{
    public class RedisCacheManager : ICacheManager
    {
        private IConnectionMultiplexer _connectionMultiplexer;

        public RedisCacheManager(IConnectionMultiplexer connectionMultiplexer)
        {
            this._connectionMultiplexer = connectionMultiplexer;
        }

        public void Add(string key, object value, int duration)
        {
            var db = _connectionMultiplexer.GetDatabase();
            db.StringSet(key, JsonConvert.SerializeObject(value), TimeSpan.FromMinutes(duration));
        }

        public T Get<T>(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return JsonConvert.DeserializeObject<T>(db.StringGet(key));
        }

        public object Get(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return JsonConvert.DeserializeObject<object>(db.StringGet(key));
        }

        public bool IsAdded(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            return db.KeyExists(key);
        }

        public void Remove(string key)
        {
            var db = _connectionMultiplexer.GetDatabase();
            db.KeyDelete(key);
        }

        public void RemoveByPattern(string pattern)
        {
            throw new NotImplementedException();
        }
    }
}
