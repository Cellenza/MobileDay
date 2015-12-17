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
using Coffee.Services;
using CoffeeLight.Droid.Views;
using CoffeeLight.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;

namespace CoffeeLight.Droid
{
    public static class App
    {
        private static ViewModelLocator _locator;

        public static ViewModelLocator Locator
        {
            get
            {
                if (_locator == null)
                {
                    var nav = new NavigationService();
                    nav.Configure(
                        ViewModelLocator.HomePageKey,
                        typeof(HomeActivity));
                    nav.Configure(
                        ViewModelLocator.ListPageKey,
                        typeof(CoffeeListActivity));
                    nav.Configure(
                        ViewModelLocator.MapPageKey,
                        typeof(CoffeeMapActivity));

                    SimpleIoc.Default.Register<INavigationService>(() => nav);
                    SimpleIoc.Default.Register<IDialogService, DialogService>();
                    SimpleIoc.Default.Register<ICoffeeService, CoffeeService>();

                    _locator = new ViewModelLocator();
                }

                return _locator;
            }
        }
    }
}