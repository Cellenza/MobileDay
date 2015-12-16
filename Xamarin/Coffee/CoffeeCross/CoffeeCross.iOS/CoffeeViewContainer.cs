using System;
using Cirrious.MvvmCross.Touch.Views;
using Cirrious.MvvmCross.ViewModels;
using UIKit;

namespace CoffeeCross.iOS
{
	public class CoffeeViewContainer : MvxTouchViewsContainer
	{
		public CoffeeViewContainer ()
		{
		}

		protected override IMvxTouchView CreateViewOfType(Type viewType, MvxViewModelRequest request)
		{
			return (IMvxTouchView)UIStoryboard.FromName("Coffee", null)
				.InstantiateViewController(viewType.Name);
		}
	}
}

