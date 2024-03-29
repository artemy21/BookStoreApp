﻿using System;
using System.Windows.Data;

namespace LibraryApp2.General
{
    [ValueConversion(typeof(object), typeof(string))]
    public class ObjectToTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => value?.GetType().Name;
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            => throw new InvalidOperationException();
    }
}
