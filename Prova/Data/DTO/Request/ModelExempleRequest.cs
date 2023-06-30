using System;
using System.Data;
using System.Text.Json.Serialization;
using FluentValidation;
using MongoDB.Bson.Serialization.Attributes;
using Prova.Data.Models;

namespace Prova.Data.DTO.Request;

[BsonIgnoreExtraElements]
[BsonCollection("dados_clientes")]
public class ModelExampleRequest : Document
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
    public class ModelExampleRequestValidator : AbstractValidator<ModelExampleRequest>
{
	public ModelExampleRequestValidator()
	{
		RuleFor(x => x.Cpf).NotEmpty().WithMessage("Informe a propriedade");
	}
}
