
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
    Task CadastrarUsuarioAsync(User user);
    Task AtualizarUsuarioAsync(User user);
}


public class CadastrarUsuarioManager : ICadastrarUsuarioManager
{
    private readonly IMongoDbRepository<ProvaConfiguration> _mongoDbRepository;
    private readonly ILogger<CadastrarUsuarioManager> _logger;

    public CadastrarUsuarioManager(
        IMongoDbRepository<ProvaConfiguration> mongoDbRepository,
        ILogger<CadastrarUsuarioManager> logger)
    {
        _mongoDbRepository = mongoDbRepository;
        _logger = logger;
    }


    public async Task CadastrarUsuarioAsync(User user)
    {
        try
        {
             await _mongoDbRepository.GetCollection<User>().InsertAsync(user);
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

