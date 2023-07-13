﻿using System;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using Prova.Data;
using Prova.Data.Atrributes;
using Prova.Data.Models;
using CollectionAttribute = Prova.Data.CollectionAttribute;

namespace Prova.Data.DTO.Request;

[BsonIgnoreExtraElements]
[CollectionAttribute("User")]
public class UserRequest
	{
    /// <summary>
    /// Login do Usuário
    /// </summary>
    [JsonPropertyName("Login")]
    public string? Login { get; set; }

    /// <summary>
    ///	Senha do Usuário
    /// </summary>
    [JsonPropertyName("Password")]
    public string? Password { get; set; }

    /// <summary>
    /// Papel - Visto ou Aprovação
    /// </summary>
    [JsonPropertyName("Paper")]
    public string? Paper { get; set; }

    /// <summary>
    /// Valor mínimo para visto ou aprovação
    /// </summary>
    [JsonPropertyName("MinValue")]
    public float MinValue { get; set; }

    /// <summary>
    /// Valor máximo para visto ou aprovação
    /// </summary>
    [JsonPropertyName("MaxValue")]
    public float MaxValue { get; set; }
}

