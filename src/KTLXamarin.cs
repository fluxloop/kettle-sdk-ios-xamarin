using System;
using System.Reflection;
using Kettle.iOS;

namespace Kettle.iOS
{
	public static class KTLXamarin
	{
		public static void Register()
		{
			KTLKettle.SetSdkWithName("Xamarin", (nint)938474749);
			KTLKettle.SetVersionWithVersion("0.0.19", (nint)83746284937);
		}
	}
}

