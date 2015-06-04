using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;

namespace CoffeeForms
{
	public class CoffeeService
	{
		private const string CoffeeUrl = "http://opendata.paris.fr/api/records/1.0/search?dataset=liste-des-cafes-a-un-euro&facet=arrondissement&rows=200";
		private Newtonsoft.Json.Linq.JObject jsonObject;


		public CoffeeService ()
		{
		}

		public async Task LoadAsync()
		{
			using (var client = new HttpClient ()) {
				var jsonString = await client.GetStringAsync (CoffeeUrl);
				jsonObject = Newtonsoft.Json.Linq.JObject.Parse (jsonString);
			}
		}

		public int GetCount()
		{
			return jsonObject.Value<int> ("nhits");
		}

		public string GetItemAt(int index)
		{
			var records = jsonObject ["records"];
			var record = records.ElementAt(index);
			var recordFields = record ["fields"];
			var coffeeName = recordFields.Value<string> ("nom_du_cafe");

			return coffeeName;
		}

		public Tuple<double, double> GetCoordinatesForItem(int index)
		{
			var records = jsonObject ["records"];
			var record = records.ElementAt (index);
			var recordGeometry = record ["geometry"];
			var recordCoordinates = recordGeometry ["coordinates"];
			var latitude = recordCoordinates.Value<double> (1);
			var longitude = recordCoordinates.Value<double> (0);

			return new Tuple<double, double> (latitude, longitude);
		}

		public IEnumerable<string> GetItems()
		{
			int count = GetCount ();
			for (int i = 0; i < GetCount(); ++i)
			{
				yield return GetItemAt (i);
			}
		}
	}
}

