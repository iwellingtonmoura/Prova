//using System;
//using Amazon.Runtime.Documents;
//using Microsoft.AspNetCore.Mvc.TagHelpers.Cache;
//using MongoDB.Bson;
//using Prova.Data.DTO.Response;
//using Prova.Data.Models;
//using Prova.Entity;

//namespace Prova.Data.Repositories;

//public interface IMongoRepository
//{
//	Task<T> GetById<T>(ObjectId objectId);

//	Task<User> InserirUsuarioAsync(User user);
//	Task AtualizarUsuarioAsync(User user, ObjectId objectId);

//	Task<Invoice> InserirNotaFiscalAsync(Invoice invoice);
//	Task AtualizarNotaFiscalAsync(Invoice invoice, ObjectId objectId);

//	Task<ApprovalRange> InserirRangeAprovacaoAsync(ApprovalRange approvalRange);

//    }

//public class MongoRepository : MongoDbFactoryBase, IMongoRepository
//{
//	public MongoRepository(IConfiguration configuration) : base(configuration)
//	{
//	}

//    public async Task<T> GetById<T>(ObjectId objectId)
//    {
//        return await FindByIdAsync<T>(objectId);
//    }

//    public async Task<User> InserirUsuarioAsync(User user)
//    {
//        return await InsertOneAsync<User>(user);
//    }

//    public async Task AtualizarUsuarioAsync(User user, ObjectId objectId)
//    {
//        await ReplaceOneAsync(user, objectId);
//    }


//    public async Task<Invoice> InserirNotaFiscalAsync(Invoice invoice)
//    {
//        return await InsertOneAsync<Invoice>(invoice);
//    }

//    public async Task AtualizarNotaFiscalAsync(Invoice invoice, ObjectId objectId)
//    {
//        await ReplaceOneAsync(invoice, objectId);
//    }

//    public async Task<ApprovalRange> InserirRangeAprovacaoAsync(ApprovalRange approvalRange)
//    {
//        return await InsertOneAsync<ApprovalRange>(approvalRange);
//    }

//}

