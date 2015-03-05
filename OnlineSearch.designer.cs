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
	[Register ("OnlineSearch")]
	partial class OnlineSearch
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField CustomerName { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField CustomerNumber { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton OnlineSearchButton { get; set; }

		[Action ("OnlineSearchButton_TouchUpInside:")]
		[GeneratedCode ("iOS Designer", "1.0")]
		partial void OnlineSearchButton_TouchUpInside (UIButton sender);

		void ReleaseDesignerOutlets ()
		{
			if (CustomerName != null) {
				CustomerName.Dispose ();
				CustomerName = null;
			}
			if (CustomerNumber != null) {
				CustomerNumber.Dispose ();
				CustomerNumber = null;
			}
			if (OnlineSearchButton != null) {
				OnlineSearchButton.Dispose ();
				OnlineSearchButton = null;
			}
		}
	}
}
