using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Views;
using Android.Widget;
using Coffee.Services;
using System.Threading.Tasks;

namespace Coffee.Droid
{
    [Activity (Label = "Liste des cafés")]			
	public class CoffeeListActivity : ListActivity
	{
		private CoffeeListAdapter _adapter;
		private ICoffeeService _coffeeService;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			this._coffeeService = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<ICoffeeService>();

			Task.Run (async () => {
				await _coffeeService.InitializeAsync();
				this.RunOnUiThread(() =>
					{
						this.ListAdapter = _adapter = new CoffeeListAdapter(this, _coffeeService);
					});
			});
		}
        
		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			var url = _adapter.GetMapUrl (position);
			var intent = new Intent (Intent.ActionView, Uri.Parse(url));

			StartActivity (intent);
		}
	}
}

