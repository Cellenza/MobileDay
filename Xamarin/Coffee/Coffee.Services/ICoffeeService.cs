using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Coffee.Services
{
	public interface ICoffeeService
	{
		int Count {get;}
		IReadOnlyList<Record> Records { get; }
		Task InitializeAsync();
	}
	
}
