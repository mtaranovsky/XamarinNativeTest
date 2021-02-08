using Android.Content;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;

using MvvmCross.Plugins.Color;
using MvvmCross.Plugins.Visibility;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using XamarinNativeTest.Core;
using XamarinNativeTest.Core.Services;

namespace XamarinNativeTest.Droid
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
        protected override IEnumerable<Assembly> ValueConverterAssemblies
        {
            get
            {
                var toReturn = base.ValueConverterAssemblies as IList;
                toReturn.Add(typeof(MvxNativeColorValueConverter).Assembly);
                toReturn.Add(typeof(MvxVisibilityValueConverter).Assembly);
                return (IEnumerable<Assembly>)toReturn;
            }
        }
        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<ITicketJsonLoccationServices, TicketsJsonLocationService>();
        }
    }
}