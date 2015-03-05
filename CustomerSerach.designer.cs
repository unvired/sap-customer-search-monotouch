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

namespace UnviredIOSSample
{
	[Register ("CustomerSerach")]
	partial class CustomerSerach
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIBarButtonItem BarButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView Customers_List { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UISearchBar SearchBar { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (BarButton != null) {
				BarButton.Dispose ();
				BarButton = null;
			}
			if (Customers_List != null) {
				Customers_List.Dispose ();
				Customers_List = null;
			}
			if (SearchBar != null) {
				SearchBar.Dispose ();
				SearchBar = null;
			}
		}
	}
}
