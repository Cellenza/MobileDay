using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;

namespace CoffeeForms
{
	public partial class CoffeeListPage : ContentPage
	{
		private readonly CoffeeService _service = new CoffeeService();

		public CoffeeListPage ()
		{
			InitializeComponent ();
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			await _service.LoadAsync ();
			this.ListCoffee.ItemsSource = _service.GetItems ();
			this.ListCoffee.ItemSelected += ListCoffee_ItemSelected;
		}

		private void ListCoffee_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var name = (string)e.SelectedItem;
			var index = _service.GetItems ().ToList ().IndexOf (name);
			var coords = _service.GetCoordinatesForItem (index);

			if (Device.OS == TargetPlatform.Android) {
				var mapUrl = "http://www.openstreetmap.org/?lat="
					+coords.Item1.ToString(System.Globalization.CultureInfo.InvariantCulture)
					+"&lon="
					+coords.Item2.ToString(System.Globalization.CultureInfo.InvariantCulture)
					+"&zoom=17&layers=M";
				Device.OpenUri (new Uri (mapUrl, UriKind.Absolute));
			}
			else {
				this.Navigation.PushAsync (new CoffeeMapPage (name, coords.Item1, coords.Item2));
			}
		}
	}
}

