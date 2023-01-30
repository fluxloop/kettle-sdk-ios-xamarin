using System;
using Foundation;
using ObjCRuntime;

namespace Kettle.iOS
{
	// @interface KTLKettle : NSObject
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface KTLKettle
	{
		// @property (readonly, nonatomic, class) BOOL isReady;
		[Static]
		[Export ("isReady")]
		bool IsReady { get; }

		// @property (nonatomic, class) enum KTLLogLevel logLevel;
		[Static]
		[Export ("logLevel", ArgumentSemantic.Assign)]
		KTLLogLevel LogLevel { get; set; }

		// @property (readonly, nonatomic, class) NSNotificationName _Nonnull kettleReadyNotification;
		[Static]
		[Export ("kettleReadyNotification")]
		string KettleReadyNotification { get; }

		// @property (readonly, nonatomic, strong, class) KTLKettle * _Nonnull shared;
		[Static]
		[Export ("shared", ArgumentSemantic.Strong)]
		KTLKettle Shared { get; }

		// +(void)prepareWithLaunchOptions:(NSDictionary<UIApplicationLaunchOptionsKey,id> * _Nullable)launchOptions;
		[Static]
		[Export ("prepareWithLaunchOptions:")]
		void PrepareWithLaunchOptions ([NullAllowed] NSDictionary<NSString, NSObject> launchOptions);

		// +(void)prepare:(KTLConfig * _Nullable)config launchOptions:(NSDictionary<UIApplicationLaunchOptionsKey,id> * _Nullable)launchOptions;
		[Static]
		[Export ("prepare:launchOptions:")]
		void Prepare ([NullAllowed] KTLConfig config, [NullAllowed] NSDictionary launchOptions);

		// +(void)setVersionWithVersion:(NSString * _Nonnull)version saneCheck:(NSInteger)saneCheck;
		[Static]
		[Export ("setVersionWithVersion:saneCheck:")]
		void SetVersionWithVersion (string version, nint saneCheck);

		// +(void)setSdkWithName:(NSString * _Nonnull)name saneCheck:(NSInteger)saneCheck;
		[Static]
		[Export ("setSdkWithName:saneCheck:")]
		void SetSdkWithName (string name, nint saneCheck);

		// -(void)start:(NSArray<NSNumber *> * _Nonnull)modules;
		[Export ("start:")]
		void Start (NSNumber[] modules);

		// -(BOOL)isEnabledWithModule:(enum KTLModule)module_ __attribute__((warn_unused_result("")));
		[Export ("isEnabledWithModule:")]
		bool IsEnabledWithModule (KTLModule module_);

		// -(void)stop:(NSArray<NSNumber *> * _Nonnull)modules;
		[Export ("stop:")]
		void Stop (NSNumber[] modules);

		// -(void)grant:(NSArray<NSNumber *> * _Nonnull)consents;
		[Export ("grant:")]
		void Grant (NSNumber[] consents);

		// -(void)revoke:(NSArray<NSNumber *> * _Nonnull)consents;
		[Export ("revoke:")]
		void Revoke (NSNumber[] consents);

		// @property (readonly, copy, nonatomic) NSString * _Nonnull privacyDashboardUrl;
		[Export ("privacyDashboardUrl")]
		string PrivacyDashboardUrl { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull privacyKey;
		[Export ("privacyKey")]
		string PrivacyKey { get; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull identifier;
		[Export ("identifier")]
		string Identifier { get; }
	}

    // @interface KTLConfig : NSObject <NSCopying>
    [BaseType (typeof(NSObject))]
	interface KTLConfig : INSCopying
	{
		// @property (copy, nonatomic) NSString * _Nullable developmentApiKey;
		[NullAllowed, Export ("developmentApiKey")]
		string DevelopmentApiKey { get; set; }

		// @property (copy, nonatomic) NSString * _Nullable productionApiKey;
		[NullAllowed, Export ("productionApiKey")]
		string ProductionApiKey { get; set; }

		// @property (nonatomic) enum KTLLogLevel developmentLogLevel;
		[Export ("developmentLogLevel", ArgumentSemantic.Assign)]
		KTLLogLevel DevelopmentLogLevel { get; set; }

		// @property (nonatomic) enum KTLLogLevel productionLogLevel;
		[Export ("productionLogLevel", ArgumentSemantic.Assign)]
		KTLLogLevel ProductionLogLevel { get; set; }

		// @property (nonatomic) BOOL deleteOnUpload;
		[Export ("deleteOnUpload")]
		bool DeleteOnUpload { get; set; }

		// @property (nonatomic) BOOL inProduction;
		[Export ("inProduction")]
		bool InProduction { get; set; }

		// @property (readonly, copy, nonatomic) NSString * _Nonnull apiKey;
		[Export ("apiKey")]
		string ApiKey { get; }

		// @property (readonly, nonatomic) enum KTLLogLevel logLevel;
		[Export ("logLevel")]
		KTLLogLevel LogLevel { get; }

		// +(KTLConfig * _Nonnull)KTLDefaultConfig __attribute__((warn_unused_result("")));
		[Static]
		[Export("KTLDefaultConfig")]
		KTLConfig KTLDefaultConfig();

		// +(KTLConfig * _Nonnull)config __attribute__((warn_unused_result("")));
		[Static]
		[Export("config")]
		KTLConfig Config();

		// @property (readonly, copy, nonatomic) NSString * _Nonnull description;
		[Export ("description")]
		string Description { get; }

		// -(BOOL)validate __attribute__((warn_unused_result("")));
		[Export("validate")]
		bool Validate();
	}
}
