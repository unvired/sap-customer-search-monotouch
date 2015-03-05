using System;
using System.Collections.Generic;
using System.Linq;
using Unvired.Kernel.Log;

using UIKit;
using Unvired.Kernel.Login;
using Unvired.Kernel.Database;
using System.Reflection;
using System.Xml.Linq;
using IPhoneApplication;
using Foundation;
using Unvired.Kernel.Util;

namespace UnviredIOSSample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate, LoginListener
	{
		UIWindow window;

		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			window = new UIWindow (UIScreen.MainScreen.Bounds);

			//Login parameters required to authenticate with Unvired Mobile Platform
			LoginParameters.AssemblyName = System.Reflection.Assembly.GetExecutingAssembly ().GetName ().ToString ();
			LoginParameters.AssemblyVersion = System.Reflection.Assembly.GetExecutingAssembly ().GetName ().Version.ToString ();

			LoginParameters.AppTitle = "Customer Search";
			LoginParameters.AppName = "UNVIRED_SAMPLE_SAP_ERP";
			LoginParameters.showCompany = true;

			LoginParameters.LoginTypes = new LoginParameters.LOGIN_TYPE[] {
				LoginParameters.LOGIN_TYPE.UNVIRED_ID,
				LoginParameters.LOGIN_TYPE.ADS,
				LoginParameters.LOGIN_TYPE.SAP
			};

			LoginParameters.DeviceType = LoginParameters.DEVICE_TYPE.iPhone;
			LoginParameters.LoginListener = this;

			LoginParameters.LoginTypes = new LoginParameters.LOGIN_TYPE[] {
				LoginParameters.LOGIN_TYPE.UNVIRED_ID,
				LoginParameters.LOGIN_TYPE.ADS,
				LoginParameters.LOGIN_TYPE.SAP
			};
			LoginParameters.CurrentLoginType = LoginParameters.LOGIN_TYPE.UNVIRED_ID;

			//To support SQLCipher add SQLCipher component into project and set EncryptDataBase to true
			//LoginParameters.EncryptDataBase = true;

			LoginParameters.Url = "http://live.unvired.io/UNI";

			string content = System.IO.File.ReadAllText ("MetaData.xml");
			LoginParameters.MetaDataXml = XDocument.Parse (content);

			Util.InitializeNative (window);

			//Fuction To check App installation
			AuthenticationService.Login ();

			return true;
		}

		// Login Listener Implementation


		public void AuthenticateAndActivationFailure (string errorMessage)
		{
		}

		public void AuthenticateAndActivationSuccessful ()
		{
			DisplayHomeScreen ();
		}

		public void DemologinSuccessful ()
		{
		}

		public void InvokeLoginScreen (bool isSuccessiveLogin)
		{
		}

		public void LoginCancelled ()
		{
		}

		public void LoginFailure (string errorMessage)
		{
		}

		public void LoginSuccessful ()
		{
			DisplayHomeScreen ();
		}

		public void DisplayHomeScreen ()
		{
			UIStoryboard addNewGeneralSb = UIStoryboard.FromName ("ApplicationStoryBoard", null);
			UIViewController viewController = addNewGeneralSb.InstantiateInitialViewController () as UIViewController;
			window.RootViewController = viewController;
			window.MakeKeyAndVisible ();
		}
	}
}