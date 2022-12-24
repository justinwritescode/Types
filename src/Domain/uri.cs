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

using System.Runtime.InteropServices;

namespace System;
#if NETSTANDARD2_0_OR_GREATER
using Vogen;

[ValueObject(typeof(string), conversions: Conversions.EfCoreValueConverter | Conversions.SystemTextJson | Conversions.TypeConverter)]
[StructLayout(LayoutKind.Auto)]
#endif
public partial record struct uri
{
    public const string EmptyValue = "about:blank";
    public static readonly uri Empty = From(EmptyValue);
    public static implicit operator Uri(uri value) => new (value.Value);
    public static Validation Validate(string value)
    {
        if (value is null)
        {
            return Validation.Invalid("Cannot create a value object with null.");
        }
        else if(!Uri.TryCreate(value, UriKind.RelativeOrAbsolute, out _))
        {
            return Validation.Invalid("The value is not a valid URI.");
        }

        return Validation.Ok;
    }

    public static bool TryCreate(string? uriString, UriKind uriKind, out uri uri)
    {
        if (string.IsNullOrEmpty(uriString))
        {
            uri = Empty;
            return false;
        }
        if (Uri.TryCreate(uriString, uriKind, out var suri))
        {
            uri = From(suri.ToString());
            return true;
        }
        uri = Empty;
        return false;
    }

#if !NETSTANDARD2_0_OR_GREATER
    public static uri From(string s) => Validate(s) == Validation.Ok ? new() { Value = s } : Empty;
    public string Value { get; private set; }
#endif
}
