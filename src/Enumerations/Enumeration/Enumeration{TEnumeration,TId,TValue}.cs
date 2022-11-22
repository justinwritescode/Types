//
// Enumeration{TEnumeration, TId, TValue}.cs
//
//   Created: 2022-10-19-01:55:33
//   Modified: 2022-11-03-12:28:37
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace JustinWritesCode.Enumerations;
using JustinWritesCode.Abstractions;
using System.Diagnostics;
using System;

/// <summary>
///  An abstract base class for enumerations.
/// </summary>
/// <typeparam name="TValue">The type of the enumeration's value</typeparam>
/// <typeparam name="TId">The type of the enumeration's id</typeparam>
/// <typeparam name="TSelf">The type of the enumeration (must be the name of the declared class)</typeparam>
/// <remarks>This class was partially adapted from the contents of the now-defunct NuGetPackage "Enumeration" https://www.nuget.org/packages/Enumeration</remarks>
[Serializable]
[DebuggerDisplay("{DisplayName} - {Value}")]
public abstract class Enumeration<TSelf, TId, TValue> : SmartEnum<TSelf, TId>, IEnumeration, IEnumeration<TId>, IEquatable<Enumeration<TId>>
    where TSelf : Enumeration<TSelf, TId, TValue>
    where TValue : Enum, IComparable//, IEquatable<TValue>
    where TId : IComparable, IComparable<TId>, IEquatable<TId>
{
    protected Enumeration(TId id, TValue value, string name) : base(name, id)
    {
        Id = id;
    }

    public TId Id { get; init; }
	object IIdentifiable.Id => Id;
	object IHaveAValue.Value => Value;
    public virtual FieldInfo FieldInfo => GetType().GetField(Name);
    protected Func<IEnumeration, string> ToStringDelegate { get; init; } = e => e.DisplayName;
    public virtual TAttribute? GetCustomAttribute<TAttribute>() where TAttribute : Attribute
        => ((IEnumeration)this).GetCustomAttribute<DisplayAttribute>() as TAttribute;
    public virtual DisplayAttribute? DisplayAttribute => GetCustomAttribute<DisplayAttribute>();
    // public override string Name
    [FromString]
    public virtual string ShortName => DisplayAttribute?.ShortName ?? Name;
    public virtual string Description => DisplayAttribute?.Description ?? Name;
    [FromString]
    public string DisplayName => DisplayAttribute?.Name ?? Name;

    public string GroupName => DisplayAttribute?.GroupName ?? Enumeration.NoGroup;

    public int Order => DisplayAttribute?.Order ?? Enumeration.DefaultOrder;

    public override string ToString() => ToStringDelegate(this);
    public virtual int CompareTo(object other) => other is IEnumeration ? CompareTo((IEnumeration)other) : -1;
    public virtual int CompareTo(IEnumeration other) => Id.CompareTo(other.Id);
    public override bool Equals(object other) => other is IEnumeration && CompareTo(other) == 0;
    public virtual bool Equals(IEnumeration other) => GetHashCode() == other.GetHashCode();
    public override int GetHashCode() => Id.GetHashCode();

    public TypeCode GetTypeCode() => Convert.GetTypeCode(Value);

    #region type conversions
    public object ToType(Type conversionType, IFormatProvider provider) => Convert.ChangeType(Value, conversionType);
    public bool ToBoolean(IFormatProvider? provider = null) => Convert.ToBoolean(Value, provider);
    public byte ToByte(IFormatProvider? provider = null) => Convert.ToByte(Value, provider);
    public char ToChar(IFormatProvider? provider = null) => Convert.ToChar(Value, provider);
    public DateTime ToDateTime(IFormatProvider? provider = null) => Convert.ToDateTime(Value, provider);
    public decimal ToDecimal(IFormatProvider? provider = null) => Convert.ToDecimal(Value, provider);
    public double ToDouble(IFormatProvider? provider = null) => Convert.ToDouble(Value, provider);
    public short ToInt16(IFormatProvider? provider = null) => Convert.ToInt16(Value, provider);
    public int ToInt32(IFormatProvider? provider = null) => Convert.ToInt32(Value, provider);
    public long ToInt64(IFormatProvider? provider = null) => Convert.ToInt64(Value, provider);
    public sbyte ToSByte(IFormatProvider? provider = null) => Convert.ToSByte(Value, provider);
    public float ToSingle(IFormatProvider? provider = null) => Convert.ToSingle(Value, provider);
    public string ToString(IFormatProvider? provider = null) => ToString();
    public ushort ToUInt16(IFormatProvider? provider = null) => Convert.ToUInt16(Value, provider);
    public uint ToUInt32(IFormatProvider? provider = null) => Convert.ToUInt32(Value, provider);
    public ulong ToUInt64(IFormatProvider? provider = null) => Convert.ToUInt64(Value, provider);
    #endregion

    // public static bool operator==(Enumeration e, object o) => e.Equals(o);
    // public static bool operator!=(Enumeration e, object o) => !e.Equals(o);

    public static IEnumeration? FromValue(Type t, object value) => Parse(t, x => x.Value.Equals(value));
    public static TEnumeration? FromValue<TEnumeration>(object value) where TEnumeration : class, IEnumeration => FromValue(typeof(TEnumeration), value) as TEnumeration;
    public static IEnumeration[] GetValues(Type t) => t.GetRuntimeFields().Select(f => f.GetValue(null)).OfType<IEnumeration>().ToArray();
    public static TEnumeration[] GetValues<TEnumeration>() => GetValues(typeof(TEnumeration)).OfType<TEnumeration>().ToArray();
    protected static IEnumerable<PropertyInfo> GetFromStringProperties(Type t)
        => t.GetRuntimeProperties().Where(p => p.GetCustomAttribute<FromStringAttribute>() != null);
    protected static IEnumerable<PropertyInfo> GetFromStringProperties<TEnumeration>()
        => GetFromStringProperties(typeof(TEnumeration));
    public static IEnumeration? Parse(Type t, string value) => Parse(t, e => GetFromStringProperties(t).Any(p => p.GetValue(null) as string == value));
    public static TEnumeration? Parse<TEnumeration>(string value) where TEnumeration : IEnumeration
        => Parse<TEnumeration>(e => GetFromStringProperties<TEnumeration>().Any(p => p.GetValue(null) as string == value));
    public static TEnumeration? Parse<TEnumeration>(Func<TEnumeration, bool> matchPredicate) where TEnumeration : IEnumeration
        => GetValues<TEnumeration>().FirstOrDefault(matchPredicate);
    public static IEnumeration? Parse(Type t, Func<IEnumeration, bool> matchPredicate)
        => GetValues(t).FirstOrDefault(matchPredicate);
    public static bool TryParse<TEnumeration>(string s, out TEnumeration value) where TEnumeration : class, IEnumeration
        => (value = Parse<TEnumeration>(s) as TEnumeration) != null;

    public bool Equals(Enumeration<TId> other) => Equals(other as IEnumeration);
}
