using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using MapKit;
using CoreLocation;
using Coffee.Services;

namespace CoffeeCross.iOS
{
	partial class CoffeeMapView : MvxViewController
	{
		private class BasicPinAnnotation : MKAnnotation
		{
			private string title, subtitle;
			public override CLLocationCoordinate2D Coordinate { get { return this.Coords; } }
			public CLLocationCoordinate2D Coords { get; set; }
			public override string Title { get { return title; } }
			public override string Subtitle { get{ return subtitle; } }

			public BasicPinAnnotation (CLLocationCoordinate2D coordinate, string title, string subtitle) 
			{
				this.Coords = coordinate;
				this.title = title;
				this.subtitle = subtitle;
			}
		}

		public new CoffeeMapViewModel ViewModel
		{
			get { return (CoffeeMapViewModel) base.ViewModel; }
			set { base.ViewModel = value; }
		}
	
		public CoffeeMapView (IntPtr handle) : base (handle)
		{
		}

		private void SetMapToCoordinate (CoreLocation.CLLocationCoordinate2D coordinate)
		{
			var currentSpan = new MapKit.MKCoordinateSpan (0.05, 0.05);
			var region = new MapKit.MKCoordinateRegion (coordinate, currentSpan);

			MyMap.SetRegion (region, true);
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			try
			{
				var latitude = ViewModel.Latitude;
				var longitude = ViewModel.Longitude;
				var coords = new CLLocationCoordinate2D (latitude ?? 0, longitude ?? 0);

				SetMapToCoordinate (coords);

				Title = ViewModel.Title;
				var pin = new BasicPinAnnotation (coords, ViewModel.Title, ViewModel.Subtitle);
				MyMap.AddAnnotation (pin);
			}
			catch (Exception)
			{
			}
		}
	}
}
