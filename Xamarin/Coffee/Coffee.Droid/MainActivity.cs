using Android.App;
using Android.OS;
using Android.Widget;
using Coffee.Services;

namespace Coffee.Droid
{
	[Activity (Label = "@string/app_name", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		private void InitializeIoc()
		{
			var container = GalaSoft.MvvmLight.Ioc.SimpleIoc.Default;
			container.Register<ICoffeeService, CoffeeService> ();
			Microsoft.Practices.ServiceLocation.ServiceLocator.SetLocatorProvider (() => container);
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			InitializeIoc ();

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);

			button.Click += delegate {
				this.StartActivity(typeof(CoffeeListActivity));
			};
		}
	}
}


