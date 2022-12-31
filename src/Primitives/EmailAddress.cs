using System.Net.Sockets;
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
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq.Expressions;

[ValueObject(typeof(string), conversions: Conversions.EfCoreValueConverter | Conversions.SystemTextJson | Conversions.TypeConverter)]
#endif
[StructLayout(LayoutKind.Auto)]
public partial record struct EmailAddress : IStringWithRegexValueObject<EmailAddress>, IComparable<EmailAddress>, IComparable, IEquatable<EmailAddress>, IFormattable
{
    public const string ExampleValueString = "somewhere@overtherainbow.com";
    public const string EmptyValueString = "nobody@nowhere.com";
    public const string Description = "an email address in the form of *user@domain.ext*";
#if NET6_0_OR_GREATER
    static string IStringWithRegexValueObject<EmailAddress>.Description => Description;
    static EmailAddress IStringWithRegexValueObject<EmailAddress>.ExampleValue => From(ExampleValueString);
    static string IStringWithRegexValueObject<EmailAddress>.RegexString => RegexString;
#else
    REx IStringWithRegexValueObject<EmailAddress>.Regex() => Regex();
    string IStringWithRegexValueObject<EmailAddress>.RegexString => RegexString;
    string IStringWithRegexValueObject<EmailAddress>.Description => Description;
    EmailAddress IStringWithRegexValueObject<EmailAddress>.ExampleValue => From(ExampleValueString);
#endif

    public bool IsEmpty => Value == Empty.Value;
    public static EmailAddress Empty => From(EmptyValueString);

    public const string RegexString = @"^(?<Username>[\w\-_\.]+)@(?<Domain>[\w\-_\.]+)\.(?<Tld>[\w\-_\.]+)$";

#if NET7_0_OR_GREATER
    [GeneratedRegex(RegexString)]
    public static partial REx Regex ();
#else
    public static REx Regex () => new(RegexString, Rxo.Compiled);
#endif

    public static Validation Validate(string? s)
    =>  s is null ? Validation.Invalid("Email address cannot be null.")
            : s.Length == 0
            ? Validation.Invalid("Email address cannot be empty.")
            : !Regex().IsMatch(s) ? Validation.Invalid("Email address is not valid.") : Validation.Ok;

    public static bool operator !=(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) == 0;

    public static bool operator ==(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) != 0;

    public static bool operator <(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) < 0;
    public static bool operator >(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) > 0;
    public static bool operator <=(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) <= 0;
    public static bool operator >=(EmailAddress? a, EmailAddress? b)
        => a.HasValue && b.HasValue && string.CompareOrdinal(a.Value.Value, b.Value.Value) >= 0;

    public string ToString(string? format, IFormatProvider? formatProvider) => ToString();
    public override string ToString() => IsEmpty ? string.Empty : Value;

    public int CompareTo(object? obj) => string.CompareOrdinal(Value, obj?.ToString() ?? string.Empty);

    public static EmailAddress Parse(string s, IFormatProvider? formatProvider = null) => From(s);
    public static bool TryParse(string s, IFormatProvider? formatProvider, out EmailAddress email) => (email = TryParse(s, out var email1) ? email1!.Value : Empty) != Empty;
    public static bool TryParse(string s, out EmailAddress? email)
    {
        try { email = From(s); return true; }
        catch { email = null; return false; }
    }


#if NETSTANDARD2_0_OR_GREATER
    public static Validation Validate(MailAddress s) => Validate(s.Address);
    public static EmailAddress Parse(string value) => From(value);
    public static implicit operator EmailAddress?(string? s)
    {
        try { return From(s); }
        catch { return Empty; }
    }

    public static implicit operator string?(EmailAddress? addr) => addr.HasValue ? addr.Value.Value : string.Empty;
#else
    public string Value { get; private set; }

    public int CompareTo(EmailAddress? other) => CompareTo(other?.Value ?? string.Empty);
    public int CompareTo(EmailAddress other) => CompareTo(other.Value);
    public static EmailAddress From(string s) => Validate(s) == Validation.Ok ? new() { Value = s } : Empty;
    public static EmailAddress Parse(string value) => From(value);
#endif
}

#if NETSTANDARD2_0_OR_GREATER
public static class EmailAddressEfCoreExtensions
{
    public static void ConfigureEmailAddress<TEntity>(this ModelBuilder modelBuilder, Expression<Func<TEntity, EmailAddress>> propertyExpression)
        where TEntity : class
        => modelBuilder.Entity<TEntity>().ConfigureEmailAddress(propertyExpression);

    public static void ConfigureEmailAddress<TEntity>(this EntityTypeBuilder<TEntity> entityBuilder, Expression<Func<TEntity, EmailAddress>> propertyExpression)
        where TEntity : class
        => entityBuilder.Property(propertyExpression).HasConversion<EmailAddress.EfCoreValueConverter>();
}
#endif

//"^\+((?:\+|00)[17](?: |\-)?|(?:\+|00)[1-9]\d{0,2}(?: |\-)?|(?:\+|00)1\-\d{3}(?: |\-)?)?(0\d|\([0-9]{3}\)|[1-9]{0,3})(?:((?: |\-)[0-9]{2}){4}|((?:[0-9]{2}){4})|((?: |\-)[0-9]{3}(?: |\-)[0-9]{4})|([0-9]{7}))$"
