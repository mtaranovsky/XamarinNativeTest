using Acr.UserDialogs;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Views.Attributes;
//using MvvmCross.Plugins.Color.Droid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinNativeTest.Core.ViewModels;

namespace XamarinNativeTest.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "NewTicketView")]
    public class NewTicketView : MvxActivity<NewTicketViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.NewTicketView);

            var toolbar = FindViewById<Android.Widget.Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            
            ActionBar.Title = "Add Ticket";
            UserDialogs.Init(this);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_add, menu);
            return base.OnCreateOptionsMenu(menu);
        }

      public override bool OnMenuItemSelected(int featureId, IMenuItem item)
      {
          ViewModel.SaveClickedCommand.Execute();
          return base.OnMenuItemSelected(featureId, item);
      }

    }
}