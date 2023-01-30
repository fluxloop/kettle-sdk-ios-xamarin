using System;
using System.Runtime.InteropServices;
using ObjCRuntime;

namespace Kettle.iOS
{
	[Native]
	public enum KTLConsent : ulong
	{
		Surveys = 1001,
		Analytics = 1002,
		Campaigns = 1003,
		Ads = 1004
	}

	[Native]
	public enum KTLLogLevel : long
	{
		Undefined = -1,
		None = 0,
		Error = 1,
		Warn = 2,
		Info = 3,
		Debug = 4,
		Trace = 5,
		Push = 6
	}

	[Native]
	public enum KTLModule : ulong
	{
		Location = 1,
		Activity = 2,
		Bluetooth = 3
	}
}
