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
			_coffeeService = CoffeeService.Instance;
		}

		public override async void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			await _coffeeService.InitializeAsync();
			TableView.Source = new CoffeeTableSource (this, _coffeeService);
			TableView.ReloadData ();
		}

		public void OnRecordSelected(double latitude, double longitude)
		{
			var mapUrl = "http://www.openstreetmap.org/?lat="
				+latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)
				+"&lon="
				+longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)
				+"&zoom=17&layers=M";

			UIApplication.SharedApplication.OpenUrl(new NSUrl(mapUrl));
		}
	}
}
