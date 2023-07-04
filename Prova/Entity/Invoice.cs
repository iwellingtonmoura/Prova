using System;
using System.Security.Principal;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Prova.Data;
using Prova.Data.Models;

namespace Prova.Entity;

    [BsonIgnoreExtraElements]
    [BsonCollection("Invoice")]
    public class Invoice : Document
{
	/// <summary>
	/// Data de emissão da nota fiscal
	/// </summary>
	[JsonPropertyName("DateIssue")]
	public DateTime DateIssue { get; set; }

	/// <summary>
	/// Valor das Mercadorias
	/// 
	/// </summary>
	[JsonPropertyName("CommodityPrice")]
	public float CommodityPrice { get; set; }

	/// <summary>
	/// Valor de Desconto da nota
	/// </summary>
	[JsonPropertyName("Discount")]
	public float Discount { get; set; }

	/// <summary>
	/// Valor de Frete pago
	/// </summary>
        [JsonPropertyName("FreightValue")]
        public float FreightValue { get; set; }

	/// <summary>
	/// Valor total da Nota Fiscal
	/// </summary>
	[JsonPropertyName("Total")]
	public float Total { get; set; }

	/// <summary>
	/// Status - Pendente ou Aprovada
	/// </summary>
	[JsonPropertyName("Status")]
	public string? Status { get; set; }

	public List<ApprovalHistory> approvalHistory { get; set; }
}


public class ApprovalHistory
{
	/// <summary>
	/// Data da Aprovação
	/// </summary>
	[JsonPropertyName("Date")]
	public DateTime Date { get; set; }
	/// <summary>
	/// Usário da Aprovação
	/// </summary>
	[JsonPropertyName("UserId")]
	public string UserId { get; set; }
	/// <summary>
	/// Visto ou Aprovação
	/// </summary>
	[JsonPropertyName("Operation")]
	public string? Operation { get; set; }


}
