/*
 * System.UriExtensions.cs
 *
 *   Created: 2022-10-24-06:07:13
 *   Modified: 2022-11-14-04:11:06
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System;
using @uri = System.Uri;

public static class UriExtensions
{
    public static uri? ToUri(this string uriString, bool throwOnInvalidUri = true)
    {
        if (uriString is null)
            throw new ArgumentNullException(nameof(uriString));
        if (Uri.TryCreate(uriString, UriKind.Absolute, out var uri))
            return uri;
        if (throwOnInvalidUri)
            throw new ArgumentException("The provided string is not a valid URI.", nameof(uriString));
        return null;
    }
}
