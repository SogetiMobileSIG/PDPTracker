using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using SQLitePCL;

namespace PDPTracker.Droid
{
    [Activity (Label = "PDP Tracker", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate (bundle);

            global::Xamarin.Forms.Forms.Init (this, bundle);
            raw.SetProvider (new SQLite3Provider_e_sqlite3 ());

            LoadApplication (new App ());
        }
    }
}

