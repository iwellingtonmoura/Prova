//using System;
//using Prova.Data.DTO.Response;
//using Prova.Data.Repositories;

//namespace Prova.DataManager;

//public interface IDadosProvaManager
//{
//    Task<ModelExampleRequest> InserirDados(ModelExampleRequest modelExampleRequest);

//}

//public class DadosProvaManager : IDadosProvaManager
//{
//    private readonly IMongoRepository _mongoRepository;


//    public DadosProvaManager(IMongoRepository mongoRepository)
//    {
//        _mongoRepository = mongoRepository;

//    }

//    public async Task<ModelExampleRequest> InserirDados(ModelExampleRequest dadosDoCliente)
//    {

//        return await _mongoRepository.InsereDados(dadosDoCliente);

//    }

//    public async Task AtualizarDados(ModelExampleRequest model)
//    {

//        await _mongoRepository.AtualizarDados(model, model.Id);

//    }

//}

