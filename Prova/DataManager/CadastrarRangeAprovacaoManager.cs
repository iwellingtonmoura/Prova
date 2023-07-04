using System;
using System.Threading.Tasks;
using Prova.Data.Repositories;
using Prova.Entity;

namespace Prova.DataManager;

public interface ICadastrarRangeAprovacaoManager
{
    Task<ApprovalRange> CadastrarRangeAprovacaoAsync(ApprovalRange approvalRange);
}

public class CadastrarRangeAprovacaoManager : ICadastrarRangeAprovacaoManager
{
		private readonly IMongoRepository _mongoRepository;

		public CadastrarRangeAprovacaoManager(IMongoRepository mongoRepository)
		{
        _mongoRepository = mongoRepository;
    }

    public async Task<ApprovalRange> CadastrarRangeAprovacaoAsync(ApprovalRange approvalRange)
    {

        return await _mongoRepository.InserirRangeAprovacaoAsync(approvalRange);

    }

}

