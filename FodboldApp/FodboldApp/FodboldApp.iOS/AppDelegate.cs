﻿using System;
using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.iOS;
using FFImageLoading.Forms.Touch;
using Foundation;
using ImageCircle.Forms.Plugin.iOS;
using Plugin.CrossPlatformTintedImage.iOS;
using UIKit;
using RoundedBoxView.Forms.Plugin.Droid;

namespace FodboldApp.iOS
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
            global::Xamarin.Forms.Forms.Init();
            ImageCircleRenderer.Init();

            var statusBar = UIApplication.SharedApplication.ValueForKey(new NSString("statusBar")) as UIView;
            if (statusBar.RespondsToSelector(new ObjCRuntime.Selector("setBackgroundColor:")))
            {
                statusBar.BackgroundColor = UIColor.FromRGB(251, 67, 60);
                statusBar.TintColor = UIColor.White;
            }
            LoadApplication(new App());
            TintedImageRenderer.Init();
            CachedImageRenderer.Init();
            RoundedBoxViewRenderer.Init();
            CarouselViewRenderer.Init();


            return base.FinishedLaunching(app, options);
        }
    }
}
