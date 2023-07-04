using System;
using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Prova.Data.DTO.Request;
using Prova.Data.DTO.Response;
using Prova.Data.Models;
using Prova.Data.Repositories;
using Prova.DataManager;
using Prova.Entity;

namespace Prova.Controllers;

[Route("api/[Controller]")]
[ApiController]

public class NotaFiscalController : Controller
{
	private readonly ILogger<UsuarioController> _logger;
	private readonly IConfiguration _configuration;
	private readonly ICadastrarNotaFiscalManager _cadastrarNotaFiscalManager;
	private readonly ICadastrarRangeAprovacaoManager _cadastrarRangeAprovacaoManager;


	public NotaFiscalController(ILogger<UsuarioController> logger,
		IConfiguration configuration,
		ICadastrarNotaFiscalManager cadastrarNotaFiscalManager,
		ICadastrarRangeAprovacaoManager cadastrarRangeAprovacaoManager)
	{
		_logger = logger;
		_configuration = configuration;
        _cadastrarNotaFiscalManager = cadastrarNotaFiscalManager;
		_cadastrarRangeAprovacaoManager = cadastrarRangeAprovacaoManager;

	}

	[HttpPost]
	[Route("CadastrarNotaFiscal")]
	[ProducesResponseType(200, Type = typeof(ResponseWrapper<List<Invoice>>))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseOnException))]
	[ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(ResponseOnException))]
	[ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ResponseOnException))]
	[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseOnException))]

	public async Task<ApiResponse> CadastrarUsuario(Invoice invoice)
	{
		if (!ModelState.IsValid)
		{
			throw new ApiException(ModelState.AllErrors());
		}
		else
		{
			try
			{
				return new ApiResponse( await _cadastrarNotaFiscalManager.CadastrarNotaFiscalAsync(invoice), StatusCodes.Status200OK);
			}
			catch (ApiException ex)
			{
				_logger.LogDebug(ex, ex.Message);
				throw;

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw new ApiException(ex);
			}
		}
	}


    [HttpPost]
    [Route("CadastrarRangeAprovacao")]
    [ProducesResponseType(200, Type = typeof(ResponseWrapper<List<ApprovalRange>>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseOnException))]
    [ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(ResponseOnException))]
    [ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ResponseOnException))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseOnException))]

    public async Task<ApiResponse> CadastrarRangeAprovacao(ApprovalRange approvalRange)
    {
        if (!ModelState.IsValid)
        {
            throw new ApiException(ModelState.AllErrors());
        }
        else
        {
            try
            {
                return new ApiResponse(await _cadastrarRangeAprovacaoManager.CadastrarRangeAprovacaoAsync(approvalRange), StatusCodes.Status200OK);
            }
            catch (ApiException ex)
            {
                _logger.LogDebug(ex, ex.Message);
                throw;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw new ApiException(ex);
            }
        }
    }


}

