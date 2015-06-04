using System;
using Foundation;
using UIKit;

namespace Coffee
{
    public partial class CoffeeTableViewController : UITableViewController
	{
		public CoffeeTableViewController (IntPtr handle) : base (handle)
		{

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			TableView.Source = new CoffeeTableSource (this);
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
