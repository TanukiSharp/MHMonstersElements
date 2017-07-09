using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace MHMonstersElements
{
    public class SharpnessColorValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((value is MH.SharpnessType) == false)
                return Colors.Transparent;

            var sharp = (MH.SharpnessType)value;

            switch (sharp)
            {
                case MH.SharpnessType.Red: return Colors.Red;
                case MH.SharpnessType.Orange: return Colors.Orange;
                case MH.SharpnessType.Yellow: return Colors.Yellow;
                case MH.SharpnessType.Green: return Colors.Lime;
                case MH.SharpnessType.Blue: return Colors.RoyalBlue;
                case MH.SharpnessType.White: return Colors.White;
                case MH.SharpnessType.Purple: return Colors.Fuchsia;
            }

            return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
