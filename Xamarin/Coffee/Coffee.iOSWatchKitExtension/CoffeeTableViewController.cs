using System;
using System.Linq;
using System.Net;
using Foundation;
using Newtonsoft.Json.Linq;
using WatchKit;

namespace Coffee.iOSWatchKitExtension
{
	partial class CoffeeTableViewController : WKInterfaceController
	{
		private const string CoffeeUrl = "http://opendata.paris.fr/api/records/1.0/search?dataset=liste-des-cafes-a-un-euro&facet=arrondissement&rows=200";
		private JObject jsonObject;

		public CoffeeTableViewController (IntPtr handle) : base (handle)
		{
			WebClient client = new WebClient ();
			var jsonString = client.DownloadString(new Uri (CoffeeUrl, UriKind.Absolute));
			jsonObject = JObject.Parse (jsonString);
		}

		public override void WillActivate ()
		{
			base.WillActivate ();

			this.CoffeeTable.SetNumberOfRows (jsonObject.Value<int> ("nhits"), "default");

			var records = jsonObject ["records"];

			int i = 0;
			foreach (var record in records) {
				var recordFields = record ["fields"];
				var coffeeName = recordFields.Value<string> ("nom_du_cafe");

				var rowController = (CoffeeTableRowController)CoffeeTable.GetRowController ((nint)i);
				rowController.SetLabelText(coffeeName);

				i++;
			}
		}
			
		public override NSObject GetContextForSegue (string segueIdentifier, WKInterfaceTable table, nint rowIndex)
		{
		    if (segueIdentifier == "MapSegue")
		    {
		        try
		        {
		            var records = jsonObject["records"];
		            var record = records.ElementAt((int) rowIndex);
		            var recordGeometry = record["geometry"];
		            var recordCoordinates = recordGeometry["coordinates"];
		            var latitude = recordCoordinates.Value<double>(1);
		            var longitude = recordCoordinates.Value<double>(0);
		            var recordFields = record["fields"];
		            var coffeeName = recordFields.Value<string>("nom_du_cafe");

		            return new NSString(latitude + "@" + longitude + "@" + coffeeName);
		        }
		        catch
		        {
		        }
		    }
		    return null;
		}
	}
}
