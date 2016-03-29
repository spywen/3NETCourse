using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace UniversalAppCsharpBindings.Convert
{
    public class YearDateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (DateTime)value;
            return date.Year;
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var stringDate = value as string;
            int year;
            if (Int32.TryParse(stringDate, out year))
            {
                return new DateTime(year, 1, 1);
            }
            return DateTime.Now;
        }
    }
}
