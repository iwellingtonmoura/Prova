using System;
using FluentValidation;
using FluentValidation.AspNetCore;
using Prova.Data.Interfaces;
using Prova.Data.Models;
using Prova.DataManager;
using Prova.Services;

namespace Prova.Extensions
{
	public  static class ProvaExtensions
	{

		public static void AddProvaWorker (this IServiceCollection services, IConfiguration configuration)
		{
			services.AddScoped(_ =>
			{

				var dataBaseConfiguration = new ProvaConfiguration(

				configuration["ParametrosProva:ConnectionString"]!,
				configuration["ParametrosProva:DatabaseName"]!);

				return dataBaseConfiguration;
			});

			// Add DI

			services.AddScoped<IMongoDbRepository<ProvaConfiguration>, BaseMongoDbRepository<ProvaConfiguration>>();
			//services.AddValidatorsFromAssemblyContaining(ModelExampleRequest);


            #region managers

            services.AddScoped<ICadastrarUsuarioManager, CadastrarUsuarioManager>();
            services.AddScoped<ICadastrarNotaFiscalManager, CadastrarNotaFiscalManager>();
            services.AddScoped<ICadastrarRangeAprovacaoManager, CadastrarRangeAprovacaoManager>();

            #endregion

        }

    }
}

