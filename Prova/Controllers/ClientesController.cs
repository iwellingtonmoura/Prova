using System;
using AutoWrapper.Extensions;
using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Prova.Data.DTO.Request;
using Prova.Data.DTO.Response;
using Prova.Data.Models;
using Prova.Data.Repositories;
using Prova.DataManager;

namespace Prova.Controllers;

[Route("api /[Controller]")]
[ApiController]

public class ClientesController : Controller
{
	private readonly ILogger<ClientesController> _logger;
	private readonly IConfiguration _configuration;
	private readonly IDadosProvaManager _dadosProvaManager;


	public ClientesController(ILogger<ClientesController> logger, IConfiguration configuration, IDadosProvaManager dadosProvaManager)
	{
		_logger = logger;
		_configuration = configuration;
		_dadosProvaManager = dadosProvaManager;

	}

	[HttpPost]
	[Route("InserirClientes")]
	[ProducesResponseType(200, Type = typeof(ResponseWrapper<List<ModelExampleResponse>>))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseOnException))]
	[ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(ResponseOnException))]
	[ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ResponseOnException))]
	[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseOnException))]

	public async Task<ApiResponse> InserirClientes(ModelExampleRequest exempleRequest)
	{
		if (!ModelState.IsValid)
		{
			throw new ApiException(ModelState.AllErrors());
		}
		else
		{
			try
			{
				return new ApiResponse( await _dadosProvaManager.InserirDados(exempleRequest), StatusCodes.Status200OK);
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

