namespace System.Domain;
using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using PhoneNumbers;
using Phone = PhoneNumbers.PhoneNumber;
using Util = PhoneNumbers.PhoneNumberUtil;

#if NETSTANDARD2_0_OR_GREATER
using Vogen;
[ValueObject(typeof(string), conversions: Conversions.EfCoreValueConverter | Conversions.SystemTextJson | Conversions.TypeConverter)]
#endif
[StructLayout(LayoutKind.Auto)]
public partial record struct PhoneNumber 
{
    public const string RegexString = @"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0-9]{4,6}$";
    private static readonly Util _util = Util.GetInstance();
    public const string DefaultRegion = "US";
    public string? Number { get; private set; }
    public int? CountryCode => ParsedNumber?.CountryCode;
    public ulong? NationalNumber => ParsedNumber?.NationalNumber;
    public string? Extension => ParsedNumber?.Extension;
    public Phone ParsedNumber => _util.Parse(Value, DefaultRegion);

#if NET7_0_OR_GREATER
    [GeneratedRegex(RegexString)]
    public static partial REx Regex ();
#else
    public static REx Regex() => new(RegexString, Rxo.Compiled);
#endif

    public static implicit operator PhoneNumber?(string? s)
    {
        try { return From(s); }
        catch { return default; }
    }

    public static implicit operator string?(PhoneNumber? n)
        => n.HasValue ? _util.Format(n.Value.ParsedNumber, PhoneNumberFormat.E164) : default;

    public static bool operator <(PhoneNumber? a, PhoneNumber? b)
         => a.HasValue && b.HasValue && a.Value.ToString().CompareTo(b.Value.ToString()) < 0;
    public static bool operator >(PhoneNumber? a, PhoneNumber? b)
        => a.HasValue && b.HasValue && a.Value.ToString().CompareTo(b.Value.ToString()) > 0;
    public static bool operator <=(PhoneNumber? a, PhoneNumber? b)
        => a.HasValue && b.HasValue && a.Value.ToString().CompareTo(b.Value.ToString()) <= 0;
    public static bool operator >=(PhoneNumber? a, PhoneNumber? b)
        => a.HasValue && b.HasValue && a.Value.ToString().CompareTo(b.Value.ToString()) >= 0;

    public static Validation Validate(string s)
        => Util.IsViablePhoneNumber(s) && Regex().IsMatch(s) ?
            Validation.Ok :
            Validation.Invalid("Phone number is not valid.");

#if !NETSTANDARD2_0_OR_GREATER
    public string Value { get; private set; }
    public static PhoneNumber From(string s) => Validate(s) == Validation.Ok ? new PhoneNumber() { Value = _util.Parse(s, DefaultRegion).ToString() } : throw new ArgumentException("Phone number is not valid.", nameof(s));
#endif
}

//"^\+((?:\+|00)[17](?: |\-)?|(?:\+|00)[1-9]\d{0,2}(?: |\-)?|(?:\+|00)1\-\d{3}(?: |\-)?)?(0\d|\([0-9]{3}\)|[1-9]{0,3})(?:((?: |\-)[0-9]{2}){4}|((?:[0-9]{2}){4})|((?: |\-)[0-9]{3}(?: |\-)[0-9]{4})|([0-9]{7}))$"
