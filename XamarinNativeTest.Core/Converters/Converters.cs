using MvvmCross.Platform.UI;
using MvvmCross.Plugins.Color;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace XamarinNativeTest.Core.Converters
{
    public class MVXColorConverter : MvxColorValueConverter
    {
        protected override MvxColor Convert(object value, object parameter, CultureInfo culture)
        {
            return  (MvxColor)value;
        }
    }
}
