using System;
using System.Linq;
using System.Net;
using Foundation;
using Newtonsoft.Json.Linq;
using WatchKit;
using Coffee.Services;

namespace Coffee.iOSWatchKitExtension
{
	partial class CoffeeTableViewController : WKInterfaceController
	{
		private readonly ICoffeeService _coffeeService;

		public CoffeeTableViewController (IntPtr handle) : base (handle)
		{
			_coffeeService = CoffeeService.Instance;
		}

		public override async void WillActivate ()
		{
			base.WillActivate ();

			await _coffeeService.InitializeAsync ();

			this.CoffeeTable.SetNumberOfRows (_coffeeService.Count, "default");

			var records = _coffeeService.Records;

			int i = 0;
			foreach (var record in records) {
				var recordFields = record.fields;
				var coffeeName = recordFields.nom_du_cafe;

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
					var record = _coffeeService.Records[(int)rowIndex];
					var recordCoordinates = record.geometry.coordinates;
		            var latitude = recordCoordinates[1];
		            var longitude = recordCoordinates[0];
					var coffeeName = record.fields.nom_du_cafe;

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
