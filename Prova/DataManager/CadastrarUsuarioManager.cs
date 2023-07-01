using System;
using Prova.Data.DTO.Request;
using Prova.Data.Repositories;
using Prova.Entity;

namespace Prova.DataManager;

public interface ICadastrarUsuarioManager
{
    Task<User> CadastrarUsuarioAsync(User user);
    Task AtualizarUsuarioAsync(User user);
}


public class CadastrarUsuarioManager : ICadastrarUsuarioManager
{

    private readonly IMongoRepository _mongoRepository;

    public CadastrarUsuarioManager(IMongoRepository mongoRepository)
    {
        _mongoRepository = mongoRepository;
    }


    public async Task<User> CadastrarUsuarioAsync(User user)
    {

        return await _mongoRepository.InserirUsuarioAsync(user);

    }

    public async Task AtualizarUsuarioAsync(User user)
    {

        await _mongoRepository.AtualizarUsuarioAsync(user, user.Id);

    }
}

