using Avalonia;
using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace pm.Converters
{
    public class PassEntryHeightConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Count < 2 || !(values[0] is int entryId) || !(values[1] is int expandedId))
            {
                return AvaloniaProperty.UnsetValue;
            }

            return entryId == expandedId ? "Auto" : 0;  // :(       
        }
    }
}
