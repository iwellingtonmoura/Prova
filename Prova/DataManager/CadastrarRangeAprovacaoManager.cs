using System;
using System.Threading.Tasks;
using AutoWrapper.Wrappers;
using MongoDB.Driver;
using Prova.Data.Interfaces;
using Prova.Entity;
using Prova.Services;

namespace Prova.DataManager;

public interface ICadastrarRangeAprovacaoManager
{
    Task<List<ApprovalRange>> CadastrarRangeAprovacaoAsync(ApprovalRange approvalRange);
}

public class CadastrarRangeAprovacaoManager : ICadastrarRangeAprovacaoManager
{
		private readonly IMongoDbRepository<ProvaConfiguration> _mongoDbRepository;
        private readonly ILogger<ApprovalRange> _logger;

		public CadastrarRangeAprovacaoManager(IMongoDbRepository<ProvaConfiguration> mongoDbRepository, ILogger<ApprovalRange> logger)
		{
        _mongoDbRepository = mongoDbRepository;
        _logger = logger;
    }

    public async Task<List<ApprovalRange>> CadastrarRangeAprovacaoAsync(ApprovalRange approvalRange)
    {
        try
        {
            await _mongoDbRepository.GetCollection<ApprovalRange>().InsertOneAsync(approvalRange);
            List<ApprovalRange> approvalRanges = _mongoDbRepository.GetCollection<ApprovalRange>().AsQueryable().Select(u => u).ToList();
            return approvalRanges;

        }
        catch (ApiException ex)
        {
            _logger.LogError(ex, ex.Message);
            throw new ApiException(ex);

        }

    }

}

