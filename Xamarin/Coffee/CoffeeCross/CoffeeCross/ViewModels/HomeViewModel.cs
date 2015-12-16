using Cirrious.MvvmCross.ViewModels;

namespace CoffeeCross.ViewModels
{
    public class HomeViewModel : MvxViewModel
    {
		public HomeViewModel()
		{
			FindCoffee = new MvxCommand(ExecuteFindCoffee);
		}

		private void ExecuteFindCoffee()
		{
			ShowViewModel<CoffeeListViewModel>();
		}

		public MvxCommand FindCoffee { get; }
    }
}
