using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace CoffeeForms
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		public void OnButtonClicked(object sender, EventArgs args)
		{
			this.Navigation.PushAsync (new CoffeeListPage ());
		}
	}
}

