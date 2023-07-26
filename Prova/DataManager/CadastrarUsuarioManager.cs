
using AutoWrapper.Wrappers;
using MongoDB.Driver;
using Prova.Data.DTO.Request;
using Prova.Data.Interfaces;
using Prova.Entity;
using Prova.Interfaces;
using Prova.Services;

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
             await _cacheRedis.InserirDadosCacheRedis<User>(user, user.Login);

             await _mongoDbRepository.GetCollection<User>().InsertOneAsync(user);

            List<User> users = _mongoDbRepository.GetCollection<User>().AsQueryable().Select(u => u).ToList();
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

