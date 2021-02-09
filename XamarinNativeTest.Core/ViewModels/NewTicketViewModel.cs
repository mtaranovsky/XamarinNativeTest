using MvvmCross.Core.Navigation;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using XamarinNativeTest.Core.Models;
using XamarinNativeTest.Core.Services;
using static XamarinNativeTest.Core.Enums;

namespace XamarinNativeTest.Core.ViewModels
{
    public class NewTicketViewModel : MvxViewModel
    {
        private readonly ITicketService _ticketService;
        public List<PriorityButtonModel> priorityList = new List<PriorityButtonModel>() {
            new PriorityButtonModel(TicketPriority.Low),
            new PriorityButtonModel(TicketPriority.Medium),
            new PriorityButtonModel(TicketPriority.Top) 
        };


        public NewTicketViewModel(ITicketService ticketService)
        {
            _ticketService = ticketService;
            Buttons = priorityList;
        }

        private string _problemName;
        public string ProblemName
        {
            get { return _problemName; }
            set
            {
                _problemName = value;
                RaisePropertyChanged(() => ProblemName);
            }
        }

        private List<PriorityButtonModel> _buttons;
        public List<PriorityButtonModel> Buttons
        {
            get { return _buttons; }
            set
            {
                _buttons = value;
                RaisePropertyChanged(() => Buttons);
            }
        }

        private MvxCommand<PriorityButtonModel> _buttonClickedCommand;
        public ICommand ButtonClickedCommand
        {
            get
            {
                return _buttonClickedCommand = _buttonClickedCommand ??
                    new MvxCommand<PriorityButtonModel>(button => {

                        Buttons.ForEach(m => m.IsVis = false);
                        button.IsVis = true;
            }       );
            }
        }

        public IMvxCommand SaveClickedCommand => new MvxCommand(AddTicket);
        private void AddTicket()
        {
            if (!string.IsNullOrEmpty(ProblemName) && Buttons.Count(m => m.IsVis == true) == 1)
            {
                var ticket = new TicketModel() { ProblemName = ProblemName, TicketPriority = Buttons.FirstOrDefault(m => m.IsVis).TicketPriority};
                _ticketService.AddTicketToJson(ticket);
                Close(this);
            }
        }
    }
}
