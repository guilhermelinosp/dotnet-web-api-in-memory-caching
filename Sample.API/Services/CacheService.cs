using System.Runtime.Caching;

namespace Sample.API.Services
{
    public class CacheService : ICacheService
    {
        private readonly ObjectCache _cache;

        public CacheService(ObjectCache cache)
        {
            _cache = cache;
        }

        public T? Get<T>(string key)
        {
            try
            {
                return (T)_cache.Get(key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Set<T>(string key, T value, DateTimeOffset expirationTime)
        {
            try
            {
                if(!string.IsNullOrEmpty(key)) _cache.Set(key, value, expirationTime);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Remove(string key)
        {
            try
            {
                if(!string.IsNullOrEmpty(key)) _cache.Remove(key);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
