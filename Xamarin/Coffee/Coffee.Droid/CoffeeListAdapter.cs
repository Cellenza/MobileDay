using System;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;
using Coffee.Services;

namespace Coffee.Droid
{
    public class CoffeeListAdapter : BaseAdapter
    {
        private readonly Activity _context;
		private readonly ICoffeeService coffeeService;

		public CoffeeListAdapter (Activity context, ICoffeeService coffeeService)
        {
			this.coffeeService = coffeeService;
            _context = context;
        }

        public override int Count
        {
            get
            {
				return coffeeService.Count;
            }
        }

        public override Java.Lang.Object GetItem (int position)
        {
            return null;
        }

        public override long GetItemId (int position)
        {
            return position;
        }

        public override View GetView (int position, View convertView, ViewGroup parent)
        {
            View view = convertView; // re-use an existing view, if one is available
            if (view == null) // otherwise create a new one
                view = _context.LayoutInflater.Inflate(Android.Resource.Layout.SimpleListItem1, null);

			view.FindViewById<TextView> (Android.Resource.Id.Text1).Text = coffeeService.Records[position].fields.nom_du_cafe;
            return view;
        }

        public string GetMapUrl(int position)
        {
			var recordCoordinates = coffeeService.Records[position].geometry.coordinates;
            var latitude = recordCoordinates[1];
            var longitude = recordCoordinates[0];

            var mapUrl = "http://www.openstreetmap.org/?lat="
                         +latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)
                         +"&lon="
                         +longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)
                         +"&zoom=17&layers=M";

            return mapUrl;
        }
    }
}