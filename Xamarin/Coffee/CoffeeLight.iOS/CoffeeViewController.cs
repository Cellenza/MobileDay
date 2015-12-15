using System;
using CoffeeLight.iOS;
using CoffeeLight.ViewModels;
using GalaSoft.MvvmLight.Helpers;
using UIKit;
using GalaSoft.MvvmLight.Views;

namespace CoffeeLight.iOS
{
	partial class CoffeeViewController : ControllerBase
	{
	    private HomeViewModel Vm => Application.Locator.Home;

		public CoffeeViewController (IntPtr handle) : base (handle)
		{
		}

	    public override void ViewDidLoad()
	    {
	        base.ViewDidLoad();

            FindCoffeeButton.SetCommand("TouchUpInside", Vm.FindCoffee);
	    }
	}
}
