using Avalonia;
using Avalonia.Data.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pm.Converters
{
    public class SavePassEntryButtonEnableConverter : IMultiValueConverter
    {
        public object? Convert(IList<object?> values, Type targetType, object? parameter, CultureInfo culture)
        {
            if (values.Count < 2 || values[0] is not string entryName || values[1] is not string entryPass)
            {
                return AvaloniaProperty.UnsetValue;
            }

            return entryName != null && entryName != "" && entryPass != null && entryPass != "";
        }
    }
}
