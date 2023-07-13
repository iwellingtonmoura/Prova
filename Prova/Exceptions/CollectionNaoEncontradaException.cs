using System;
namespace Prova.Exceptions
{
	public class CollectionNaoEncontradaException : Exception
	{
		public CollectionNaoEncontradaException(string collectionName)
			:base("collection " + collectionName + "não encontrada")
		{
		}
	}
}

