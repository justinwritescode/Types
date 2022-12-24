/*
 * EmailAddress copy.cs
 *
 *   Created: 2022-12-19-11:36:46
 *   Modified: 2022-12-19-11:36:46
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace System.Net.Mail;
using System.Runtime.InteropServices;

#if NETSTANDARD2_0_OR_GREATER
using Vogen;

[ValueObject(typeof(string), conversions: Conversions.EfCoreValueConverter | Conversions.SystemTextJson | Conversions.TypeConverter)]
#endif
[StructLayout(LayoutKind.Auto)]
public partial record struct EmailAddress
{
    public static readonly EmailAddress Empty = From("nobody@nowhere.nower");

    public const string RegexString = @"\A[\w!#$%&'*+/=?`{|}~^-]+(?:\.[\w!#$%&'*+/=?`{|}~^-]+)*@(?:[A-Z0-9-]+\.)+[A-Z]{2,6}\Z";

#if NET7_0_OR_GREATER
    [GeneratedRegex(RegexString)]
    public static partial REx Regex ();
#else
    public static REx Regex () => new REx(RegexString, Rxo.Compiled);
#endif

    public static Validation Validate(string? s)
    {
        if (s is null) return Validation.Invalid("Email address cannot be null.");
        if (s.Length == 0) return Validation.Invalid("Email address cannot be empty.");
        if (!Regex().IsMatch(s)) return Validation.Invalid("Email address is not valid.");
        return Validation.Ok;
    }

    public static bool operator <(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && a.Value.Value.CompareTo(b.Value.Value) < 0;
    public static bool operator >(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && a.Value.Value.CompareTo(b.Value.Value) > 0;
    public static bool operator <=(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && a.Value.Value.CompareTo(b.Value.Value) <= 0;
    public static bool operator >=(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && a.Value.Value.CompareTo(b.Value.Value) >= 0;
#if NETSTANDARD2_0_OR_GREATER
    public static Validation Validate(MailAddress s) => Validate(s.Address);

    public static implicit operator EmailAddress?(string? s)
    {
        try { return From(s); }
        catch { return default; }
    }

    public static implicit operator string?(EmailAddress? addr) => addr.HasValue ? addr.Value : string.Empty;
#else
    public string Value { get; private set; }
    public static EmailAddress From(string s) => Validate(s) == Validation.Ok ? new() { Value = s } : Empty;
#endif
}
#if NO



    public static implicit operator EmailAddress?(string? s)
    {
        try { return From(s); }
        catch { return default; }
    }

    public static implicit operator string?(EmailAddress? addr) => addr.HasValue ? addr.Value.Value : default;

    public static bool operator <(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && a.Value.Value.CompareTo(b.Value.Value) < 0;
    public static bool operator >(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && a.Value.Value.CompareTo(b.Value.Value) > 0;
    public static bool operator <=(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && a.Value.Value.CompareTo(b.Value.Value) <= 0;
    public static bool operator >=(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && a.Value.Value.CompareTo(b.Value.Value) >= 0;
}

#endif

//"^\+((?:\+|00)[17](?: |\-)?|(?:\+|00)[1-9]\d{0,2}(?: |\-)?|(?:\+|00)1\-\d{3}(?: |\-)?)?(0\d|\([0-9]{3}\)|[1-9]{0,3})(?:((?: |\-)[0-9]{2}){4}|((?:[0-9]{2}){4})|((?: |\-)[0-9]{3}(?: |\-)[0-9]{4})|([0-9]{7}))$"
