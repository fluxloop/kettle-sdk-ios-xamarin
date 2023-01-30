using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Kettle.iOS;

namespace XamarinFormsSample.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
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
    }
}

