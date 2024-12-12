using System;
using System.Collections.Generic;
using System.Globalization;
using Avalonia.Data.Converters;

namespace AvaloniaControls.Converters;

public class TextLengthToBoolConverter : IMultiValueConverter
{
    public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
    {
        if ((bool)values[1] == false)
            return false;

        return !(((string)values[0])?.Length > 0);
    }
}