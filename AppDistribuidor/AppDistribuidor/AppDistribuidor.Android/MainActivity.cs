﻿using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Content;
using Xamarin.Forms;
using Plugin.CurrentActivity;
using Plugin.LocalNotification;


namespace AppDistribuidor.Droid
{
    [Activity(Label = "AppDistribuidor", Icon = "@mipmap/aqua_launcher", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        Intent serviceIntent;
        public static Activity CurrentActivity;
        private const int RequestCode = 5469;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            CurrentActivity = this;
            base.OnCreate(savedInstanceState);


            LocalNotificationCenter.CreateNotificationChannel();

            //CrossCurrentActivity.Current.Init(this, savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            //serviceIntent = new Intent(this, typeof(AndroidLocationService));
            //SetServiceMethods();

            //if (Build.VERSION.SdkInt >= BuildVersionCodes.M && !Android.Provider.Settings.CanDrawOverlays(this))
            //{
            //    var intent = new Intent(Android.Provider.Settings.ActionManageOverlayPermission);
            //    intent.SetFlags(ActivityFlags.NewTask);
            //    this.StartActivity(intent);
            //}

            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        //void SetServiceMethods()
        //{
        //    MessagingCenter.Subscribe<StartServiceMessage>(this, "ServicioInicio", message => {
        //        if (!IsServiceRunning(typeof(AndroidLocationService)))
        //        {
        //            if (Android.OS.Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
        //            {
        //                StartForegroundService(serviceIntent);
        //            }
        //            else
        //            {
        //                StartService(serviceIntent);
        //            }
        //        }
        //    });

        //    MessagingCenter.Subscribe<StopServiceMessage>(this, "ServicioCancelado", message => {
        //        if (IsServiceRunning(typeof(AndroidLocationService)))
        //            StopService(serviceIntent);
        //    });
        //}


        //private bool IsServiceRunning(System.Type cls)
        //{
        //    ActivityManager manager = (ActivityManager)GetSystemService(Context.ActivityService);
        //    foreach (var service in manager.GetRunningServices(int.MaxValue))
        //    {
        //        if (service.Service.ClassName.Equals(Java.Lang.Class.FromType(cls).CanonicalName))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        //{
        //    if (requestCode == RequestCode)
        //    {
        //        if (Android.Provider.Settings.CanDrawOverlays(this))
        //        {

        //        }
        //    }

        //    base.OnActivityResult(requestCode, resultCode, data);
        //}
    }
}