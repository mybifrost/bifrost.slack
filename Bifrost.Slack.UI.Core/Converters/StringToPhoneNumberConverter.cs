using Cirrious.CrossCore.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bifrost.Slack.UI.Core.Converters
{
    public class StringToPhoneNumberConverter : MvxValueConverter<string, string>
    {
        protected override string Convert(string value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // do nothing for null or empty strings
            if (string.IsNullOrEmpty(value))
                return value;

            // pull out non-digit characters from the string
            var digits = value.ToCharArray().Where(c => c >= '0' && c <= '9');
            var digitsStr = new string(digits.ToArray<char>());

            // build the string, checking the length before appending each segment
            var builder = new StringBuilder();
            
            if (digitsStr.Length > 0)
            {
                builder.Append('(');
                builder.Append(digitsStr.Substring(0, 3));
                builder.Append(')');
            }
            if (digitsStr.Length > 3)
            {
                builder.Append(' ');
                builder.Append(digitsStr.Substring(3, 3));
            }
            if (digitsStr.Length > 6)
            {
                builder.Append('-');
                builder.Append(digitsStr.Substring(6, 4));
            }

            // return the formatted string
            return builder.ToString();
        }
    }
}
