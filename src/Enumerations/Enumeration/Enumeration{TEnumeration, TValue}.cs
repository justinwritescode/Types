namespace JustinWritesCode.Enumerations;
using System.Diagnostics;
using System;

/// <summary>
///  An abstract base class for enumerations.
/// </summary>
/// <typeparam name="TEnumeration">The enumeration class</typeparam>
/// <remarks>This class was partially adapted from the contents of the now-defunct NuGetPackage "Enumeration" https://www.nuget.org/packages/Enumeration</remarks>
[Serializable]
[DebuggerDisplay("{DisplayName} - {Value}")]
public abstract class Enumeration<TEnumeration, TValue> : IComparable<TEnumeration>, IEquatable<TEnumeration>
    where TEnumeration : Enumeration<TEnumeration, TValue>
    where TValue : IComparable
{
    public int Id { get; init; }
    public string Name { get; init; }
    public TValue Value { get; init; }
    public const string NoGroup = "None";
    protected Func<Enumeration<TEnumeration, TValue>, string> ToStringDelegate { get; init; } = e => e.DisplayName;

    private static Lazy<TEnumeration[]> _enumerations = new Lazy<TEnumeration[]>(GetEnumerations);

    protected Enumeration(int id, string displayName, TValue value, Func<Enumeration<TEnumeration, TValue>, string> toStringDelegate = null)
    {
        Id = id;
        Value = value;
        Name = displayName;
        if (toStringDelegate != null)
        {
            ToStringDelegate = toStringDelegate;
        }
    }

    #region DisplayAttribute
    public virtual string DisplayName => DisplayAttribute?.Name ?? Name;
    public virtual string ShortName => DisplayAttribute?.ShortName ?? Name;
    public virtual string Description => DisplayAttribute?.Description ?? Name;
    public virtual string GroupName => DisplayAttribute?.GroupName ?? NoGroup;
    public virtual int Order => DisplayAttribute?.Order ?? Id;
    public virtual DisplayAttribute DisplayAttribute => FieldInfo.GetCustomAttribute<DisplayAttribute>();
    public virtual FieldInfo FieldInfo => GetType().GetField(Name);
    #endregion

    public int CompareTo(TEnumeration other)
    {
        return Value.CompareTo(other.Value);
    }

    public override string ToString() => ToStringDelegate(this);

    public static TEnumeration[] GetAll()
    {
        return _enumerations.Value;
    }

    private static TEnumeration[] GetEnumerations()
    {
        Type enumerationType = typeof(TEnumeration);
        return enumerationType
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
            .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
            .Select(info => info.GetValue(null))
            .Cast<TEnumeration>()
            .ToArray();
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as TEnumeration);
    }

    public bool Equals(TEnumeration other)
    {
        return other != null && Value.Equals(other.Value);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static bool operator ==(Enumeration<TEnumeration, TValue> left, Enumeration<TEnumeration, TValue> right)
    {
        return Equals(left, right);
    }

    public static bool operator !=(Enumeration<TEnumeration, TValue> left, Enumeration<TEnumeration, TValue> right)
    {
        return !Equals(left, right);
    }

    public static TEnumeration FromValue(TValue value)
    {
        return Parse(value, "value", item => item.Value.Equals(value));
    }

    public static TEnumeration Parse(string name)
    {
        return Parse(name, "enumeration name", item => item.Name == name);
    }

    static bool TryParse(Func<TEnumeration, bool> predicate, out TEnumeration result)
    {
        result = GetAll().FirstOrDefault(predicate);
        return result != null;
    }

    private static TEnumeration Parse(object value, string description, Func<TEnumeration, bool> predicate)
    {
        TEnumeration result;

        if (!TryParse(predicate, out result))
        {
            string message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(TEnumeration));
            throw new ArgumentException(message, "value");
        }

        return result;
    }

    public static bool TryParse(TValue value, out TEnumeration result)
    {
        return TryParse(e => e.Value.Equals(value), out result);
    }

    public static bool TryParse(string displayName, out TEnumeration result)
    {
        return TryParse(e => e.DisplayName == displayName, out result);
    }
}
