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
	[Register ("Customers")]
	partial class Customers
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITableView table { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (table != null) {
				table.Dispose ();
				table = null;
			}
		}
	}
}
