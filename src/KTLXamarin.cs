using System;
using System.IO.Enumeration;
using System.Reflection;
using System.Text.RegularExpressions;
using Intents;
using Kettle.iOS;

namespace Kettle.iOS
{
	public static class KTLXamarin
	{		
		public static void RegisterTopic(Action<string> closure)
		{
			const string allKettle = "kettle";
			const string kettleOnboarded = "kettle-onboarded";
			
			var kettleId = KTLKettle.Shared.Identifier;
			var firstTwoChars = kettleId.ToLower().Substring(0, 2);

			closure.Invoke(allKettle);
            Console.WriteLine($"Registering to topic kettle");

            closure.Invoke($"kettle-{firstTwoChars}");
            Console.WriteLine($"Registering to topic kettle-{firstTwoChars}");

            if (KTLKettle.Shared.Started)
			{
				closure.Invoke(kettleOnboarded);
                Console.WriteLine($"Registering to topic kettle-onboarded");
            }
		}
	}
}

