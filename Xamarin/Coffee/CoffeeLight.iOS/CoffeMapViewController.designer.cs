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

namespace CoffeeLight.iOS
{
	[Register ("CoffeMapViewController")]
	partial class CoffeMapViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		MapKit.MKMapView MyMap { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MyMap != null) {
				MyMap.Dispose ();
				MyMap = null;
			}
		}
	}
}
