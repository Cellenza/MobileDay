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
	[Register ("CoffeeTableViewController")]
	partial class CoffeeTableViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		WatchKit.WKInterfaceTable CoffeeTable { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CoffeeTable != null) {
				CoffeeTable.Dispose ();
				CoffeeTable = null;
			}
		}
	}
}
