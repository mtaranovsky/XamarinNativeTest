using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Platform.Plugins;

namespace XamarinNativeTest.Droid.Bootstrap
{
    public class ColorPluginBootstrap
        //: MvxPluginBootstrapAction<MvvmCross.Plugins.Color.PluginLoader>
        : MvxLoaderPluginBootstrapAction<MvvmCross.Plugins.Color.PluginLoader, SomeAbsolutelty.Unconventional.Namespace.CustomColorPlugin>
    {
    }
}