/*
 * uri.cs
 *
 *   Created: 2022-12-20-04:48:32
 *   Modified: 2022-12-20-04:48:32
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System;

public static partial class TryCreateUriExtensions
{
    public static uri? ToUri(this string uriString) => uriString.CreateUri(true);
    public static uri? ToUri(this string uriString, string defaultFallbackUri) => uri.From(uriString.CreateUri(defaultFallbackUri).ToString());

    public static bool TryCreateUri(this string uriString, out uri? uri)
    {
        try { uri = uriString.CreateUri(true); return true; }
        catch { uri = null; return false; }
    }
    public static uri? CreateUri(this string uriString, bool throwOnInvalidUri = true)
    {
        if (string.IsNullOrEmpty(uriString))
            throw new ArgumentException("The provided URI string is null or empty.", nameof(uriString));
        if (System.uri.TryCreate(uriString, UriKind.Absolute, out var uri))
            return uri;
        if (throwOnInvalidUri)
            throw new ArgumentException("The provided string is not a valid URI.", nameof(uriString));
        return null;
    }
    public static uri CreateUri(this string uriString, string defaultFallbackUri)
    {
        if (string.IsNullOrEmpty(defaultFallbackUri))
            throw new ArgumentException("The provided default fallback URI is null or empty.", nameof(defaultFallbackUri));
        if (string.IsNullOrEmpty(uriString))
            throw new ArgumentException("The provided URI string is null or empty.", nameof(uriString));

        if (System.uri.TryCreate(uriString, UriKind.Absolute, out var uri))
            return uri;
        return System.uri.From(string.Format(defaultFallbackUri, uriString));
    }
}
