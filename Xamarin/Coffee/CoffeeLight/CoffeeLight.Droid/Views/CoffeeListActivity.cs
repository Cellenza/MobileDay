using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using Coffee.Services;
using CoffeeLight.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;

namespace CoffeeLight.Droid.Views
{
    [Activity(Label = "CoffeeLight.Droid", MainLauncher = false, Icon = "@drawable/icon")]
    public class CoffeeListActivity : ActivityBase, AdapterView.IOnItemClickListener
    {
        public CoffeeListViewModel ViewModel => App.Locator.List;

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.CoffeeList);

            var listView = FindViewById<ListView>(Resource.Id.coffee_listview);

            await ViewModel.StartAsync();

            var adapter = ViewModel.Records.GetAdapter(GetRecordAdapter);
            listView.Adapter = adapter;
            listView.OnItemClickListener = this;
        }

        private View GetRecordAdapter(int position, Record record, View convertView)
        {
            if (convertView == null)
                convertView = LayoutInflater.Inflate(Resource.Layout.coffeelistfragment_itemtemplate, null);

            var title = convertView.FindViewById<TextView>(Resource.Id.coffee_name_textview);
            title.Text = record.fields.nom_du_cafe;

            return convertView;
        }

        public void OnItemClick(AdapterView parent, View view, int position, long id)
        {
            ViewModel.SelectRecord.Execute(ViewModel.Records[position]);
        }
    }
}