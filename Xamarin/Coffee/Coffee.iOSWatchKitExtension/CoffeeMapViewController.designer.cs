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

namespace Coffee.iOSWatchKitExtension
{
	[Register ("CoffeeMapViewController")]
	partial class CoffeeMapViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceMap CoffeeMap { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CoffeeMap != null) {
				CoffeeMap.Dispose ();
				CoffeeMap = null;
			}
		}
	}
}
