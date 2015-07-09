using CoffeeUniversal.ViewModels;
using Microsoft.Practices.ServiceLocation;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CoffeeUniversal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CoffeeListPage : Page, ICoffeeListModeHandler
    {
        public CoffeeListPageViewModel Model
        {
            get { return (CoffeeListPageViewModel)DataContext; }
            set { DataContext = value; }
        }
        public CoffeeListPage()
        {
            this.InitializeComponent();
            this.VisualStateGroup.CurrentStateChanged += VisualStateGroup_CurrentStateChanged;
        }

        private void VisualStateGroup_CurrentStateChanged(object sender, Windows.UI.Xaml.VisualStateChangedEventArgs e)
        {
            if (e.NewState.Name == "Small")
            {
                Model.DisplayMode = true;
            }
            else
            {
                Model.DisplayMode = false;
            }
        }

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            Model = ServiceLocator.Current.GetInstance<CoffeeListPageViewModel>();
            await Model.LoadAsync(this);
        }

        public void NavigateToDetailView()
        {
            Frame.Navigate(typeof(CoffeeMapPage), Model.SelectedRecord);
        }

        public void ShowDetailView()
        {
            //MyMap.Center = Model.CenterPoint;
        }
    }
}
