using System;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Prova.Data;
using Prova.Data.Models;

namespace Prova.Entity
{
    [BsonIgnoreExtraElements]
    [BsonCollection("ApprovalRange")]
    public class ApprovalRange : Document
	{
        /// <summary>
        /// Faixa Inicial
        /// </summary>
        [JsonPropertyName("RangeInitial")]
        public string RangeInitial { get; set; }

        /// <summary>
        /// Faixa Final
        /// </summary>
        [JsonPropertyName("RangeFinal")]
        public string RangeFinal { get; set; }

        /// <summary>
        /// Vistos
        /// </summary>
        [JsonPropertyName("Checked")]
        public int Checked { get; set; }

        /// <summary>
        /// Aprovações
        /// </summary>
        [JsonPropertyName("Approvals")]
        public int Approvals { get; set; }
    }
}

