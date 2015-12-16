using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using Cirrious.MvvmCross.Touch.Views;
using CoffeeCross.ViewModels;
using Cirrious.MvvmCross.Binding.BindingContext;

namespace CoffeeCross.iOS
{
	partial class HomeView : MvxViewController
	{
		public new HomeViewModel ViewModel
		{
			get { return (HomeViewModel) base.ViewModel; }
			set { base.ViewModel = value; }
		}

		public HomeView (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			this.CreateBinding(FindCoffeeButton).To<HomeViewModel>(vm => vm.FindCoffee).Apply();
		}
	}
}
