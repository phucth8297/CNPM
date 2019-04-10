package mono;

import java.io.*;
import java.lang.String;
import java.util.Locale;
import java.util.HashSet;
import java.util.zip.*;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ApplicationInfo;
import android.content.res.AssetManager;
import android.util.Log;
import mono.android.Runtime;

public class MonoPackageManager {

	static Object lock = new Object ();
	static boolean initialized;

	static android.content.Context Context;

	public static void LoadApplication (Context context, ApplicationInfo runtimePackage, String[] apks)
	{
		synchronized (lock) {
			if (context instanceof android.app.Application) {
				Context = context;
			}
			if (!initialized) {
				android.content.IntentFilter timezoneChangedFilter  = new android.content.IntentFilter (
						android.content.Intent.ACTION_TIMEZONE_CHANGED
				);
				context.registerReceiver (new mono.android.app.NotifyTimeZoneChanges (), timezoneChangedFilter);
				
				System.loadLibrary("monodroid");
				Locale locale       = Locale.getDefault ();
				String language     = locale.getLanguage () + "-" + locale.getCountry ();
				String filesDir     = context.getFilesDir ().getAbsolutePath ();
				String cacheDir     = context.getCacheDir ().getAbsolutePath ();
				String dataDir      = getNativeLibraryPath (context);
				ClassLoader loader  = context.getClassLoader ();
				java.io.File external0 = android.os.Environment.getExternalStorageDirectory ();
				String externalDir = new java.io.File (
							external0,
							"Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath ();
				String externalLegacyDir = new java.io.File (
							external0,
							"../legacy/Android/data/" + context.getPackageName () + "/files/.__override__").getAbsolutePath ();

				Runtime.init (
						language,
						apks,
						getNativeLibraryPath (runtimePackage),
						new String[]{
							filesDir,
							cacheDir,
							dataDir,
						},
						loader,
						new String[] {
							externalDir,
							externalLegacyDir
						},
						MonoPackageManager_Resources.Assemblies,
						context.getPackageName ());
				
				mono.android.app.ApplicationRegistration.registerApplications ();
				
				initialized = true;
			}
		}
	}

	public static void setContext (Context context)
	{
		// Ignore; vestigial
	}

	static String getNativeLibraryPath (Context context)
	{
	    return getNativeLibraryPath (context.getApplicationInfo ());
	}

	static String getNativeLibraryPath (ApplicationInfo ainfo)
	{
		if (android.os.Build.VERSION.SDK_INT >= 9)
			return ainfo.nativeLibraryDir;
		return ainfo.dataDir + "/lib";
	}

	public static String[] getAssemblies ()
	{
		return MonoPackageManager_Resources.Assemblies;
	}

	public static String[] getDependencies ()
	{
		return MonoPackageManager_Resources.Dependencies;
	}

	public static String getApiPackageName ()
	{
		return MonoPackageManager_Resources.ApiPackageName;
	}
}

class MonoPackageManager_Resources {
	public static final String[] Assemblies = new String[]{
		/* We need to ensure that "MyAlarm.Android.dll" comes first in this list. */
		"MyAlarm.Android.dll",
		"DryIoc.dll",
		"FFImageLoading.dll",
		"FFImageLoading.Forms.dll",
		"FFImageLoading.Forms.Platform.dll",
		"FFImageLoading.Platform.dll",
		"FFImageLoading.Svg.Forms.dll",
		"FFImageLoading.Svg.Platform.dll",
		"FFImageLoading.Transformations.dll",
		"FormsViewGroup.dll",
		"Microsoft.Data.Sqlite.dll",
		"Microsoft.DotNet.PlatformAbstractions.dll",
		"Microsoft.EntityFrameworkCore.Abstractions.dll",
		"Microsoft.EntityFrameworkCore.Design.dll",
		"Microsoft.EntityFrameworkCore.dll",
		"Microsoft.EntityFrameworkCore.Relational.Design.dll",
		"Microsoft.EntityFrameworkCore.Relational.dll",
		"Microsoft.EntityFrameworkCore.Sqlite.Design.dll",
		"Microsoft.EntityFrameworkCore.Sqlite.dll",
		"Microsoft.Extensions.Caching.Abstractions.dll",
		"Microsoft.Extensions.Caching.Memory.dll",
		"Microsoft.Extensions.Configuration.Abstractions.dll",
		"Microsoft.Extensions.Configuration.Binder.dll",
		"Microsoft.Extensions.Configuration.dll",
		"Microsoft.Extensions.DependencyInjection.Abstractions.dll",
		"Microsoft.Extensions.DependencyInjection.dll",
		"Microsoft.Extensions.DependencyModel.dll",
		"Microsoft.Extensions.Logging.Abstractions.dll",
		"Microsoft.Extensions.Logging.dll",
		"Microsoft.Extensions.Options.dll",
		"Microsoft.Extensions.Primitives.dll",
		"MyAlarm.dll",
		"Newtonsoft.Json.dll",
		"Prism.dll",
		"Prism.DryIoc.Forms.dll",
		"Prism.Forms.dll",
		"Remotion.Linq.dll",
		"SkiaSharp.dll",
		"SkiaSharp.Views.Android.dll",
		"SkiaSharp.Views.Forms.dll",
		"SQLitePCLRaw.batteries_green.dll",
		"SQLitePCLRaw.batteries_v2.dll",
		"SQLitePCLRaw.core.dll",
		"SQLitePCLRaw.lib.e_sqlite3.dll",
		"SQLitePCLRaw.provider.e_sqlite3.dll",
		"System.Buffers.dll",
		"System.Collections.Immutable.dll",
		"System.Diagnostics.DiagnosticSource.dll",
		"System.Interactive.Async.dll",
		"System.Memory.dll",
		"System.Runtime.CompilerServices.Unsafe.dll",
		"Telerik.Xamarin.Android.Chart.dll",
		"Telerik.Xamarin.Android.Common.dll",
		"Telerik.Xamarin.Android.Data.dll",
		"Telerik.Xamarin.Android.Gauges.dll",
		"Telerik.Xamarin.Android.Input.dll",
		"Telerik.Xamarin.Android.List.dll",
		"Telerik.Xamarin.Android.Primitives.dll",
		"Telerik.XamarinForms.Barcode.dll",
		"Telerik.XamarinForms.Chart.dll",
		"Telerik.XamarinForms.Common.dll",
		"Telerik.XamarinForms.ConversationalUI.dll",
		"Telerik.XamarinForms.DataControls.dll",
		"Telerik.XamarinForms.DataGrid.dll",
		"Telerik.XamarinForms.DataVisualization.dll",
		"Telerik.XamarinForms.Input.dll",
		"Telerik.XamarinForms.Primitives.dll",
		"Telerik.XamarinForms.SkiaSharp.dll",
		"Xamarin.Android.Arch.Core.Common.dll",
		"Xamarin.Android.Arch.Lifecycle.Common.dll",
		"Xamarin.Android.Arch.Lifecycle.Runtime.dll",
		"Xamarin.Android.Support.Animated.Vector.Drawable.dll",
		"Xamarin.Android.Support.Annotations.dll",
		"Xamarin.Android.Support.Compat.dll",
		"Xamarin.Android.Support.Core.UI.dll",
		"Xamarin.Android.Support.Core.Utils.dll",
		"Xamarin.Android.Support.Design.dll",
		"Xamarin.Android.Support.Fragment.dll",
		"Xamarin.Android.Support.Media.Compat.dll",
		"Xamarin.Android.Support.Transition.dll",
		"Xamarin.Android.Support.v4.dll",
		"Xamarin.Android.Support.v7.AppCompat.dll",
		"Xamarin.Android.Support.v7.CardView.dll",
		"Xamarin.Android.Support.v7.MediaRouter.dll",
		"Xamarin.Android.Support.v7.Palette.dll",
		"Xamarin.Android.Support.v7.RecyclerView.dll",
		"Xamarin.Android.Support.Vector.Drawable.dll",
		"Xamarin.Forms.Core.dll",
		"Xamarin.Forms.Platform.Android.dll",
		"Xamarin.Forms.Platform.dll",
		"Xamarin.Forms.Xaml.dll",
		"Logic.dll",
		"MyAlarm.EFStandard.dll",
	};
	public static final String[] Dependencies = new String[]{
	};
	public static final String ApiPackageName = "Mono.Android.Platform.ApiLevel_27";
}