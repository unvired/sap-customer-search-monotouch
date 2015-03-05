using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;
using UnviredIOSSample.HelperClasses;
using System.Collections.Generic;
using Entity;
using System.Linq;
using Unvired.Kernel.Database;
using Unvired.Kernel.Core;

namespace UnviredIOSSample
{
	public partial class CustomerSerach : UIViewController
	{
		List<CUSTOMERS_RESULTS_HEADER> resultlist = new List<CUSTOMERS_RESULTS_HEADER> ();
		List<CUSTOMERS_RESULTS_HEADER> filtered_list = new List<CUSTOMERS_RESULTS_HEADER> ();
		IDataManager datamanager;
		public CustomerSerach (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad ();

			SearchBar.TextChanged += (s, e) => {
				RefreshList(e.SearchText);
			};
			LoadList ();
		}
 		

		private void RefreshList(string hint)
		{
			if (resultlist != null && resultlist.Count > 0) 
			{
				Customers_List.Source = null;
				filtered_list = (resultlist.Where (x => x.NAME.ToLower ().Contains (hint.ToLower ()) || x.STREET.ToLower ().Contains (hint.ToLower ()))).ToList ();
				Customers_List.Source = new CustomersAdapter (this,filtered_list);
				Customers_List.ReloadData ();
			}
		}


		private async void LoadList()
		{
			try
			{
				Customers_List.Source = null;
				datamanager = ApplicationManager.Instance.GetDataManager();
					resultlist = (await datamanager.Get<CUSTOMERS_RESULTS_HEADER>()).ToList();
				if (resultlist != null && resultlist.Count () > 0) 
				{
					this.Title = "All Customers "+"("+resultlist.Count.ToString()+")";
					Customers_List.Source = new CustomersAdapter (this,resultlist.OrderBy (x => x.NAME).ToList ());
					RefreshList ("");
				}
				else
				{
					this.Title = "All Customers";
				}
			
			}
			catch(Exception) 
			{

			}
		}

		public override void ViewDidAppear(bool val)
		{
			LoadList ();
		}
	}
}
