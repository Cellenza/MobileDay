using System;
using Foundation;
using UIKit;
using Coffee.Services;

namespace Coffee
{
    public partial class CoffeeTableViewController : UITableViewController
	{
		private readonly ICoffeeService _coffeeService;

		public CoffeeTableViewController (IntPtr handle) : base (handle)
		{
			_coffeeService = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<ICoffeeService>();
		}

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			try
			{
				await _coffeeService.InitializeAsync();
				TableView.Source = new CoffeeTableSource (this, _coffeeService);
				TableView.ReloadData ();
			}
			catch (Exception e) {
				// TRAITER L'ERREUR
			}
		}

		private Record _selectedItem;

		public override void PrepareForSegue (UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue (segue, sender);

			switch (segue.Identifier)
			{
			case "ShowMap":
				var mapController = segue.DestinationViewController as CoffeMapViewController;
				if (mapController != null) {
					try{
					var recordCoordinates = _selectedItem.geometry.coordinates;
					var latitude = recordCoordinates[1];
					var longitude = recordCoordinates[0];
					mapController.Latitude = latitude;
					mapController.Longitude = longitude;
					mapController.PinTitle = _selectedItem.fields.nom_du_cafe;
						mapController.PinSubtitle = _selectedItem.fields.adresse;}catch{}
				}
				break;
			}
		}

		public void OnRecordSelected(Record selectedItem)
		{
//			var mapUrl = "http://www.openstreetmap.org/?lat="
//				+latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)
//				+"&lon="
//				+longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)
//				+"&zoom=17&layers=M";

			//UIApplication.SharedApplication.OpenUrl(new NSUrl(mapUrl));
			_selectedItem = selectedItem;
			PerformSegue("ShowMap", this);
		}
	}
}
