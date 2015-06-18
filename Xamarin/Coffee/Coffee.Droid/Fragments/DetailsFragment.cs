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
	public class DetailsFragment : Fragment
	{
	    private ICoffeeService _coffeeService;
		private CoffeeListAdapter _adapter;

	    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
	    {
	        View view = inflater.Inflate(Resource.Layout.CoffeeListFragment, null);
	        var listView = view.FindViewById<ListView>(Resource.Id.coffee_listview);

			this._coffeeService = Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<ICoffeeService>();

            Task.Run(async () =>
            {
                await _coffeeService.InitializeAsync();
                Activity.RunOnUiThread(() =>
                {
                    listView.Adapter = _adapter = new CoffeeListAdapter(Activity, _coffeeService);
                });
            });

			listView.ItemClick += ListView_ItemClick;

	        return view;
	    }

	    private void ListView_ItemClick (object sender, AdapterView.ItemClickEventArgs e)
	    {
			var url = _adapter.GetMapUrl (e.Position);
			var intent = new Intent (Intent.ActionView, Uri.Parse(url));

			StartActivity (intent);
	    }
	}
}

