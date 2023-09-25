﻿using System;
using System.IO.Enumeration;
using System.Reflection;
using System.Text.RegularExpressions;
using Intents;
using Kettle.iOS;

namespace Kettle.iOS
{
	public static class KTLXamarin
	{
		public static void Register()
		{
			KTLKettle.SetSdkWithName("Kettle-iOS-Xamarin", (nint)938474749);
			KTLKettle.SetVersionWithVersion("1.0.7", (nint)83746284937);
		}

		public static void RegisterTopic(Action<string> closure)
		{
			const string allKettle = "kettle";
			const string kettleOnboarded = "kettle-onboarded";
			
			var kettleId = KTLKettle.Shared.Identifier;
			var firstNumber = Regex.Match(kettleId, "\\d").ToString().ToLower();
			var firstLetter = Regex.Match(kettleId, "[a-zA-Z]").ToString().ToLower();

			closure.Invoke(allKettle);
			closure.Invoke($"kettle-{firstNumber}-{firstLetter}");

			if (KTLKettle.Shared.Started)
			{
				closure.Invoke(kettleOnboarded);
			}
		}
	}
}

