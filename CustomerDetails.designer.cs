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
	[Register ("CustomerDetails")]
	partial class CustomerDetails
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CCity { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CKunnr { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel CStreet { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (CCity != null) {
				CCity.Dispose ();
				CCity = null;
			}
			if (CKunnr != null) {
				CKunnr.Dispose ();
				CKunnr = null;
			}
			if (CName != null) {
				CName.Dispose ();
				CName = null;
			}
			if (CStreet != null) {
				CStreet.Dispose ();
				CStreet = null;
			}
		}
	}
}
