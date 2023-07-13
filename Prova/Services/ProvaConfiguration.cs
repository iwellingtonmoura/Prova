using System;
using Prova.Data.Models;

namespace Prova.Services;

public record ProvaConfiguration (string ConnectionString, string DatabaseName) : IDatabaseConfiguration;


