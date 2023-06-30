using System;
namespace Prova.Data.DTO.Response
{
	public class ResponseOnException
	{
		public bool IsError { get; set; }
		public ResponseException? ResponseException { get; set; }
	}

	public class ResponseException
	{
		public string? ExceptionMessage { get; set; }
	}
}

