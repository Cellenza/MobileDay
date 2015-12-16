// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace CoffeeCross.iOS
{
	[Register ("HomeView")]
	partial class HomeView
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton FindCoffeeButton { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (FindCoffeeButton != null) {
				FindCoffeeButton.Dispose ();
				FindCoffeeButton = null;
			}
		}
	}
}
