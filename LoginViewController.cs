using System.CodeDom.Compiler;
using System;
using System.Drawing;
using Unvired.Kernel.Login;
using Foundation;
using UIKit;
using System.Collections.Generic;
using Unvired.Kernel.UI;
using Unvired.Kernel.Database;
using System.Reflection;
using System.IO;
using System.Xml.Linq;

namespace UnviredIOSSample
{
	partial class LoginViewController : UIViewController, IUITextFieldDelegate
	{
		// This textField holds the reference of whichever textfield the user had the focus.
		// This is used to move the Contents of the view when a keyboard comes up.
		private UITextField activeTextField = null;

		// This AlertView displays of the logging in to the user.
		public static UIAlertView alert = new UIAlertView () { 
			Title = "Select Login Type(s)"
		};

		// Default Constructor
		public LoginViewController (IntPtr handle)
			: base (handle)
		{

		}

		#region Private Methods

		private void setReturnKeyTypes ()
		{
			// Set the Return Key Types.
			switch (LoginParameters.CurrentLoginType) {
			case LoginParameters.LOGIN_TYPE.ADS:
				{
					CompanyTextField.ReturnKeyType = UIReturnKeyType.Next;
					DomainTextField.ReturnKeyType = UIReturnKeyType.Done;
				}
				break;

			case LoginParameters.LOGIN_TYPE.UNVIRED_ID:
				{
					CompanyTextField.ReturnKeyType = UIReturnKeyType.Done;
				}
				break; 

			case LoginParameters.LOGIN_TYPE.SAP:
				{
					// To Do
				}
				break;

			default:
				{

				}
				break;
			}
		}

		private void AdjustUIForLoginType ()
		{
			if (LoginParameters.CurrentLoginType != LoginParameters.LOGIN_TYPE.ADS) {		
				DomainTextField.Hidden = true;
				DomainLabel.Hidden = true;
			}
		}

		private void ManageUIButtons ()
		{
			LoginButton.TouchUpInside += (object sender, EventArgs e) => {

				DoLogin ();
			};

			CancelButton.TouchUpInside += (object sender, EventArgs e) => {

				// Clear out the Fields
				ClearAll ();
			};
			OptionsButton.TouchUpInside += (object sender, EventArgs e) => {

				// Display Login Mode Selection pop up

				//List<Unvired.Kernel.Login.LoginParameters.LOGIN_TYPE> CurrentLoginOptions =  LoginParameters.LoginTypes;
				//CurrentLoginOptions.Remove(LoginParameters.CurrentLoginType);

				UIAlertView alert = new UIAlertView () { 
					Title = "Select Login Type(s)"
				};

				string login_type = "";
				foreach (var item in LoginParameters.LoginTypes) {
					if (item.Equals (LoginParameters.CurrentLoginType))
						continue;
					switch (item) {
					case LoginParameters.LOGIN_TYPE.ADS:
						login_type = "Microsoft Active Directory Service";
						break;
					case LoginParameters.LOGIN_TYPE.SAP:
						login_type = "SAP Login";
						break;
					case LoginParameters.LOGIN_TYPE.UNVIRED_ID:
						login_type = "Unvired ID Login";
						break;
					default:
						login_type = "Other";
						break;
					}
					alert.AddButton (login_type);
				}

				alert.AddButton ("Cancel");
				alert.Show ();

				alert.Clicked += delegate(object a, UIButtonEventArgs b) {
					string button_title = alert.ButtonTitle (b.ButtonIndex);
					if (!button_title.Equals ("Cancel"))
						ChangeToLoginType (button_title);

				};
			};	
		}

