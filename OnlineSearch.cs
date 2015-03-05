using System;
using Foundation;
using UIKit;
using System.CodeDom.Compiler;
using Entity;
using Unvired.Kernel.Sync;
using System.Collections.Generic;
using Unvired.Kernel.Model;

namespace UnviredIOSSample
{
	partial class OnlineSearch : UIViewController
	{

		string inputxml = null;
		public  UIAlertView alert = new UIAlertView ();

		public OnlineSearch (IntPtr handle) : base (handle)
		{
		}

		partial void OnlineSearchButton_TouchUpInside (UIButton sender)
		{
			GetCustomer ();
		}

		public void GetCustomer ()
		{
			string name = "";
			string number = "";

			bool flag = false;
			if (!string.IsNullOrEmpty (CustomerName.Text.Trim ()) && !CustomerName.Text.Trim ().Equals ("\n")) {
				name = CustomerName.Text.Trim ();
				flag = true;
			}
			if (!string.IsNullOrEmpty (CustomerNumber.Text.Trim ()) && !CustomerNumber.Text.Trim ().Equals ("\n")) {
				number = CustomerNumber.Text.Trim ();
				flag = true;
			}
			if (flag) {
				alert.Title = "Loading Please Wait ...";
				alert.Message = string.Empty;
				alert.Show ();
				LoadList (name, number);                
			} else
				return;
		}

		private void LoadList (string customer_name, string customer_number)
		{
			INPUT_CUSTOMER inputcust = new INPUT_CUSTOMER ();
			inputcust.CUSTOMER_NUMBER = customer_number;
			inputcust.MC_NAME = customer_name;
			inputxml = inputcust.GetXML ();            
			MakeServerCall ();
		}


		public async void MakeServerCall ()
		{
			try {
				ISyncResponse iSyncResponse = null;
				if (!string.IsNullOrEmpty (inputxml)) {
					iSyncResponse = await SyncEngine.Instance.SubmitInForeground (SyncConstants.MESSAGE_REQUEST_TYPE.PULL, null, inputxml, Constants.GET_CUSTOMER_PROCESS_AGENT_FUNCTION_NAME, true);
				}
				SyncBEResponse response = (SyncBEResponse)iSyncResponse;
				if (response.DataBEs != null && response.DataBEs.Count > 0) 
				{
					alert.DismissWithClickedButtonIndex(0,true);
					this.NavigationController.PopViewController(true);
				}
				else 
				{
					alert.DismissWithClickedButtonIndex(0,true);
					string error_msg = string.Empty;
					foreach (var item in response.InfoMessages) {
						if (item.Category == "FAILURE") {
							error_msg += item.Message;
						}
					}
					ShowErrorMsg (error_msg);
				}
			}
			catch (Exception) 
			{
				alert.DismissWithClickedButtonIndex(0,true);
			} 
			finally 
			{
				//alert.DismissWithClickedButtonIndex(0,true);

			}
		}

		static void ShowErrorMsg (string error_msg)
		{
			UIAlertView alert_box = new UIAlertView ("Error", error_msg, null, "OK", null);
			alert_box.Show ();
		}
	}
}
