using System;
using System.Threading.Tasks;
using Prova.Data.Interfaces;
using Prova.Entity;
using Prova.Services;

namespace Prova.DataManager;

public interface ICadastrarRangeAprovacaoManager
{
    //Task<ApprovalRange> CadastrarRangeAprovacaoAsync(ApprovalRange approvalRange);
}

public class CadastrarRangeAprovacaoManager : ICadastrarRangeAprovacaoManager
{
		private readonly IMongoDbRepository<ProvaConfiguration> _mongoRepository;

		public CadastrarRangeAprovacaoManager(IMongoDbRepository<ProvaConfiguration> mongoRepository)
		{
        _mongoRepository = mongoRepository;
    }

    //public async Task<ApprovalRange> CadastrarRangeAprovacaoAsync(ApprovalRange approvalRange)
    //{

    //    return await _mongoRepository.InserirRangeAprovacaoAsync(approvalRange);

    //}

}

