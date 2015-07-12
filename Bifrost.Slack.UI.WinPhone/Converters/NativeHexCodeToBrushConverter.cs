using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Bifrost.Slack.UI.WinPhone.Converters
{
    public class NativeHexCodeToBrushConverter : IValueConverter
    {
        /// <summary>
        /// Modifies the source data before passing it to the target for display in the UI.
        /// </summary>
        /// <param name="value">The source data being passed to the target.</param>
        /// <param name="targetType">The type of the target property, specified by a helper structure that wraps the type name.</param>
        /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
        /// <param name="language">The language of the conversion.</param>
        /// <returns>The value to be passed to the target dependency property.</returns>
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null) return null;

            var hexStr = value.ToString();
            hexStr = hexStr.Replace("#", "");
            if (hexStr.Length != 6 && hexStr.Length != 8)
                return null;

            byte r = System.Convert.ToByte(hexStr.Substring(0, 2), 16);
            byte g = System.Convert.ToByte(hexStr.Substring(2, 2), 16);
            byte b = System.Convert.ToByte(hexStr.Substring(4, 2), 16);

            var color = Color.FromArgb(255, r, g, b);

            return new SolidColorBrush(color);
        }

        /// <summary>
        /// Modifies the target data before passing it to the source object. This method is called only in <c>TwoWay</c> bindings. 
        /// </summary>
        /// <param name="value">The target data being passed to the source..</param>
        /// <param name="targetType">The type of the target property, specified by a helper structure that wraps the type name.</param>
        /// <param name="parameter">An optional parameter to be used in the converter logic.</param>
        /// <param name="language">The language of the conversion.</param>
        /// <returns>The value to be passed to the source object.</returns>
        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
