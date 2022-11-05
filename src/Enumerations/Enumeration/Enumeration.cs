// 
// Enumeration.cs
// 
//   Created: 2022-10-16-03:16:17
//   Modified: 2022-11-02-01:58:19
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Enumerations;
using JustinWritesCode.Abstractions;
using JustinWritesCode.Enumerations.Abstractions;
using System.ComponentModel.DataAnnotations;
using Convert = System.Convert;
using static System.Convert;

[Serializable]
[DebuggerDisplay("{DisplayName} - {Value}")]
public abstract class Enumeration : IEnumeration
{
    public const int DefaultOrder = 0;
    public const string NoGroup = "No Group";

    protected Enumeration(object id, string name) 
    {
        this.Id = id;
        Name = name;
    }

    object IHaveAnId.Id => Id;
    public virtual object Value => Id;
    public virtual FieldInfo FieldInfo => GetType().GetField(Name);
    protected Func<IEnumeration, string> ToStringDelegate { get; init; } = e => e.DisplayName;
    public virtual object Id {get;}
    [FromString]
    public virtual string Name { get; init; }
    public virtual TAttribute? GetCustomAttribute<TAttribute>() where TAttribute : Attribute 
        => ((IEnumeration)this).GetCustomAttribute<DisplayAttribute>() as TAttribute;
    public virtual DisplayAttribute? DisplayAttribute => GetCustomAttribute<DisplayAttribute>();
    [FromString]
    public virtual string ShortName => DisplayAttribute?.ShortName ?? Name;
    public virtual string Description => DisplayAttribute?.Description ?? Name;
    [FromString]
    public string DisplayName => DisplayAttribute?.Name ?? Name;

    public string GroupName => DisplayAttribute?.GroupName ?? Enumeration.NoGroup;

    public int Order => DisplayAttribute?.Order ?? Enumeration.DefaultOrder;

    public override string ToString() => ToStringDelegate(this);
    public virtual int CompareTo(object other) => other is IEnumeration ? CompareTo((IEnumeration)other) : -1;
    public virtual int CompareTo(IEnumeration other) => (Id as IComparable)?.CompareTo(other.Id) ?? -1;
    public override bool Equals(object other) => other is IEnumeration && CompareTo(other) == 0;
    public virtual bool Equals(IEnumeration other) => GetHashCode() == other.GetHashCode();
    public override int GetHashCode() => Id.GetHashCode();

    public virtual int ToInt32() => Convert.ToInt32(Value);
    public TypeCode GetTypeCode() => Convert.GetTypeCode(Value);

    public bool ToBoolean(IFormatProvider provider) => Convert.ToBoolean(Value, provider);

    public byte ToByte(IFormatProvider provider) => Convert.ToByte(Value, provider);

    #region type conversions
    public object ToType(Type conversionType, IFormatProvider provider) => Convert.ChangeType(Value, conversionType);
    public char ToChar(IFormatProvider provider) => Convert.ToChar(Value, provider);
    public DateTime ToDateTime(IFormatProvider provider) => Convert.ToDateTime(Value, provider);
    public decimal ToDecimal(IFormatProvider provider) => Convert.ToDecimal(Value, provider);
    public double ToDouble(IFormatProvider provider) => Convert.ToDouble(Value, provider);
    public short ToInt16(IFormatProvider provider) => Convert.ToInt16(Value, provider);
    public int ToInt32(IFormatProvider provider) => Convert.ToInt32(Value, provider);
    public long ToInt64(IFormatProvider provider) => Convert.ToInt64(Value, provider);
    public sbyte ToSByte(IFormatProvider provider) => Convert.ToSByte(Value, provider);
    public float ToSingle(IFormatProvider provider) => Convert.ToSingle(Value, provider);
    public string ToString(IFormatProvider provider) => ToString();   
    public ushort ToUInt16(IFormatProvider provider) => Convert.ToUInt16(Value, provider);    
    public uint ToUInt32(IFormatProvider provider) => Convert.ToUInt32(Value, provider);    
    public ulong ToUInt64(IFormatProvider provider) => Convert.ToUInt64(Value, provider);
    #endregion

    public static bool operator==(Enumeration e, object o) => e.Equals(o);
    public static bool operator!=(Enumeration e, object o) => !e.Equals(o);

    public static IEnumeration FromValue(Type t, object value) => Parse(t, x => x.Value.Equals(value));
    public static TEnumeration? FromValue<TEnumeration>(object value) where TEnumeration : class, IEnumeration => FromValue(typeof(TEnumeration), value) as TEnumeration;
    public static IEnumeration[] GetValues(Type t) => t.GetRuntimeFields().Select(f => f.GetValue(null)).OfType<IEnumeration>().ToArray();
    public static TEnumeration[] GetValues<TEnumeration>() => GetValues(typeof(TEnumeration)).OfType<TEnumeration>().ToArray();
    protected static IEnumerable<PropertyInfo> GetFromStringProperties(Type t)
        => t.GetRuntimeProperties().Where(p => p.GetCustomAttribute<FromStringAttribute>() != null);
    protected static IEnumerable<PropertyInfo> GetFromStringProperties<TEnumeration>()
        => GetFromStringProperties(typeof(TEnumeration));
    public static IEnumeration Parse(Type t, string value) => Parse(t, e => GetFromStringProperties(t).Any(p => p.GetValue(null) as string == value));
    public static TEnumeration Parse<TEnumeration>(string value) where TEnumeration : IEnumeration
        => Parse<TEnumeration>(e => GetFromStringProperties<TEnumeration>().Any(p => p.GetValue(null) as string == value));
    public static TEnumeration Parse<TEnumeration>(Func<TEnumeration, bool> matchPredicate) where TEnumeration : IEnumeration
        => GetValues<TEnumeration>().FirstOrDefault(matchPredicate);
    public static IEnumeration Parse(Type t, Func<IEnumeration, bool> matchPredicate)
        => GetValues(t).FirstOrDefault(matchPredicate);
    public static bool TryParse<TEnumeration>(string s, out TEnumeration value) where TEnumeration : class, IEnumeration
        => (value = Parse<TEnumeration>(s) as TEnumeration) != null;
}
