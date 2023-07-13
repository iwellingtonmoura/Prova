using System;
using MongoDB.Driver;
using Prova.Data.Models;
using Prova.Data.Atrributes;
using Prova.Exceptions;

namespace Prova.Extensions
{
	public static class IMongoDatabaseExtensions
	{
		public static IMongoCollection<TEntity> GetCollection<TEntity>(this IMongoDatabase database) where TEntity : IEntity
		{
			string text = CollectionName<TEntity>();
			return database.GetCollection<TEntity>(text) ?? throw new CollectionNaoEncontradaException(text);
		}


		public static Task DropCollectionAsync<TEntity>(this IMongoDatabase database) where TEntity : IEntity

		{

			return database.DropCollectionAsync(CollectionName<TEntity>());
		}

		private static string CollectionName<TEntity>() where TEntity : IEntity
		{

            CollectionAttribute? collectionAttribute = typeof(TEntity)!.GetCustomAttributes(typeof(CollectionAttribute), inherit: true).FirstOrDefault() as CollectionAttribute;

			if (collectionAttribute == null)
			{
				return typeof(TEntity)!.Name;
			}

			return collectionAttribute.CollectionName;
		}
	}
}

