using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DomenicDenicola.Extensions
{
    /// <summary>
    /// Addresses the strange lack of single-separator-accepting Split overloads in the Base Class Library that also take a <see cref="StringSplitOptions"/> parameter.
    /// </summary>
    public static class StringSplitExtensions
    {
        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by the specified Unicode character.
        /// A parameter specifies whether to return empty array elements.
        /// </summary>
        /// <param name="theString">The string to split.</param>
        /// <param name="separator">A Unicode character that delimits the substrings in this string.</param>
        /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned;
        /// or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
        /// <returns>An array whose elements contain the substrings in this string that are delimited by <paramref name="seperator"/>.</returns>
        public static string[] Split(this string theString, char separator, StringSplitOptions options)
        {
            return theString.Split(new char[] { separator }, options);
        }
        /// <summary>
        /// Returns a string array that contains the substrings in this string that are delimited by the specified string.
        /// A parameter specifies whether to return empty array elements.
        /// </summary>
        /// <param name="theString">The string to split.</param>
        /// <param name="separator">A string that delimits the substrings in this string.</param>
        /// <param name="options"><see cref="StringSplitOptions.RemoveEmptyEntries"/> to omit empty array elements from the array returned;
        /// or <see cref="StringSplitOptions.None"/> to include empty array elements in the array returned.</param>
        /// <returns>An array whose elements contain the substrings in this string that are delimited by <paramref name="seperator"/>.</returns>
        public static string[] Split(this string theString, string separator, StringSplitOptions options)
        {
            return theString.Split(new string[] { separator }, options);
        }
    }
}