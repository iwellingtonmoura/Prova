using System;
using MongoDB.Driver;
using Prova.Data.Models;
using Prova.Exceptions;

namespace Prova.Extensions
{
	public static class IDatabaseConfigurationExtensions
	{
		public static IMongoDatabase ConnectAndGetDatabase(this IDatabaseConfiguration databaseConfiguration) {

			return new MongoClient(databaseConfiguration.ConnectionString).GetDatabase(databaseConfiguration.DatabaseName) ?? throw new DataBaseNaoEncontradoException(databaseConfiguration.DatabaseName);
		}
	}
}

