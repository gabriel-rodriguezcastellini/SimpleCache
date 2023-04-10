# Simple Cache
This service is used to cache any item with a key identifier.
I've implemented `ICacheService` interface, there are three functions in this interface:
```
public interface ICacheService
{
    bool Set<T>(string key, T value) where T : class;
    T Get<T>(string key) where T : class;
    bool Remove(string key);
}
```
Keep in mind the following:
 - Cache service is **thread-safe**
 - **Error handling** is considered 
 - I've used **Microsoft Dependency Injection** to initialize implementation of `ICacheService`
 -  `Program.cs`: From line 14 till end file are the tests to confirm implementation.

```mermaid
graph LR
A[Thread A] -- Set Item `KEY_A` ---> S(ICacheService)
B[Thread B] -- Set Item `KEY_B` ---> S
C[Thread C] -- Get Item `KEY_B` ---> S
D[Thread D] -- Remove Item `KEY_A` ---> S
```

## Status (GitHub Actions)

[![.NET](https://github.com/gabriel-rodriguezcastellini/SimpleCache/actions/workflows/dotnet.yml/badge.svg)](https://github.com/gabriel-rodriguezcastellini/SimpleCache/actions/workflows/dotnet.yml) [![CodeQL](https://github.com/gabriel-rodriguezcastellini/SimpleCache/actions/workflows/codeql.yml/badge.svg)](https://github.com/gabriel-rodriguezcastellini/SimpleCache/actions/workflows/codeql.yml)