		private void ManageUITextFields ()
		{
			setReturnKeyTypes ();

			// Default the URL
			URLTextfield.Text = LoginParameters.Url;

			// Navigate upon clicking on the Return Key
			URLTextfield.ShouldReturn = (textField) => {

				textField.ResignFirstResponder ();
				UsernameTextField.BecomeFirstResponder ();
				return true;
			};
			UsernameTextField.ShouldReturn = (textField) => {

				textField.ResignFirstResponder ();
				PasswordTextField.BecomeFirstResponder ();
				return true;
			};
			PasswordTextField.ShouldReturn = (textField) => {

				textField.ResignFirstResponder ();
				CompanyTextField.BecomeFirstResponder ();
				return true;

			};
			CompanyTextField.ShouldReturn = (textField) => {

				textField.ResignFirstResponder ();

				if (LoginParameters.CurrentLoginType == LoginParameters.LOGIN_TYPE.ADS) {
					DomainTextField.BecomeFirstResponder ();

				} else if (LoginParameters.CurrentLoginType == LoginParameters.LOGIN_TYPE.UNVIRED_ID) {
					DoLogin ();
				}
				return true;
			};
			DomainTextField.ShouldReturn = (textField) => {

				textField.ResignFirstResponder ();
				DoLogin ();
				return true;
			};

			// Set the Active Field.
			CompanyTextField.ShouldBeginEditing = (textField) => {

				activeTextField = textField;
				return true;
			};
			DomainTextField.ShouldBeginEditing = (textField) => {

				activeTextField = textField;
				return true;
			};
			PasswordTextField.ShouldBeginEditing = (textField) => {

				activeTextField = textField;
				return true;
			};
			URLTextfield.ShouldBeginEditing = (textField) => {

				activeTextField = textField;
				return true;
			};
			UsernameTextField.ShouldBeginEditing = (textField) => {

				activeTextField = textField;
				return true;
			};
		}

		#endregion

		#region View lifecycle

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();

			// Release any cached data, images, etc that aren't in use.
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Set the Focus to the Username TextField
			UsernameTextField.BecomeFirstResponder ();

			// Register for Keyboard Notifications to move the content which gets hidden by the Keyboard.
			RegisterForKeyboardNotifications ();

			// For all the TextField's set the delegate as 'this'
			// To Get the Active Text Field
			ManageUITextFields ();

			// Specify the Actions for each of the Buttons
			ManageUIButtons ();

			AdjustUIForLoginType ();
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}

		#endregion

		public void DoLogin ()
		{
			if (Validate ()) {
				alert.Title = "Logging in please wait...";
				alert.Show ();

				if (LoginParameters.CurrentLoginType == LoginParameters.LOGIN_TYPE.UNVIRED_ID) {

				} else if (LoginParameters.CurrentLoginType == LoginParameters.LOGIN_TYPE.ADS) {
					// To Do Implement for ADS Login

				} else if (LoginParameters.CurrentLoginType == LoginParameters.LOGIN_TYPE.SAP) {
					// To Do Implement for SAP Login
				}
			}
		}

		public void ShowAlert (string msg)
		{
			UIAlertView alert_msg = new UIAlertView ();
			alert_msg.Title = msg;
			alert_msg.AddButton ("OK");
			alert_msg.Show ();
		}

		public bool Validate ()
		{
			if (string.IsNullOrEmpty (URLTextfield.Text)) {
				ShowAlert ("URL cannot be empty");
				return false;
			}

			if (string.IsNullOrEmpty (UsernameTextField.Text)) {
				ShowAlert ("Username cannot be empty");
				return false;
			}
			if (string.IsNullOrEmpty (PasswordTextField.Text)) {
				ShowAlert ("Password cannot be empty");
				return false;
			}
			if (string.IsNullOrEmpty (CompanyTextField.Text)) {
				ShowAlert ("Company Name cannot be empty");
				return false;
			}
			return true;
		}

		public void ChangeToLoginType (string  button_title)
		{
			setReturnKeyTypes ();

			switch (button_title) {
			case "Unvired ID Login":
				LoginTypeLabel.Text = "Unvired Login";
				logo.Image = UIImage.FromBundle ("logo.png");
				DomainTextField.Hidden = true;
				DomainLabel.Hidden = true;
				LoginParameters.CurrentLoginType = LoginParameters.LOGIN_TYPE.UNVIRED_ID;
				break;
			case "Microsoft Active Directory Service":
				LoginTypeLabel.Text = "Microsoft ADS Login";
				logo.Image = UIImage.FromBundle ("Windows.png");
				DomainTextField.Hidden = false;
				DomainLabel.Hidden = false;
				LoginParameters.CurrentLoginType = LoginParameters.LOGIN_TYPE.ADS;
				break;
			case "SAP Login":
				LoginTypeLabel.Text = "SAP Login";
				LoginParameters.CurrentLoginType = LoginParameters.LOGIN_TYPE.SAP;
				break;
			default:
				break;
			}
		}

