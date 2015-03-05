using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace UnviredIOSSample
{
	partial class CustomerDetails : UIViewController
	{
		public CustomerDetails (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidAppear(bool val)
		{
			if (Constants.SelectedCustomer != null) {
				this.Title = Constants.SelectedCustomer.NAME;
				CName.Text = Constants.SelectedCustomer.NAME;
				CStreet.Text = Constants.SelectedCustomer.STREET;
				CKunnr.Text = Constants.SelectedCustomer.KUNNR;
				CCity.Text = Constants.SelectedCustomer.CITY1;
			} 
		}
	}
}
