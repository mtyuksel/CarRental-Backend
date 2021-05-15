
namespace CarRental.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key);
        object Get(string key);
        void Add(string key, object value, int duration);
        bool IsAdded(string key);
        void Remove(string key);
        void RemoveByPattern(string pattern);
    }
}
