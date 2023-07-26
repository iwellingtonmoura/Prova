using System.Formats.Asn1;
using AutoWrapper.Wrappers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace Prova.Services;

public interface ICacheRedis
{
    Task InserirDadosCacheRedis<T>(T document, string? Nome);
    Task<string?> RetornarDadosCacheRedis<T>(string chave);
}
public class CacheRedisService : ICacheRedis
{

    private readonly IDistributedCache _distributedCache;
    private readonly ILogger<CacheRedisService> _logger;

    public CacheRedisService(IDistributedCache distributedCache, ILogger<CacheRedisService> logger)
    {
        _distributedCache = distributedCache;
        _logger = logger;
    }

    public async Task InserirDadosCacheRedis<T>(T document, string? Nome)
    {
        try
        {
            await _distributedCache.SetStringAsync($"USUARIO_LOGIN:{Nome}", JsonConvert.SerializeObject(document),
                options: new DistributedCacheEntryOptions { AbsoluteExpiration = DateTimeOffset.Now.AddHours(8) });
        }
        catch (ApiException ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new ApiException(ex);
        }
    }

    public async Task<string?> RetornarDadosCacheRedis<T>(string chave)
    {
        return await _distributedCache.GetStringAsync(chave);
    }

}


