using System;
namespace Prova.Exceptions;

public class DataBaseNaoEncontradoException : Exception
{
	public DataBaseNaoEncontradoException(string databaseName)
		: base("Database " + databaseName + "não encontrado")
	{
	}
}

