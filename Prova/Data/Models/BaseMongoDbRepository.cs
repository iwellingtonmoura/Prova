using System;
using MongoDB.Driver;
using Prova.Data.Interfaces;
using Prova.Extensions;

namespace Prova.Data.Models
{
	public class BaseMongoDbRepository<TConfiguration> : IMongoDbRepository<TConfiguration> where TConfiguration : IDatabaseConfiguration
	{
		public IMongoDatabase Database { get; private set; }

		public BaseMongoDbRepository(TConfiguration configuration)
		{
			Database = configuration.ConnectAndGetDatabase();
		}

		public IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : IEntity
		{

			return Database.GetCollection<TEntity>();
		}
	}
}

