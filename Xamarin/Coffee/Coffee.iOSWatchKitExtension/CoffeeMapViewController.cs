using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Coffee.iOSWatchKitExtension
{
	partial class CoffeeMapViewController : WatchKit.WKInterfaceController
	{
		private double latitude;
		private double longitude;

		public CoffeeMapViewController (IntPtr handle) : base (handle)
		{
		}

		public override void WillActivate ()
		{
			base.WillActivate ();

			var coords = new CoreLocation.CLLocationCoordinate2D (latitude, longitude);

			SetMapToCoordinate (coords);

			this.CoffeeMap.AddAnnotation (
				coords,
				WatchKit.WKInterfaceMapPinColor.Purple);
		}

		void SetMapToCoordinate (CoreLocation.CLLocationCoordinate2D coordinate)
		{
			var currentSpan = new MapKit.MKCoordinateSpan (0.05, 0.05);
			var region = new MapKit.MKCoordinateRegion (coordinate, currentSpan);

			var newCenterPoint = MapKit.MKMapPoint.FromCoordinate (coordinate);

			CoffeeMap.SetVisible (new MapKit.MKMapRect (newCenterPoint.X, newCenterPoint.Y, currentSpan.LatitudeDelta, currentSpan.LongitudeDelta));
			CoffeeMap.SetRegion (region);
		}

		public override void Awake (NSObject context)
		{
			if (context != null) {
				NSString ns = (NSString)context;

				var s = ns.ToString ();

				var sarr = s.Split (new [] { '@' });

				latitude = double.Parse (sarr [0]);
				longitude = double.Parse (sarr [1]);

				this.SetTitle (sarr [2]);
			}

			base.Awake (context);
		}
	}
}
