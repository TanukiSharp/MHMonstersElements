using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MHMonstersElements
{
    public class TestValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ImageValueConverter : IValueConverter
    {
        private static Dictionary<string, BitmapImage> cache = new Dictionary<string, BitmapImage>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var filename = value as string;

            if (string.IsNullOrWhiteSpace(filename))
                return null;

            var fullFilename = string.Format("{0}\\{1}", App.Path, filename);

            if (File.Exists(fullFilename) == false)
                return null;

            BitmapImage image;
            if (cache.TryGetValue(filename, out image) == false)
            {
                image = new BitmapImage(new Uri(fullFilename, UriKind.Absolute));
                cache.Add(filename, image);
            }

            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
