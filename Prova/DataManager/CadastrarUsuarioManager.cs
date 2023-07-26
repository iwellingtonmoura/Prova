
using AutoWrapper.Wrappers;
using AsyncAwaitBestPractices;
using Dasync.Collections;
using MongoDB.Driver;
using Prova.Data.DTO.Request;
using Prova.Data.Interfaces;
using Prova.Entity;
using Prova.Interfaces;
using Prova.Services;
using MongoDB.Bson.IO;
using Newtonsoft.Json;

namespace Prova.DataManager;

public interface ICadastrarUsuarioManager
{
    Task<List<User>> CadastrarUsuarioAsync(User user);
    Task AtualizarUsuarioAsync(User user);
}


public class CadastrarUsuarioManager : ICadastrarUsuarioManager
{
    private readonly IMongoDbRepository<ProvaConfiguration> _mongoDbRepository;
    private readonly ILogger<CadastrarUsuarioManager> _logger;
    private readonly ICacheRedis _cacheRedis;

    public CadastrarUsuarioManager(
        IMongoDbRepository<ProvaConfiguration> mongoDbRepository,
        ILogger<CadastrarUsuarioManager> logger,
        ICacheRedis cacheRedis)
    {
        _mongoDbRepository = mongoDbRepository;
        _logger = logger;
        _cacheRedis = cacheRedis;
    }

    public async Task<List<User>> CadastrarUsuarioAsync(User user)
    {
        try
        {
            await _mongoDbRepository.GetCollection<User>().InsertOneAsync(user);

            List<User> users = _mongoDbRepository.GetCollection<User>().AsQueryable().Select(u => u).ToList();

            //Criado somente para testar o cache
            if (users.Any())
            {
                await users.ParallelForEachAsync
                    (

                            async item =>
                            {
                                var retornoUsuario = await _cacheRedis.RetornarDadosCacheRedis<User>($"USUARIO_LOGIN:{item.Login}");

                                if (string.IsNullOrEmpty(retornoUsuario))
                                {
                                    await _cacheRedis.InserirDadosCacheRedis<User>(item, item.Login);
                                }

                            }, maxDegreeOfParallelism: 1
                     ); ;

            }

            return users;
        }
        catch (ApiException ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new ApiException(ex);
        }
    }

    public async Task AtualizarUsuarioAsync(User user)
    {

        try
        {
            await _mongoDbRepository.GetCollection<User>().ReplaceAsync(user, user.Id);
        }
        catch (ApiException ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new ApiException(ex);
        }

    }
}

