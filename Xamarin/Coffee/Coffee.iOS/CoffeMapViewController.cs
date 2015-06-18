using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using MapKit;
using CoreLocation;

namespace Coffee
{
	public partial class CoffeMapViewController : UIViewController
	{
		private class BasicPinAnnotation : MKAnnotation
		{
			string title, subtitle;
			public override CLLocationCoordinate2D Coordinate { get { return this.Coords; }}
			public CLLocationCoordinate2D Coords { get; set; }
			public override string Title { get{ return title; }}
			public override string Subtitle { get{ return subtitle; }}
			public BasicPinAnnotation (CLLocationCoordinate2D coordinate, string title, string subtitle) 
			{
				this.Coords = coordinate;
				this.title = title;
				this.subtitle = subtitle;
			}
		}

		public CoffeMapViewController (IntPtr handle) : base (handle)
		{
		}

		public double Latitude {get;set;}
		public double Longitude {get;set;}
		public string PinTitle {get;set;}
		public string PinSubtitle { get; set; }

		void SetMapToCoordinate (CoreLocation.CLLocationCoordinate2D coordinate)
		{
			var currentSpan = new MapKit.MKCoordinateSpan (0.05, 0.05);
			var region = new MapKit.MKCoordinateRegion (coordinate, currentSpan);

			MyMap.SetRegion (region, true);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			var coords = new CoreLocation.CLLocationCoordinate2D (Latitude, Longitude);

			SetMapToCoordinate (coords);

			Title = PinTitle;
			var pin = new BasicPinAnnotation (coords, PinTitle, PinSubtitle);
			MyMap.AddAnnotation (pin);
		}
	}
}