		public void ClearAll ()
		{
			URLTextfield.Text = "";
			UsernameTextField.Text = "";
			PasswordTextField.Text = "";
			DomainTextField.Text = "";
			CompanyTextField.Text = "";
		}

		#region Keyboard adjust

		// Set this field to any view inside the scroll view to center this view instead of the current responder
		protected UIView ViewToCenterOnKeyboardShown;

		protected virtual void RegisterForKeyboardNotifications ()
		{
			NSNotificationCenter.DefaultCenter.AddObserver (UIKeyboard.WillHideNotification, OnKeyboardNotification);
			NSNotificationCenter.DefaultCenter.AddObserver (UIKeyboard.WillShowNotification, OnKeyboardNotification);
		}

		// Gets the UIView that represents the "active" user input control (e.g. textfield, or button under a text field)
		protected virtual UIView KeyboardGetActiveView ()
		{
			return activeTextField;
		}

		private void OnKeyboardNotification (NSNotification notification)
		{
			if (!IsViewLoaded)
				return;

			//Check if the keyboard is becoming visible
			var visible = notification.Name == UIKeyboard.WillShowNotification;

			//Start an animation, using values from the keyboard
			UIView.BeginAnimations ("AnimateForKeyboard");
			UIView.SetAnimationBeginsFromCurrentState (true);
			UIView.SetAnimationDuration (UIKeyboard.AnimationDurationFromNotification (notification));
			UIView.SetAnimationCurve ((UIViewAnimationCurve)UIKeyboard.AnimationCurveFromNotification (notification));

			//Pass the notification, calculating keyboard height, etc.
			bool landscape = InterfaceOrientation == UIInterfaceOrientation.LandscapeLeft || InterfaceOrientation == UIInterfaceOrientation.LandscapeRight;
			var keyboardFrame = visible
				? UIKeyboard.FrameEndFromNotification (notification)
				: UIKeyboard.FrameBeginFromNotification (notification);

			OnKeyboardChanged (visible, landscape ? keyboardFrame.Width : keyboardFrame.Height);

			//Commit the animation
			UIView.CommitAnimations ();
		}

		protected virtual void OnKeyboardChanged (bool visible, nfloat keyboardHeight)
		{
			var activeView = ViewToCenterOnKeyboardShown ?? KeyboardGetActiveView ();
			if (activeView == null)
				return;

			var scrollView = activeView.Superview as UIScrollView;
			if (scrollView == null)
				return;

			if (!visible)
				RestoreScrollPosition (scrollView);
			else
				CenterViewInScroll (activeView, scrollView, (float)keyboardHeight);
		}

		protected virtual void CenterViewInScroll (UIView viewToCenter, UIScrollView scrollView, float keyboardHeight)
		{
			var contentInsets = new UIEdgeInsets (0.0f, 0.0f, keyboardHeight, 0.0f);
			scrollView.ContentInset = contentInsets;
			scrollView.ScrollIndicatorInsets = contentInsets;

			// Position of the active field relative isnside the scroll view
			RectangleF relativeFrame = (RectangleF)viewToCenter.Superview.ConvertRectToView (viewToCenter.Frame, scrollView);

			bool landscape = InterfaceOrientation == UIInterfaceOrientation.LandscapeLeft || InterfaceOrientation == UIInterfaceOrientation.LandscapeRight;
			var spaceAboveKeyboard = (landscape ? scrollView.Frame.Width : scrollView.Frame.Height) - keyboardHeight;

			// Move the active field to the center of the available space
			var offset = relativeFrame.Y - (spaceAboveKeyboard - viewToCenter.Frame.Height) / 2;
			scrollView.ContentOffset = new PointF (0, (float)offset);
		}

		protected virtual void RestoreScrollPosition (UIScrollView scrollView)
		{
			scrollView.ContentInset = UIEdgeInsets.Zero;
			scrollView.ScrollIndicatorInsets = UIEdgeInsets.Zero;
		}

		// Call it to force dismiss keyboard when background is tapped
		protected void DismissKeyboardOnBackgroundTap ()
		{
			// Add gesture recognizer to hide keyboard
			var tap = new UITapGestureRecognizer { CancelsTouchesInView = false };
			tap.AddTarget (() => View.EndEditing (true));
			View.AddGestureRecognizer (tap);
		}

		#endregion
	}
}