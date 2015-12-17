using Android.App;
using Android.OS;
using Cirrious.CrossCore;
using Cirrious.MvvmCross.Droid.Views;
using CoffeeCross.Droid.Views;
using CoffeeCross.ViewModels;
using MvxActivity = Cirrious.MvvmCross.Droid.FullFragging.Views.MvxActivity;

namespace CoffeeCross.Droid
{
    [Activity(Label = "CoffeeCross.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            var presenter = (DroidPresenter)Mvx.Resolve<IMvxAndroidViewPresenter>();
            var initialFragment = new HomeView { ViewModel = Mvx.IocConstruct<HomeViewModel>() };
            presenter.RegisterFragmentManager(FragmentManager, initialFragment);
        }
    }
}
