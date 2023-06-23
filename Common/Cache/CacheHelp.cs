using System;
using System.Runtime.Caching;

public class CacheHelper
{
    private MemoryCache _cache = MemoryCache.Default;

    public CacheHelper()
    {
        AddItem("admin", "/WeatherForecast");
        AddItem("anonymous", "/Login");
    }
    
    public void AddItem(string key, object value, DateTimeOffset? absoluteExpiration = null)
    {
        if (absoluteExpiration == null)
        {
            absoluteExpiration = ObjectCache.InfiniteAbsoluteExpiration;
        }

        CacheItemPolicy policy = new CacheItemPolicy
        {
            AbsoluteExpiration = absoluteExpiration.Value
        };

        _cache.Add(key, value, policy);
    }

    public object GetItem(string key)
    {
        return _cache.Get(key);
    }

    public void RemoveItem(string key)
    {
        _cache.Remove(key);
    }
}