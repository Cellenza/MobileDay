using System;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Coffee.Services
{

	public class CoffeeService : ICoffeeService
	{
		private const string CoffeeUrl = "http://opendata.paris.fr/api/records/1.0/search?dataset=liste-des-cafes-a-un-euro&facet=arrondissement&rows=200";
		private RootObject _result;
		private static readonly CoffeeService _instance = new CoffeeService();
		private bool _isInitialized;

		protected CoffeeService ()
		{
			
		}

		public static CoffeeService Instance { get { return _instance; } }

		public int Count {get;private set;}

		public IReadOnlyList<Record> Records {get; private set;}

		public async Task InitializeAsync()
		{
			if (_isInitialized)
				return;
			
			try
			{
				using (var client = new HttpClient())
				{
					var jsonString = await client.GetStringAsync (new Uri (CoffeeUrl, UriKind.Absolute));
					_result = JsonConvert.DeserializeObject<RootObject>(jsonString);
					Count = _result.nhits;
					Records = _result.records;
				}

				_isInitialized = true;
			}
			catch (Exception)
			{
				throw;
			}

		}
	}
}

