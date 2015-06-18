using System;
using System.Collections.Generic;
using System.Linq;

using Xamarin.Forms;
using Coffee.Services;
using Microsoft.Practices.ServiceLocation;

namespace CoffeeForms
{
	public partial class CoffeeListPage : ContentPage
	{
		private readonly ICoffeeService _service;

		public CoffeeListPage ()
		{
			InitializeComponent ();

			_service = ServiceLocator.Current.GetInstance<ICoffeeService> ();
		}

		protected async override void OnAppearing ()
		{
			base.OnAppearing ();

			await _service.InitializeAsync ();
			this.ListCoffee.ItemsSource = _service.Records.Select (it => it.fields.nom_du_cafe);
			this.ListCoffee.ItemSelected += ListCoffee_ItemSelected;
		}

		private void ListCoffee_ItemSelected (object sender, SelectedItemChangedEventArgs e)
		{
			var name = (string)e.SelectedItem;
			var record = _service.Records.FirstOrDefault (it => it.fields.nom_du_cafe == name);
			if (record != null && record.geometry != null && record.geometry.coordinates != null) {
				var coords = record.geometry.coordinates;

				if (Device.OS == TargetPlatform.Android) {
					var mapUrl = "http://www.openstreetmap.org/?lat="
					            + coords [1].ToString (System.Globalization.CultureInfo.InvariantCulture)
					            + "&lon="
					            + coords [0].ToString (System.Globalization.CultureInfo.InvariantCulture)
					            + "&zoom=17&layers=M";
					Device.OpenUri (new Uri (mapUrl, UriKind.Absolute));
				} else {
					this.Navigation.PushAsync (new CoffeeMapPage (name, coords [1], coords [0]));
				}
			}
		}
	}
}

