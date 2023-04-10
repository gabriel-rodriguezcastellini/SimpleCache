namespace SimpleCache;

public interface ICacheService
{
    bool Set<T>(string key, T value) where T : class;
    T Get<T>(string key) where T : class;
    bool Remove(string key);
}
