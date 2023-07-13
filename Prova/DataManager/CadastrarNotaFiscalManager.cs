using System;
using System.Threading.Tasks;
using Prova.Data.Interfaces;
using Prova.Entity;
using Prova.Services;

namespace Prova.DataManager;

public interface ICadastrarNotaFiscalManager
{
    //Task<Invoice> CadastrarNotaFiscalAsync(Invoice invoice);
    Task AtualizarNotaFiscalAsync(Invoice invoice);
}

public class CadastrarNotaFiscalManager : ICadastrarNotaFiscalManager
{
    private readonly IMongoDbRepository<ProvaConfiguration> _mongoRepository;

    public CadastrarNotaFiscalManager(IMongoDbRepository<ProvaConfiguration> mongoRepository)
    {
        _mongoRepository = mongoRepository;
    }

    //public async Task<Invoice> CadastrarNotaFiscalAsync(Invoice invoice)
    //{

    //    //return await _mongoRepository.InserirNotaFiscalAsync(invoice);

    //}

    public async Task AtualizarNotaFiscalAsync(Invoice invoice)
    {

        //await _mongoRepository.AtualizarNotaFiscalAsync(invoice, invoice.Id);

    }

}

