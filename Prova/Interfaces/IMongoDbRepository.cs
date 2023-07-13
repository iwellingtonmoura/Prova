using MongoDB.Driver;
using Prova.Data.Models;

namespace Prova.Data.Interfaces;

public interface IMongoDbRepository<TConfiguration> where TConfiguration : IDatabaseConfiguration
{
	IMongoDatabase Database { get; }

	IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : IEntity;
	
}

