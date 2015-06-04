using System;
using System.Linq;
using Android.App;
using Android.Views;
using Android.Widget;

namespace Coffee.Droid
{
    public class CoffeeListAdapter : BaseAdapter
    {
        private readonly Activity _context;
        private const string CoffeeUrl = "http://opendata.paris.fr/api/records/1.0/search?dataset=liste-des-cafes-a-un-euro&facet=arrondissement&rows=200";
        private Newtonsoft.Json.Linq.JObject jsonObject;

        public CoffeeListAdapter (Activity context)
        {
            _context = context;

            System.Net.WebClient client = new System.Net.WebClient ();
            var jsonString = client.DownloadString(new Uri (CoffeeUrl, UriKind.Absolute));
            jsonObject = Newtonsoft.Json.Linq.JObject.Parse (jsonString);
        }

        public override int Count
        {
            get
            {
                return jsonObject.Value<int> ("nhits");
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

            var records = jsonObject ["records"];
            var record = records.ElementAt(position);
            var recordFields = record ["fields"];
            var coffeeName = recordFields.Value<string> ("nom_du_cafe");

            view.FindViewById<TextView> (Android.Resource.Id.Text1).Text = coffeeName;
            return view;
        }

        public string GetMapUrl(int position)
        {
            var records = jsonObject ["records"];
            var record = records.ElementAt (position);
            var recordGeometry = record ["geometry"];
            var recordCoordinates = recordGeometry ["coordinates"];
            var latitude = recordCoordinates.Value<double> (1);
            var longitude = recordCoordinates.Value<double> (0);

            var mapUrl = "http://www.openstreetmap.org/?lat="
                         +latitude.ToString(System.Globalization.CultureInfo.InvariantCulture)
                         +"&lon="
                         +longitude.ToString(System.Globalization.CultureInfo.InvariantCulture)
                         +"&zoom=17&layers=M";

            return mapUrl;
        }
    }
}