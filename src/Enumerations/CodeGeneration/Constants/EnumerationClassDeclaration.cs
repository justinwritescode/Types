//
// EnumerationClassDeclaration.cs
//
//   Created: 2022-10-16-12:10:27
//   Modified: 2022-10-30-04:29:58
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022-2023 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace JustinWritesCode.Enumerations.CodeGeneration;

public static partial class Constants
{
    // public static readonly string EnumerationClassDeclaration =
    //     new StreamReader(typeof(Constants).Assembly.GetManifestResourceStream("JustinWritesCode.Enumerations.CodeGeneration.Resources.EnumerationClassDeclaration.cs")).ReadToEnd().TrimFromSentinel();
    /*@"

namespace {Namespace};

public class {EnumerationClassName} : JustinWritesCode.Enumerations.Enumeration<{EnumerationClassName}, {EnumType}>
{
    public {EnumerationClassName}(int id, string name, string toStringProperty = null, string comparisonProperty = null) : base(id, name, ({EnumType})id) { }

    public static {EnumerationClassName}[] Values = new[] { {Values} };

    {Fields}
}
";*/
    public const string EnumerationClassDeclaration =
$$$""""

namespace {{ namespace }};
#nullable enable
using System.Runtime.CompilerServices;
using System;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;
using JustinWritesCode.Abstractions;
using JustinWritesCode.Enumerations;
using System.CodeDom.Compiler;
using {{ enum_namespace }};

/**
    {{ documentation }}
*/
[Serializable]
[DebuggerDisplay("{DisplayName} - {Value}")]
[CompilerGenerated]
[{{{GeneratedCodeAttribute}}}]
public {{ is_readonly }} partial {{ enumeration_type }} {{ enumeration_class_name }} : IEnumeration, IEnumeration<{{ enumeration_class_name}}, {{ id_type }}>, IEquatable<{{ value_type }}>, IComparable<{{ value_type }}>, IHaveAValue<{{ value_type }}>, IHaveAValue, IIdentifiable<{{ id_type }}>, IIdentifiable, IComparable<{{ enumeration_class_name}}>, IEquatable<{{ enumeration_class_name}}>
{
    [{{{GeneratedCodeAttribute}}}]
    public {{ enumeration_class_name }}({{ id_type }} id, {{ value_type }} value, string name)
    {
        Id = id;
        Value = value;
        Name = name;
    }

    [{{{GeneratedCodeAttribute}}}]
    public static readonly {{ enumeration_class_name }}[] Values = new[] { {{ values }} };

    {{ fields }}

    /// <summary>Gets the underlying value of the enumeration.</summary>
    /// <returns>The underlying value of the enumeration.</returns>
    public {{ value_type }} Value { get; init; }
    /// <summary>Gets the numeric ID of the enumeration.</summary>
    /// <returns>The numeric ID of the enumeration.</returns>
    public {{ id_type }} Id { get; init; }
    object IIdentifiable.Id => Id;
    object IHaveAValue.Value => Value;
    /// <summary>Gets the field info of the backing type of the enumeration.</summary>
    /// <returns>The field info of the backing type of the enumeration.</returns>
    public FieldInfo? FieldInfo => GetType().GetField(Name);
    private Func<IEnumeration, string> ToStringDelegate { get; init; } = e => e.DisplayName;
    /// <summary>Gets the custom attribute of type <typeparamref name="TAttribute"/> from the enumeration's <see cref="FieldInfo" />.</summary>
    public TAttribute? GetCustomAttribute<TAttribute>() where TAttribute : Attribute
        => ((IEnumeration)this).GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>() as TAttribute;
    /// <summary>Gets the <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute" /> of the enumeration'<see cref="FieldInfo" />.</summary>
    public System.ComponentModel.DataAnnotations.DisplayAttribute? DisplayAttribute => GetCustomAttribute<System.ComponentModel.DataAnnotations.DisplayAttribute>();

    /// <summary>Gets the short name of the enumeration as pulled from the <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute" />.</summary>
    [FromString]
    public string ShortName => DisplayAttribute?.ShortName ?? Name;
    /// <summary>Gets the description of the enumeration as pulled from the <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute" />.</summary>
    public string Description => DisplayAttribute?.Description ?? Name;
    /// <summary>Gets the display name of the enumeration as pulled from the <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute" />.</summary>
    [FromString]
    public string DisplayName => DisplayAttribute?.Name ?? Name;
    /// <summary>Gets the group name of the enumeration as pulled from the <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute" />.</summary>
    public string GroupName => DisplayAttribute?.GroupName ?? Enumeration.NoGroup;
    /// <summary>Gets the order of the enumeration as pulled from the <see cref="System.ComponentModel.DataAnnotations.DisplayAttribute" />.</summary>
    public int Order => DisplayAttribute?.Order ?? Enumeration.DefaultOrder;

    /// <summary>Gets the name of the enumeration.</summary>
    public string Name { get; init; }

    /// <summary>Gets the enumeration's value as a string.</summary>
    public override string ToString() => ToStringDelegate(this);

    public int CompareTo(object other) => other is IEnumeration ? CompareTo((IEnumeration)other) : -1;
    public int CompareTo(IEnumeration other) => Id.CompareTo(other.Id);
    // public override bool Equals(object other) => other is IEnumeration && CompareTo(other) == 0;
    public bool Equals(IEnumeration other) => GetHashCode() == other.GetHashCode();
    public override int GetHashCode() => Id.GetHashCode();

    public TypeCode GetTypeCode() => Convert.GetTypeCode(Value);

    #region type conversions
    /// <summary>Converts the value of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent string representation.</summary>
    public object ToType(Type conversionType, IFormatProvider? provider = null) => Convert.ChangeType(Value, conversionType);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="bool" /> representation (if it exists).</summary>
    public bool ToBoolean(IFormatProvider? provider = null) => Convert.ToBoolean(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="byte" /> representation (if it exists).</summary>
    public byte ToByte(IFormatProvider? provider = null) => Convert.ToByte(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="char" /> representation (if it exists).</summary>
    public char ToChar(IFormatProvider? provider = null) => Convert.ToChar(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see cref="DateTime" /> representation (if it exists).</summary>
    public DateTime ToDateTime(IFormatProvider? provider = null) => Convert.ToDateTime(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="decimal" /> representation (if it exists).</summary>
    public decimal ToDecimal(IFormatProvider? provider = null) => Convert.ToDecimal(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="double" /> representation (if it exists).</summary>
    public double ToDouble(IFormatProvider? provider = null) => Convert.ToDouble(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="short" /> representation (if it exists).</summary>
    public short ToInt16(IFormatProvider? provider = null) => Convert.ToInt16(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="int" /> representation (if it exists).</summary>
    public int ToInt32(IFormatProvider? provider = null) => Convert.ToInt32(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="long" /> representation (if it exists).</summary>
    public long ToInt64(IFormatProvider? provider = null) => Convert.ToInt64(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="sbyte" /> representation (if it exists).</summary>
    public sbyte ToSByte(IFormatProvider? provider = null) => Convert.ToSByte(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="float" /> representation (if it exists).</summary>
    public float ToSingle(IFormatProvider? provider = null) => Convert.ToSingle(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="string" /> representation (if it exists).</summary>
    public string ToString(IFormatProvider? provider = null) => ToString();

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="ushort" /> representation (if it exists).</summary>
    public ushort ToUInt16(IFormatProvider? provider = null) => Convert.ToUInt16(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="uint" /> representation (if it exists).</summary>
    public uint ToUInt32(IFormatProvider? provider = null) => Convert.ToUInt32(Value, provider);

    /// <summary>Converts the <see cref="Value" /> of the current <see cref="{{ enumeration_class_name }}" /> object to its equivalent <see langword="ulong" /> representation (if it exists).</summary>
    public ulong ToUInt64(IFormatProvider? provider = null) => Convert.ToUInt64(Value, provider);
    #endregion

    /// <summary>Converts the <paramref name="value"/> to a data structure of type <paramref name="t" />.</summary>
    /// <param name="t">The type of the enumeration.</param>
    /// <param name="value">The value to parse.</param>
    public static IEnumeration? FromValue(Type t, object value) => Parse(t, x => x.Value.Equals(value));

    /// <summary>Converts the <paramref name="value"/> to a data structure of type <typeparamref name="TEnumeration" />.</summary>
    public static TEnumeration? FromValue<TEnumeration>(object value) where TEnumeration : class, IEnumeration => FromValue(typeof(TEnumeration), value) as TEnumeration;

    /// <summary>Retrieves a list of values that are members of the enumeration.</summary>
    /// <param name="t">The type of the enumeration.</param>
    public static IEnumeration[] GetValues(Type t) => t.GetRuntimeFields().Select(f => f.GetValue(null)).OfType<IEnumeration>().ToArray();

    /// <summary>Retrieves a list of values that are members of the enumeration.</summary>
    public static TEnumeration[] GetValues<TEnumeration>() => GetValues(typeof(TEnumeration)).OfType<TEnumeration>().ToArray();

    /// <summary>Retrieves a list of <see cref="PropertyInfo"/>s that can be used to convert <see langword="string" />s to the enumeration <paramref name="t" />.</summary>
    private static IEnumerable<PropertyInfo> GetFromStringProperties(Type t)
        => t.GetRuntimeProperties().Where(p => p.GetCustomAttribute<FromStringAttribute>() != null);

    /// <summary>Retrieves a list of <see cref="PropertyInfo"/>s that can be used to convert <see langword="string" />s to the enumeration <typeparamref name="TEnumeration" />.</summary>
    private static IEnumerable<PropertyInfo> GetFromStringProperties<TEnumeration>()
        => GetFromStringProperties(typeof(TEnumeration));

    /// <summary>Parses the <paramref name="value" /> to an object of type <paramref name="t" />, which implements <see cref="IEnumeration"/>.</summary>
    /// <param name="t">The type of the enumeration.</param>
    /// <param name="value">The value to parse.</param>
    public static IEnumeration? Parse(Type t, string value) => Parse(t, e => GetFromStringProperties(t).Any(p => p.GetValue(null) as string == value));

    /// <summary>Parses the <paramref name="value" /> to an object of type <typeparamref name="TEnumeration" />.</summary>
    public static TEnumeration? Parse<TEnumeration>(string value) where TEnumeration : IEnumeration
        => Parse<TEnumeration>(e => GetFromStringProperties<TEnumeration>().Any(p => p.GetValue(null) as string == value));

    /// <summary>Retrieves a <typeparamref name="TEnumeration" /> that matches the given <paramref name="matchPredicate" />.</summary>
    /// <param name="matchPredicate">The predicate to use to match the enumeration value.</param>
    /// <returns>The enumeration value that matches the predicate, or <see langword="null" /> if no match is found.</returns>
    public static TEnumeration? Parse<TEnumeration>(Func<TEnumeration, bool> matchPredicate) where TEnumeration : IEnumeration
        => GetValues<TEnumeration>().FirstOrDefault(matchPredicate);

    /// <summary>Retrieves an <see cref="IEnumeration" /> of type <paramref name="t" /> that matches the given <paramref name="matchPredicate" />.</summary>
    /// <param name="matchPredicate">The predicate to use to match the enumeration value.</param>
    /// <returns>The enumeration value that matches the predicate, or <see langword="null" /> if no match is found.</returns>
    public static IEnumeration? Parse(Type t, Func<IEnumeration, bool> matchPredicate)
        => GetValues(t).FirstOrDefault(matchPredicate);

    /// <summary>Attempts to parse the <paramref name="value" /> to an object of type <typeparamref name="TEnumeration"/>.</summary>
    /// <param name="s">The value to parse.</param>
    /// <param name="value">The result of the parse operation.</param>
    /// <returns><see langword="true" /> if the parse operation was successful; otherwise, <see langword="false" />.</returns>
    public static bool TryParse<TEnumeration>(string s, out TEnumeration value) where TEnumeration : class, IEnumeration
        => (value = Parse<TEnumeration>(s) as TEnumeration) != null;

    /// <summary>Determines if the current object is equivalent to the value represented by <paramref name="other" />.</summary>
    /// <param name="other">The object to compare to.</param>
    /// <returns><see langword="true" /> if the current object is equivalent to the value represented by <paramref name="other" />; otherwise, <see langword="false" />.</returns>
    public bool Equals(IEnumeration<{{ enumeration_class_name }}> other) => Equals(other as IEnumeration);

    /// <summary>Compares the current object to the value represented by <paramref name="other" />.</summary>
    /// <param name="other">The object to compare to.</param>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <remarks>
    /// <para>The return value has the following meanings:</para>
    /// <list type="table">
    /// <listheader>
    /// <term>Value</term>
    /// <description>Meaning</description>
    /// </listheader>
    /// <item>
    /// <term>Less than zero</term>
    /// <description>This object is less than the <paramref name="other" /> parameter.</description>
    /// </item>
    /// <item>
    /// <term>Zero</term>
    /// <description>This object is equal to <paramref name="other" />.</description>
    /// </item>
    /// <item>
    /// <term>Greater than zero</term>
    /// <description>This object is greater than <paramref name="other" />.</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <exception cref="ArgumentException"><paramref name="other" /> is not the same type as this instance.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="other" /> is <see langword="null" />.</exception>
    /// <exception cref="InvalidOperationException">The <see cref="Value" /> property of this instance is <see langword="null" />.</exception>
    public int CompareTo({{ value_type }} other) => Value.CompareTo(other);

    /// <summary>Determines if the current object is equivalent to the value represented by <paramref name="other" />.</summary>
    /// <param name="other">The object to compare to.</param>
    /// <returns><see langword="true" /> if the current object is equivalent to the value represented by <paramref name="other" />; otherwise, <see langword="false" />.</returns>
    public bool Equals({{ value_type }} other) => Value.Equals(other);

    /// <summary>Compares the current object to the value represented by <paramref name="other" />.</summary>
    /// <param name="other">The object to compare to.</param>
    /// <returns>A value that indicates the relative order of the objects being compared.</returns>
    /// <remarks>
    /// <para>The return value has the following meanings:</para>
    /// <list type="table">
    /// <listheader>
    /// <term>Value</term>
    /// <description>Meaning</description>
    /// </listheader>
    /// <item>
    /// <term>Less than zero</term>
    /// <description>This object is less than the <paramref name="other" /> parameter.</description>
    /// </item>
    /// <item>
    /// <term>Zero</term>
    /// <description>This object is equal to <paramref name="other" />.</description>
    /// </item>
    /// <item>
    /// <term>Greater than zero</term>
    /// <description>This object is greater than <paramref name="other" />.</description>
    /// </item>
    /// </list>
    /// </remarks>
    /// <exception cref="ArgumentException"><paramref name="other" /> is not the same type as this instance.</exception>
    /// <exception cref="ArgumentNullException"><paramref name="other" /> is <see langword="null" />.</exception>
    /// <exception cref="InvalidOperationException">The <see cref="Value" /> property of this instance is <see langword="null" />.</exception>
    public int CompareTo({{ enumeration_class_name }} other) => CompareTo(other.Value);

    /// <summary>Determines if the current object is equivalent to the value represented by <paramref name="other" />.</summary>
    /// <param name="other">The object to compare to.</param>
    /// <returns><see langword="true" /> if the current object is equivalent to the value represented by <paramref name="other" />; otherwise, <see langword="false" />.</returns>
    public bool Equals({{ enumeration_class_name }}? other) => Equals(other?.Value);
}

"""";
}
