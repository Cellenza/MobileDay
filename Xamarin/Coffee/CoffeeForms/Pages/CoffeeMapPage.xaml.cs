using System;
using Xamarin.Forms.Maps;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CoffeeForms
{
	public partial class CoffeeMapPage : ContentPage
	{
		private readonly double _latitude;
		private readonly double _longitude;
		private readonly string _coffeeName;

		public CoffeeMapPage (string coffeName, double latitude, double longitude)
		{
			InitializeComponent ();

			_latitude = latitude;
			_longitude = longitude;
			_coffeeName = coffeName;
			Title = coffeName;
		}

		protected override void OnAppearing ()
		{
			base.OnAppearing ();

			this.MyMap.MoveToRegion(
				MapSpan.FromCenterAndRadius(
					new Position(_latitude, _longitude),
					Distance.FromKilometers(0.5d)));

			this.MyMap.Pins.Add (new Pin () {
				Label = _coffeeName,
				Position = new Position(_latitude, _longitude)
			});

		}
	}
}

