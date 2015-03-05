

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Entity;

namespace UnviredIOSSample.HelperClasses
{
	public class CustomersAdapter : UITableViewSource
	{
		List<CUSTOMERS_RESULTS_HEADER> tableItems;

		CustomerSerach navigationController; 

		string cellIdentifier = "TableCell";
		public CustomersAdapter(CustomerSerach navigationController,List<CUSTOMERS_RESULTS_HEADER> items)
		{
			this.navigationController = navigationController;
			tableItems = items;
		}
		public override nint RowsInSection(UITableView tableview, nint section)
		{
			return tableItems.Count;
		}
		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			UITableViewCell cell = tableView.DequeueReusableCell(cellIdentifier);
			// if there are no cells to reuse, create a new one
			if (cell == null)
				cell = new UITableViewCell(UITableViewCellStyle.Subtitle, cellIdentifier);
			cell.TextLabel.Text = tableItems[indexPath.Row].NAME;
			cell.DetailTextLabel.Text = tableItems [indexPath.Row].STREET;
			return cell;
		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			//new UIAlertView("Row Selected", tableItems[indexPath.Row].NAME, null, "OK", null).Show();
			//tableView.DeselectRow (indexPath, true); // iOS convention is to remove the highlight


			//CustomerDetails details = new CustomerDetails ();
			//navigationController.PushViewController (details);
			//tableView.DeselectRow (indexPath, true);

			Constants.SelectedCustomer = tableItems [indexPath.Row];
			navigationController.PerformSegue ("detailSegue", navigationController);
		}
	}
}