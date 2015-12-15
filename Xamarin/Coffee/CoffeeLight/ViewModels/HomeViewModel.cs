using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;

namespace CoffeeLight.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            FindCoffee = new RelayCommand(ExecuteFindCoffee);
        }

        private void ExecuteFindCoffee()
        {
            _navigationService.NavigateTo(ViewModelLocator.ListPageKey);
        }

        public RelayCommand FindCoffee { get; }
    }
}
