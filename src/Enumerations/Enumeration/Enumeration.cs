namespace JustinWritesCode.Enumerations;

public abstract class Enumeration : Enumeration<Enumeration>
{
    protected Enumeration(int value, string displayName)
        : base(value, displayName)
    {
    }



    #region arbitrary properties
    public virtual TAttribute GetCustomAttribute<TAttribute>() where TAttribute : Attribute
    {
        return FieldInfo.GetCustomAttribute<TAttribute>();
    }
    #endregion

    // public override string ToString() => GetType().GetProperty(ToStringProperty).GetValue(this).ToString();

    public static IEnumerable<T> GetAll<T>() where T : Enumeration
    {
        var fields = typeof(T).GetFields(BindingFlags.Public |
                                         BindingFlags.Static |
                                         BindingFlags.DeclaredOnly);

        return fields.Select(f => f.GetValue(null)).Cast<T>();
    }

    public override bool Equals(object obj)
    {
        var otherValue = obj as Enumeration;

        if (otherValue == null)
            return false;

        var typeMatches = GetType() == obj.GetType();
        var valueMatches = Id.Equals(otherValue.Id);

        return typeMatches && valueMatches;
    }

    public override int GetHashCode() => Id.GetHashCode();

    public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
    {
        return Math.Abs(firstValue.Id - secondValue.Id);
    }

    public static T FromValue<T>(int value) where T : Enumeration
    {
        return Parse<T, int>(value, "value", item => item.Id == value);
    }

    public static T FromDisplayName<T>(string displayName) where T : Enumeration
    {
        return Parse<T, string>(displayName, "display name", item => item.Name == displayName);
    }

    private static T Parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);

        if (matchingItem == null)
            throw new InvalidOperationException($"'{value}' is not a valid {description} in {typeof(T)}");

        return matchingItem;
    }

    private static bool TryParse<T, K>(K value, string description, Func<T, bool> predicate, out T result) where T : Enumeration
    {
        var matchingItem = GetAll<T>().FirstOrDefault(predicate);

        result = matchingItem;

        return matchingItem != null;
    }

    // public IComparable ComparisonPropertyValue => GetType().GetProperty(ComparisonProperty).GetValue(this) as IComparable;

    // public int CompareTo(object other) =>
    //     ComparisonPropertyValue.CompareTo(((Enumeration)other).ComparisonPropertyValue);

    public static implicit operator int(Enumeration enumeration) => enumeration.Id;
    public static implicit operator Enumeration(int id) => FromValue<Enumeration>(id);
}

// public class Enumeration<TSelf> : Enumeration where TSelf : Enumeration<TSelf>
// {

//     protected Enumeration(int id, string name, string toStringProperty = DefaultToStringProperty, string comparisonProperty = DefaultComparisonProperty)
//         : base(id, name, toStringProperty, comparisonProperty)
//     {
//     }

//     public static IEnumerable<TSelf> GetAll() => Enumeration.GetAll<TSelf>();
//     public static implicit operator Enumeration<TSelf>(int id) => FromValue<TSelf>(id);
// }

// // public class Enumeration<TValue> : Enumeration, IEnumeration<TValue> where TValue : Enum
// // {
// //     public TValue Value { get; }

// //     protected Enumeration(int id, string name, TValue value, string toStringProperty = DefaultToStringProperty, string comparisonProperty = DefaultComparisonProperty)
// //         : base(id, name, toStringProperty, comparisonProperty)
// //     {
// //         Value = value;
// //     }

// //     public static implicit operator TValue(Enumeration<TValue> enumeration) => enumeration.Value;
// //     public static implicit operator Enumeration<TValue>(TValue value) => FromValue<Enumeration<TValue>>(value);
// // }

// public class Enumeration<TValue, TSelf> : Enumeration<TSelf> where TSelf : Enumeration<TValue, TSelf> where TValue : Enum
// {
//     public TValue Value { get; }

//     protected Enumeration(int id, string name, TValue value, string toStringProperty = DefaultToStringProperty, string comparisonProperty = DefaultComparisonProperty)
//         : base(id, name, toStringProperty, comparisonProperty)
//     {
//         Value = value;
//     }

//     public static implicit operator TValue(Enumeration<TValue, TSelf> enumeration) => enumeration.Value;
//     public static implicit operator Enumeration<TValue, TSelf>(TValue value) => FromValue<TSelf>((int)(object)value);
// }
