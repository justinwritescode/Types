/*
 * StringExtensions.cs
 *
 *   Created: 2022-11-11-06:06:01
 *   Modified: 2022-11-14-04:11:14
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System;

// #if DEFINE_INTERNAL
internal static class StringExtensions
// #else
// public static class StringExtensions
// #endif
{
    /// <summary>Escapes special characters in a string</summary>
    /// <param name="str">The string to escape</param>
    /// <returns>The escaped string</returns>
    public static string Escape(this string str)
    {
        if (str is null)
            throw new ArgumentNullException(nameof(str));
        return str.Replace("&", "\x26").Replace("<", "\x3c").Replace(">", "\x3e").Replace("\"", "\x22").Replace("'", "\x27");
    }
}
