using Microsoft.Extensions.Caching.Memory;

namespace SimpleCache;

public class CacheService : ICacheService
{
    private readonly IMemoryCache _cache;    

    public CacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public T Get<T>(string key) where T : class
    {
        try
        {
            var itemInCache = _cache.TryGetValue<T>(key, out T value);
            return itemInCache ? value : throw new Exception($"Item is not in cache, key {key}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception getting cache item, {e.Message}");
            return null!;
        }
    }

    public bool Remove(string key)
    {
        try
        {            
            if (_cache.TryGetValue(key, out object _))
            {
                _cache.Remove(key);
                return true;
            }

            Console.WriteLine($"Item not present in cache, key: {key}");
            return false;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception getting cache item, {e.Message}");
            return false;
        }        
    }

    public bool Set<T>(string key, T value) where T : class
    {
        try
        {
            _cache.Set(key, value);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine($"Exception trying to set a new cache item, key: {key}, value: {value}, exception: {e.Message}");
            return false;
        }
    }
}
