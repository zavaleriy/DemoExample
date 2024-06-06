using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace DemoExample.Converters;

public class QuantityBackgroundConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int quantity)
            if (quantity == 0)
                return new SolidColorBrush(Colors.LightGray);

        return new SolidColorBrush(Colors.Transparent);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}