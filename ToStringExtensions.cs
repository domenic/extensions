using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DomenicDenicola.Extensions
{
    public static class TimeSpanToString
    {
        /// <summary>
        /// Converts a time span to a string representation of the form H:mm.
        /// </summary>
        /// <param name="span">The time span to be formatted.</param>
        /// <returns>The string representation of <paramref name="span"/> in the desired H:mm format.</returns>
        public static string ToHourMinuteString(this TimeSpan span)
        {
            return span.ToHourMinuteString(CultureInfo.CurrentCulture);
        }
        /// <summary>
        /// Converts a time span to a string representation of the form H:mm. A specified parameter supplies culture-specific formatting information.
        /// </summary>
        /// <param name="span">The time span to be formatted.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information. </param>
        /// <returns>The string representation of <paramref name="span"/> in the desired H:mm format, with customizations as specified by <paramref name="provider"/>.</returns>
        public static string ToHourMinuteString(this TimeSpan span, IFormatProvider provider)
        {
            int hours = (int)span.TotalMinutes / 60;
            int minutes = Math.Abs((int)span.TotalMinutes % 60);
            return string.Format(provider, "{0:0}:{1:00}", hours, minutes);
        }
    }

    public static class ColorToString
    {
        private static string ToHexString(byte r, byte g, byte b)
        {
            return string.Format(CultureInfo.InvariantCulture, "{0:X2}{1:X2}{2:X2}", r, g, b);
        }

        /// <summary>
        /// Formats a given color as a hexadecimal string, of the form <c>#RRGGBB</c>.
        /// </summary>
        /// <param name="color">The color to be formatted.</param>
        /// <returns>The string representation of <paramref name="color"/> in the desired <c>#RRGGBB</c> format.</returns>
        public static string ToHexString(this System.Drawing.Color color)
        {
            return ToHexString(color.R, color.G, color.B);
        }

        /// <summary>
        /// Formats a given color as a hexadecimal string, of the form <c>#RRGGBB</c>.
        /// </summary>
        /// <param name="color">The color to be formatted.</param>
        /// <returns>The string representation of <paramref name="color"/> in the desired <c>#RRGGBB</c> format.</returns>
        public static string ToHexString(this System.Windows.Media.Color color)
        {
            return ToHexString(color.R, color.G, color.B);
        }
    }

    public static class Int32ToString
    {
        /// <summary>
        /// Formats a number as a string according to the current culture format info.
        /// </summary>
        /// <param name="number">The number to be formatted.</param>
        /// <returns>A string containing the value of <paramref name="number"/>, according to <see cref="NumberFormatInfo.CurrentInfo"/>.</returns>
        /// <remarks>Spaces in the returned string are replaced with non-breaking spaces (U+00A0), for easier display purposes.</remarks>
        public static string ToFormattedString(this int number)
        {
            return number.ToString("#,0", NumberFormatInfo.CurrentInfo).Replace(' ', '\u00A0');
        }
    }

    public static class IEnumerableOfStringToString
    {
        /// <summary>
        /// Creates a gramatically-correct English listing from the given enumerable collection.
        /// </summary>
        /// <param name="listItems">An enumerable of strings denoting the items to appear in the listing.</param>
        /// <returns>A comma-delimited list of items, following English grammar rules wherein a two-item list has no commas but does have an “and,” and lists with more items have an “and” after the last comma.</returns>
        /// <exception cref="ArgumentNullException"><paramref name="listItems"/> is <see langword="null"/>.</exception>
        public static string ToGrammaticalListString(this IEnumerable<string> list)
        {
            var builder = new StringBuilder();

            string previous = null;
            foreach (string entry in list)
            {
                if (previous != null)
                {
                    builder.Append(previous + ", ");
                }
                previous = entry;
            }

            if (previous != null)
            {
                if (builder.Length > 0)
                {
                    builder.AppendFormat(" and " + previous);
                    return builder.ToString();
                }

                return previous;
            }

            return string.Empty;
        }
    }
}