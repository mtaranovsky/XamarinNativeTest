using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Color;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using static XamarinNativeTest.Core.Enums;

namespace XamarinNativeTest.Core.Converters
{
    public class MVXColorConverter : MvxColorValueConverter<TicketPriority>
    {
        protected override MvxColor Convert(TicketPriority value, object parameter, CultureInfo culture)
        {
            var Color = new MvxColor(0,0,0);
            switch (value)
            {
                case TicketPriority.Low:
                    Color = new MvxColor(121, 196, 69);
                    break;
                case TicketPriority.Medium:
                    Color = new MvxColor(247, 148, 22);
                    break;
                case TicketPriority.Top:
                    Color = new MvxColor(255, 0, 0);
                    break;
            }
            return  Color;
        }
    }
}
