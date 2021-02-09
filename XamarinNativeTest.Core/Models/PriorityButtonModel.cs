using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.UI;
using System;
using System.Collections.Generic;
using System.Text;
using static XamarinNativeTest.Core.Enums;

namespace XamarinNativeTest.Core.Models
{
    public class PriorityButtonModel:MvxViewModel
    {
        public PriorityButtonModel(TicketPriority ticketPriority)
        {
            Name = ticketPriority.ToString();
            TicketPriority = ticketPriority;
        }
        public string Name { get; set; }
        public TicketPriority TicketPriority { get; set; }

        private bool isVis = false;
        public bool IsVis {
            get { return isVis; }
            set
            {
                isVis = value;
                RaisePropertyChanged(() => IsVis);
            } 
        }
    }
}
