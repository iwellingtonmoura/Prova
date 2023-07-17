using System;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using MongoDB.Driver;
using Prova.Data.Interfaces;
using Prova.Entity;
using Prova.Interfaces;
using Prova.Services;

namespace Prova.DataManager;

public interface ICadastrarNotaFiscalManager
{
    Task<List<Invoice>> CadastrarNotaFiscalAsync(Invoice invoice);
    Task AtualizarNotaFiscalAsync(Invoice invoice);
}

public class CadastrarNotaFiscalManager : ICadastrarNotaFiscalManager
{
    private readonly IMongoDbRepository<ProvaConfiguration> _mongoDbRepository;
    private readonly ILogger<Invoice> _logger;

    public CadastrarNotaFiscalManager(IMongoDbRepository<ProvaConfiguration> mongoDbRepository, ILogger<Invoice> logger)
    {
        _mongoDbRepository = mongoDbRepository;
        _logger = logger;
    }

    public async Task<List<Invoice>> CadastrarNotaFiscalAsync(Invoice invoice)
    {
        try
        {
            await _mongoDbRepository.GetCollection<Invoice>().InsertOneAsync(invoice);
            List<Invoice> invoices = _mongoDbRepository.GetCollection<Invoice>().AsQueryable().Select(u => u).ToList();
            return invoices;
        }
        catch (ApiException ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new ApiException(ex);
        }
    }

    public async Task AtualizarNotaFiscalAsync(Invoice invoice)
    {
        try
        {
            await _mongoDbRepository.GetCollection<Invoice>().ReplaceAsync(invoice, invoice.Id);
    
        }
        catch (ApiException ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new ApiException(ex);
        }
        

    }

}

