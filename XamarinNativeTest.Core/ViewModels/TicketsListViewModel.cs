using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using XamarinNativeTest.Core.Services;

namespace XamarinNativeTest.Core.ViewModels
{
    public class TicketsListViewModel : MvxViewModel
    {
        private readonly IMvxNavigationService _navigationService;
        private readonly ITicketService _ticketService;

        private List<TicketModel> _ticketsList;
        public TicketsListViewModel(ITicketService ticketService)
        {
            _navigationService = Mvx.Resolve<IMvxNavigationService>();
            _ticketService = ticketService;
        }

        public override void ViewAppeared()
        {
            base.ViewAppeared();
            ReloadTickets();
        }

        public void ReloadTickets()
        {
            var list = _ticketService.GetAllTickets();
            TicketsList = list;
         }

        public List<TicketModel> TicketsList
        {
            get { return _ticketsList; }
            set
            {
                _ticketsList = value;
                RaisePropertyChanged(() => TicketsList);
            }
        }

        private string _searchbarText;
        public string SearchBarText
        {
            get { return _searchbarText; }
            set
            {
                _searchbarText = value;
                if (_searchbarText.Length > 2)
                    SearchItems(_searchbarText);
                else
                    ReloadTickets();
                RaisePropertyChanged(() => SearchBarText);
            }
        }

        private void SearchItems(string searchSymbols)
        {
            TicketsList = _ticketService.GetFiltredList(searchSymbols);
        }


        public IMvxCommand ToNewTicketViewCommand => new MvxCommand(ToNewTicketView);
        private void ToNewTicketView()
        {
            _navigationService.Navigate<NewTicketViewModel>();
        }

    }
}
