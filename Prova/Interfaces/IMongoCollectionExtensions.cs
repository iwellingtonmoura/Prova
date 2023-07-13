using System;
using System.Linq.Expressions;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using Prova.Data.Models;

namespace Prova.Interfaces;

public static class IMongoCollectionExtensions
{
	public static async Task<TEntity?> FindAsync<TEntity>(this IMongoCollection<TEntity> collection, Expression<Func<TEntity, bool>> predicate) where TEntity : IEntity
	{
		return await collection.AsQueryable().Where(predicate).FirstOrDefaultAsync();
	}

	public static async Task<IEnumerable<TEntity>> ListAsync<TEntity>(this IMongoCollection<TEntity> collection, Expression<Func<TEntity, bool>>? predicate) where TEntity : IEntity
	{
		return (predicate == null) ? (await collection.AsQueryable().ToListAsync()) : (await collection.AsQueryable().Where(predicate).ToListAsync());

	}

	public static async Task InsertAsync<TEntity>(this IMongoCollection<TEntity> collection, TEntity entity) where TEntity : IEntity
	{
		await collection.InsertOneAsync(entity);
	}

	public static async Task<UpdateResult> UpdateAsync<TEntity>(this IMongoCollection<TEntity> collection, Expression<Func<TEntity, bool>> filter, object update, bool IsUpsert = false, bool many = false) where TEntity : IEntity
	{

		BsonDocument bsonDocument = update.ToBsonDocument();
		bsonDocument.Remove("_id");
		bsonDocument.Remove("_t");
		return (!many) ? (await collection.UpdateOneAsync(filter, new BsonDocument { { "$set", bsonDocument } }, new UpdateOptions
		{
			IsUpsert = IsUpsert
		})) : (await collection.UpdateManyAsync(filter, new BsonDocument { { "$set", bsonDocument } }, new UpdateOptions
		{

			IsUpsert = IsUpsert
		}));
	}

	public static async Task<UpdateResult> UpdateManyAsync<TEntity>(this IMongoCollection<TEntity> collection, Expression<Func<TEntity, bool>> filter, object update) where TEntity : IEntity
	{
		return await collection.UpdateAsync(filter, update, IsUpsert: false, many: true);
	}

	public static async Task InsertAllAsync<TEntity>(this IMongoCollection<TEntity> collection, IEnumerable<TEntity> entities) where TEntity : IEntity
	{
		if (entities == null || entities.Count() != 0)
		{
			await collection.InsertManyAsync(entities);
		}
	}

	public static async Task InsertAllBulkWriteAsync<TEntity>(this IMongoCollection<TEntity> collection, IEnumerable<WriteModel<TEntity>> entities) where TEntity : IEntity
	{
		await collection.BulkWriteAsync(entities);
	}

	public static async Task<UpdateResult> UpdateOrInsertAsync<TEntity>(this IMongoCollection<TEntity> collection, Expression<Func<TEntity, bool>> filter, object update) where TEntity : IEntity
	{
		return await collection.UpdateAsync(filter, update, IsUpsert: true);
	}

	public static async Task<UpdateResult> ReplaceAsync<TEntity>(this IMongoCollection<TEntity> collection, Expression<Func<TEntity, bool>> filter, object update) where TEntity : IEntity
	{
		return await collection.UpdateAsync(filter, update, IsUpsert: true);
	}

	public static async Task ReplaceAsync<TEntity>(this IMongoCollection<TEntity> collection, TEntity document, object id) where TEntity : IEntity
	{
		FilterDefinition<TEntity> filter = Builders<TEntity>.Filter.Eq("_id", id);
		await MongoDB.Driver.IMongoCollectionExtensions.FindOneAndReplaceAsync<TEntity>(collection, filter, document);
	}

}

