
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using SimpleCache;

var serviceCollection = new ServiceCollection();


serviceCollection.AddSingleton<ICacheService, CacheService>();
serviceCollection.AddMemoryCache();
var serviceProvider = serviceCollection.BuildServiceProvider();
var cacheService = serviceProvider.GetRequiredService<ICacheService>();

//test
var item = new SomeItem();

cacheService.Set("Key1", item);

Debug.Assert(item == cacheService.Get<SomeItem>("Key1"));

cacheService.Remove("Key1");
Debug.Assert(cacheService.Get<SomeItem>("Key1") == null);
