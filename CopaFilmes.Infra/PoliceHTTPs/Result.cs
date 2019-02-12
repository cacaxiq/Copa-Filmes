using System;
using System.Collections.Generic;
using System.Text;

namespace CopaFilmes.Infra.PoliceHTTPs
{
	public class Result<T>  
	{
		public bool Success { get; set; }
		public T Content { get; set; }
		public string Message { get; set; }
	}
}
