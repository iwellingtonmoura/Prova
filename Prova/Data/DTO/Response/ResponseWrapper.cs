using System;
using System.Security.Principal;

namespace Prova.Data.DTO.Response
{
	public class ResponseWrapper<T>
	{
		public string? Message { get; set; }
		public T? Result { get; set; }
	}
}
