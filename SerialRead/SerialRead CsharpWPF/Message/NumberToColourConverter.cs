using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace SerialRead_CsharpWPF.Converters
{
    class NumberToColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int number = 0;
            string numberS = (string)value;
            if (value != null && int.TryParse(numberS, out number))
            {

                return new SolidColorBrush(Color.FromArgb((byte)number, (byte)number, (byte)number, (byte)number));
            }
            else
            {
                return "White";
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
