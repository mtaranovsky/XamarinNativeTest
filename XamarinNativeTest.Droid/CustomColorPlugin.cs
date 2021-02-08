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
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;
using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Color.Droid;
using MvvmCross.Plugins.Color.Droid.BindingTargets;

namespace SomeAbsolutelty.Unconventional.Namespace
{
    public class CustomColorPlugin : IMvxPlugin
    {
        public void Load()
        {
            Console.WriteLine("-------- This plugin is loaded instead of the default");
            Mvx.RegisterSingleton<IMvxNativeColor>(new MvxAndroidColor());
            Mvx.CallbackWhenRegistered<IMvxTargetBindingFactoryRegistry>(RegisterDefaultBindings);
        }

        private void RegisterDefaultBindings()
        {
            var helper = new MvxDefaultColorBindingSet();
            helper.RegisterBindings();
        }
    }
}