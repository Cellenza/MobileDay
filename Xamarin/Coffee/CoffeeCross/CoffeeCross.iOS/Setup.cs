using Cirrious.CrossCore.Platform;
using Cirrious.MvvmCross.Touch.Views.Presenters;
using Cirrious.MvvmCross.ViewModels;
using Cirrious.MvvmCross.Touch.Platform;
using UIKit;

namespace CoffeeCross.iOS
{
	public class Setup : MvxTouchSetup
	{
		public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
			: base(applicationDelegate, window)
		{
		}
		
		public Setup(MvxApplicationDelegate applicationDelegate, IMvxTouchViewPresenter presenter)
			: base(applicationDelegate, presenter)
		{
		}

		protected override IMvxApplication CreateApp()
		{
			return new CoffeeCross.App();
		}
		
		protected override IMvxTrace CreateDebugTrace()
		{
			return new DebugTrace();
		}

		protected override Cirrious.MvvmCross.Touch.Views.IMvxTouchViewsContainer CreateTouchViewsContainer ()
		{
			return new CoffeeViewContainer();
		}
	}
}
