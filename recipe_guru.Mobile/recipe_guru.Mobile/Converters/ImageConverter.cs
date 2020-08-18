﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace recipe_guru.Mobile.Converters
{
    public class ImageConverter 
    {
        public ImageSource Convert(byte[] value)
        {
            if (value == null)
                return null;

            Func<Stream> myFunc = () => new MemoryStream(value);

            return ImageSource.FromStream(myFunc);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
