using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Converter
{
    public class BoolToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
            /*
            if ((bool)value)
            {
                return Microsoft.Maui.Graphics.Color.FromRgb(32, 32, 32);
            }
            return Microsoft.Maui.Graphics.Color.FromRgb(34, 34, 34);
            */
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
