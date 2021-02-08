using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinNativeTest.Core.Models
{
    public class PriorityButtonModel:MvxViewModel
    {
        public PriorityButtonModel()
        {
        }

        public string Name { get; set; }
        public MvxColor Color { get; set; }
        
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
