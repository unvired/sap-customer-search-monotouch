// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace UnviredIOSSample
{
	[Register ("ApplicationHomeScreen")]
	partial class ApplicationHomeScreen
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		Customersearch Customersearch { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView CustomersList { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (Customersearch != null) {
				Customersearch.Dispose ();
				Customersearch = null;
			}
			if (CustomersList != null) {
				CustomersList.Dispose ();
				CustomersList = null;
			}
		}
	}
}
