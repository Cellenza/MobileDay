using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Coffee.Droid
{	
	public class HomeFragment : Fragment
	{
		public override View OnCreateView (LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			var activity = (MainActivityWithFragments)Activity;
			View view = inflater.Inflate (Resource.Layout.MainFragment, null);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = view.FindViewById<Button> (Resource.Id.myButton);

			button.Click += delegate {
				activity.LoadListFragment();
			};

			return view;
		}
	}
}

