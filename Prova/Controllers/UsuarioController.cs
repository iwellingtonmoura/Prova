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

public class UsuarioController : Controller
{
	private readonly ILogger<UsuarioController> _logger;
	private readonly IConfiguration _configuration;
	private readonly ICadastrarUsuarioManager _cadastrarUsuarioManager;


	public UsuarioController(ILogger<UsuarioController> logger, IConfiguration configuration, ICadastrarUsuarioManager cadastrarUsuarioManager)
	{
		_logger = logger;
		_configuration = configuration;
        _cadastrarUsuarioManager = cadastrarUsuarioManager;

	}

	[HttpPost]
	[Route("CadastrarUsuario")]
	[ProducesResponseType(200, Type = typeof(ResponseWrapper<List<User>>))]
	[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ResponseOnException))]
	[ProducesResponseType(StatusCodes.Status412PreconditionFailed, Type = typeof(ResponseOnException))]
	[ProducesResponseType(StatusCodes.Status422UnprocessableEntity, Type = typeof(ResponseOnException))]
	[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ResponseOnException))]

	public async Task<ApiResponse> CadastrarUsuario(User user)
	{
		if (!ModelState.IsValid)
		{
			throw new ApiException(ModelState.AllErrors());
		}
		else
		{
			try
			{
				return new ApiResponse( await _cadastrarUsuarioManager.CadastrarUsuarioAsync(user), StatusCodes.Status200OK);
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

