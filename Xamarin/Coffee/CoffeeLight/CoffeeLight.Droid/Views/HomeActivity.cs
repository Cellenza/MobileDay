using Android.App;
using Android.OS;
using Android.Widget;
using CoffeeLight.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using GalaSoft.MvvmLight.Views;

namespace CoffeeLight.Droid.Views
{
    [Activity(Label = "CoffeeLight.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class HomeActivity : ActivityBase
    {
        public HomeViewModel ViewModel => App.Locator.Home;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Home);

            var btn = FindViewById<Button>(Resource.Id.myButton);
            btn.SetCommand("Click", ViewModel.FindCoffee);
        }
    }
}