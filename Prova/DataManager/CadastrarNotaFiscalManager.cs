using System;
using System.Threading.Tasks;
using Prova.Data.Repositories;
using Prova.Entity;

namespace Prova.DataManager;

public interface ICadastrarNotaFiscalManager
{
    Task<Invoice> CadastrarNotaFiscalAsync(Invoice invoice);
    Task AtualizarNotaFiscalAsync(Invoice invoice);
}

public class CadastrarNotaFiscalManager : ICadastrarNotaFiscalManager
	{
		private readonly IMongoRepository _mongoRepository;

		public CadastrarNotaFiscalManager(IMongoRepository mongoRepository)
		{
        _mongoRepository = mongoRepository;
    }

    public async Task<Invoice> CadastrarNotaFiscalAsync(Invoice invoice)
    {

        return await _mongoRepository.InserirNotaFiscalAsync(invoice);

    }

    public async Task AtualizarNotaFiscalAsync(Invoice invoice)
    {

        await _mongoRepository.AtualizarNotaFiscalAsync(invoice, invoice.Id);

    }

}

