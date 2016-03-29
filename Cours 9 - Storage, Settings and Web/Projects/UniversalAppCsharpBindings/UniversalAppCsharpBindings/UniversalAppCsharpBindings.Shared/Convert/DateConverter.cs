using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace UniversalAppCsharpBindings.Convert
{
    public class DateConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var date = (DateTime)value;
            return new DateTimeOffset(date);
        }
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                DateTimeOffset dto = (DateTimeOffset)value;
                return dto.DateTime;
            }
            catch (Exception e)
            {
                return DateTime.MinValue;
            }
        }
    }
}
