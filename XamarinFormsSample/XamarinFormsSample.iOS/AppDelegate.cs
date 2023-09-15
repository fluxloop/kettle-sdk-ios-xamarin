using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Kettle.iOS;
using Firebase.Core;
using ObjCRuntime;
using UserNotifications;
using Firebase.CloudMessaging;

namespace XamarinFormsSample.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate, IUNUserNotificationCenterDelegate, IMessagingDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            // Initialize Firebase
            Firebase.Core.App.Configure();

            if (UIDevice.CurrentDevice.CheckSystemVersion(10,0))
            {
                UNUserNotificationCenter.Current.Delegate = this;

                var authOptions = UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound;
                UNUserNotificationCenter.Current.RequestAuthorization(authOptions, (granted, error) => {
                    Console.WriteLine(granted);
                });

            } else {
                var allNotificationTypes = UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound;
                var settings = UIUserNotificationSettings.GetSettingsForTypes(allNotificationTypes, null);
                UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
            }

            Messaging.SharedInstance.Delegate = this;
            UIApplication.SharedApplication.RegisterForRemoteNotifications();

            // Initialize Kettle
            KTLConfig config = KTLConfig.KTLDefaultConfig();
            config.ProductionApiKey = "6bbaa095cd614680a089840eee426dc1";
            config.DevelopmentApiKey = "ecba028a8f2b4e91a99aa33151c1cdd2";
            config.ProductionLogLevel = KTLLogLevel.Trace;
            config.DevelopmentLogLevel = KTLLogLevel.Trace;

            KTLXamarin.Register();
            KTLKettle.Prepare(config, options);
            

            if (KTLKettle.IsReady)
            {
                Console.WriteLine("Kettle is ready");
                Console.WriteLine("ID: " + KTLKettle.Shared.Identifier);
            } else
            {
                Console.WriteLine("Kettle is not ready.");
            }

            var consents = new[] {
                KTLConsent.Ads,
                KTLConsent.Surveys
            }.Select(
                consent =>
                    NSNumber.FromUnsignedLong((System.nuint)(long) consent)
            ).ToArray();

            KTLKettle.Shared.Grant(consents);

            if (!KTLKettle.Shared.IsEnabledWithModule(KTLModule.Location))
            {
                var locationModule = NSNumber.FromUnsignedLong((System.nuint)(long)KTLModule.Location);
                KTLKettle.Shared.Start(new[] { locationModule });
            }

            if (!KTLKettle.Shared.IsEnabledWithModule(KTLModule.Bluetooth))
            {
                Console.WriteLine("Bluetooth is not enabled");
                var bluetoothModule = NSNumber.FromUnsignedLong((System.nuint)(long)KTLModule.Bluetooth);
                KTLKettle.Shared.Start(new[] { bluetoothModule });
            } else
            {
                Console.WriteLine("Bluetooth is enabled");
            }


            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }

        [Export ("messaging:didReceiveRegistrationToken:")]
        public async void DidReceiveRegistrationToken(Messaging messaging, string fcmToken)
        {
            Console.WriteLine($"Firebase registration token: {fcmToken}");

            try
            {
                await Messaging.SharedInstance.SubscribeAsync("kettle");
                Console.WriteLine("Subscribed to topic 'kettle'");
            } catch (NSErrorException ex)
            {
                Console.WriteLine("Failed to subscribe to 'kettle'", ex);
            }
        }
    }
}

