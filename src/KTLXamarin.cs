﻿using System;
using System.Reflection;
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
	}
}

