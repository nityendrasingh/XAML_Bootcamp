using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace XAML_Bootcamp.Converters
{
    public class BoolToBorderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string culture)
        {
            // Do the conversion from bool to visibility
            if ((bool)value)
                return new SolidColorBrush(Colors.Red);
            else
                return new SolidColorBrush(Colors.Green);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
    public class BoolToBackgroundConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string culture)
        {
            // Do the conversion from bool to visibility
            if ((bool)value)
                return new SolidColorBrush(Colors.Green);
            else
                return new SolidColorBrush(Colors.LightGreen);
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType,
            object parameter, string culture)
        {
            // Do the conversion from bool to visibility
            if ((bool)value)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType,
            object parameter, string culture)
        {
            throw new NotImplementedException();
        }
    }
}
