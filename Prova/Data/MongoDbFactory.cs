//using System.Reflection.Metadata;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using System.Linq.Expressions;
//using System.Linq;
//using MongoDB.Bson;
//using MongoDB.Driver;
//using Prova.Data;

//public abstract class MongoDbFactoryBase
//{

//    private readonly IMongoDatabase _database;

//    protected MongoDbFactoryBase(IConfiguration configuration)
//    {
//        _database = new MongoClient(configuration.GetConnectionString("MongoConnection")).GetDatabase(configuration.GetSection("DatabaseName").Value);
//    }

//    private protected static string GetCollectionName(Type documentType)
//    {
//        //return ((Collection)documentType.GetCustomAttributes(typeof(Collection), true).FirstOrDefault())?.CollectionName;
//    }

//    private protected IMongoCollection<T> GetMongoCollection<T>()
//    {
//        return _database.GetCollection<T>(GetCollectionName(typeof(T)));
//    }

//    public virtual IQueryable<T> AsQueryable<T>()
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        return collection.AsQueryable();
//    }

//    public async virtual Task<T> FindOneAsync<T>(Expression<Func<T, bool>> filterExpression)
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        return await collection.Find(filterExpression).FirstOrDefaultAsync();
//    }

//    public async virtual Task<List<T>> FindAllAsync<T>(Expression<Func<T, bool>> filterExpression)
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        return await collection.Find(filterExpression).ToListAsync();
//    }

//    public async virtual Task<long> CountDocumentsAsync<T>(Expression<Func<T, bool>> filterExpression)
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        return await collection.Find(filterExpression).CountDocumentsAsync();
//    }


//    public async virtual Task<bool> ExistsOneAsync<T>(Expression<Func<T, bool>> filterExpression)
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        return await collection.Find(filterExpression).AnyAsync();
//    }


//    public async virtual Task<T> FindByIdAsync<T>(ObjectId id)
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        var filter = Builders<T>.Filter.Eq("_id", id);
//        return await collection.Find(filter).SingleOrDefaultAsync();
//    }

//    public async virtual Task<T> FindByLastDocumentAsync<T>()
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        return await collection.Find(_ => true).Sort(Builders<T>.Sort.Descending("_id")).FirstOrDefaultAsync();
//    }

//    public async virtual Task<T> InsertOneAsync<T>(T document)
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        await collection.InsertOneAsync(document);
//        return document;
//    }

//    public virtual async Task InsertManyAsync<T>(ICollection<T> documents)
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        await collection.InsertManyAsync(documents);
//    }

//    public virtual async Task ReplaceOneAsync<T>(T document, ObjectId id)
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        var filter = Builders<T>.Filter.Eq("_id", id);
//        await collection.FindOneAndReplaceAsync(filter, document);
//    }

//    public async Task DeleteOneAsync<T>(Expression<Func<T, bool>> filterExpression)
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        await collection.FindOneAndDeleteAsync(filterExpression);
//    }

//    public async Task DeleteByIdAsync<T>(ObjectId id)
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        var filter = Builders<T>.Filter.Eq("_id", id);
//        await collection.FindOneAndDeleteAsync(filter);
//    }

//    public async Task DeleteManyAsync<T>(Expression<Func<T, bool>> filterExpression)
//    {
//        IMongoCollection<T> collection = GetMongoCollection<T>();
//        await collection.DeleteManyAsync(filterExpression);
//    }

//}