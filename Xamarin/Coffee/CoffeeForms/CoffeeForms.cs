using System;

using Xamarin.Forms;
using GalaSoft.MvvmLight.Ioc;
using Coffee.Services;
using Microsoft.Practices.ServiceLocation;

namespace CoffeeForms
{
	public class App : Application
	{
		public App ()
		{
			SimpleIoc.Default.Register<ICoffeeService, CoffeeService> ();
			ServiceLocator.SetLocatorProvider (() => SimpleIoc.Default);

			// The root page of your application
			MainPage = new NavigationPage(new CoffeeForms.MainPage());
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

