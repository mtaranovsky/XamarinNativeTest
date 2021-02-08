using Android.App;
using Android.Content.PM;
using MvvmCross;
using MvvmCross.Droid.Views;

namespace XamarinNativeTest.Droid
{
    [Activity(
        Label = "XamarinNativeTest.Droid"
        , MainLauncher = true
        , NoHistory = true
        , ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashScreen : MvxSplashScreenActivity
    {
        public SplashScreen()
            : base(Resource.Layout.SplashScreen)
        {

        }
    }
}