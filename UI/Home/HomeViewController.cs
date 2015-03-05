
using System;
using System.Drawing;

using Foundation;
using UIKit;

namespace IPhoneApplication
{
	public partial class HomeViewController : UIViewController
	{
		static bool UserInterfaceIdiomIsPhone {
			get { return UIDevice.CurrentDevice.UserInterfaceIdiom == UIUserInterfaceIdiom.Phone; }
		}

		public HomeViewController ()
			: base (UserInterfaceIdiomIsPhone ? "HomeViewController_iPhone" : "HomeViewController_iPad", null)
		{
		}

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			Console.WriteLine ("Initialized Home View Controller");
			
			// Perform any additional setup after loading the view, typically from a nib.
			// Set the Title.
			this.NavigationItem.Title = "Customer search";

		}
	}
}

