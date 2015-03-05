using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;

namespace UnviredIOSSample
{
	partial class Customers : UIViewController
	{

		public Customers (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			table = new UITableView(View.Bounds); // defaults to Plain style
			string[] tableItems = new string[] {"Vegetables","Fruits","Flower Buds","Legumes","Bulbs","Tubers"};
			table.Source = new TableSource(tableItems);
			Add (table);
		}
	}
}
