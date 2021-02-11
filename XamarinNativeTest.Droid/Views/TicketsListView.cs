using Acr.UserDialogs;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Views.Attributes;
using XamarinNativeTest.Core.ViewModels;

namespace XamarinNativeTest.Droid.Views
{
    [MvxActivityPresentation]
    [Activity(Label = "Tickets List")]
    public class TicketsListView : MvxActivity<TicketsListViewModel>
    {
        protected override void OnViewModelSet()
        {
            SetContentView(Resource.Layout.TicketsListView);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            SetActionBar(toolbar);
            ActionBar.Title = "Tickets List";
            UserDialogs.Init(this);
        }
        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_list, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            ViewModel.ToNewTicketViewCommand.Execute();
            return base.OnMenuItemSelected(featureId, item);
        }
    }
}