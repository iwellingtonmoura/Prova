using System;
namespace Prova.Data.Models
{
	public interface IDatabaseConfiguration
	{
		string ConnectionString { get; }

		string DatabaseName { get; }
	}
}

