using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using MapKit;
using CoreLocation;
using GalaSoft.MvvmLight.Views;
using Coffee.Services;
using CoffeeLight.ViewModels;

namespace CoffeeLight.iOS
{
	public partial class CoffeMapViewController : ControllerBase
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

		public CoffeMapViewController (IntPtr handle) : base (handle)
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

			var vm = NavigationParameter as CoffeeMapViewModel;
			if (vm == null)
				return;
			
			Record record = vm.Record;
			if (record == null)
				return;

			if (record.geometry == null || record.geometry.coordinates == null)
				return;
			
			try
			{
				var recordCoordinates = record.geometry.coordinates;
				var latitude = recordCoordinates[1];
				var longitude = recordCoordinates[0];
				var coords = new CLLocationCoordinate2D (latitude, longitude);

				SetMapToCoordinate (coords);

				Title = record.fields.nom_du_cafe;
				var pin = new BasicPinAnnotation (coords, record.fields.nom_du_cafe, record.fields.adresse);
				MyMap.AddAnnotation (pin);
			}
			catch (Exception)
			{
			}
		}
	}
}
