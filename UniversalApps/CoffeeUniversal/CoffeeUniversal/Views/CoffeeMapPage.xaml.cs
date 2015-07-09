using System;
using Coffee.Services;
using CoffeeUniversal.ViewModels;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Practices.ServiceLocation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CoffeeUniversal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CoffeeMapPage : Page
    {
        public CoffeeMapPageViewModel Model
        {
            get { return (CoffeeMapPageViewModel)DataContext; }
            set { DataContext = value; }
        }

        public CoffeeMapPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Model = ServiceLocator.Current.GetInstance<CoffeeMapPageViewModel>();

            var record = e.Parameter as Record;
            if (record.geometry != null)
            {
                await Model.LoadAsync(record);
            }
        }
    }
}
