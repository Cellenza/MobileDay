using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Coffee.Droid
{
    [Activity (Label = "Liste des cafés")]			
	public class CoffeeListActivity : ListActivity
	{
		private CoffeeListAdapter _adapter;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			this.ListAdapter = _adapter = new CoffeeListAdapter(this);
		}

		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			var url = _adapter.GetMapUrl (position);
			var intent = new Intent (Intent.ActionView, Uri.Parse(url));
			StartActivity (intent);
		}
	}
}

