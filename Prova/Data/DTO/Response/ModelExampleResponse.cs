using System;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Prova.Data.Models;

namespace Prova.Data.DTO.Response;

[BsonIgnoreExtraElements]
[BsonCollection("dados_clientes")]
public class ModelExampleResponse : Document
{
    [JsonPropertyName("Cpf")]
    public string? Cpf { get; set; }
    [JsonPropertyName("Nome")]
    public string? Nome { get; set; }
    [JsonPropertyName("Idade")]
    public int Idade { get; set; }
    [JsonPropertyName("Endereco")]
    public string? Endereco { get; set; }

}

