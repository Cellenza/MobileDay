using Android.App;
using Android.OS;
using Android.Widget;
using Coffee.Services;

namespace Coffee.Droid
{
	[Activity (Label = "@string/app_name", MainLauncher = false, Icon = "@drawable/icon")]
	public class MainActivityWithFragments : Activity
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
			SetContentView (Resource.Layout.MainWithFragments);

			LoadMainFragment ();
		}

		public void LoadMainFragment()
		{
			// Create a new fragment and a transaction.
			FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
			HomeFragment frag = new HomeFragment();

			fragmentTx
				.Replace(Resource.Id.fragment_container, frag)
				.AddToBackStack(null)
				.Commit();
		}

		public void LoadListFragment()
		{
			// Create a new fragment and a transaction.
			FragmentTransaction fragmentTx = this.FragmentManager.BeginTransaction();
			DetailsFragment frag = new DetailsFragment();

			fragmentTx
				.Replace(Resource.Id.fragment_container, frag)
				.AddToBackStack("List")
				.Commit();
		}
	}
}


