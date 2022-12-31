namespace System;
public interface IStringWithRegexValueObject<TSelf> : IComparable<TSelf>, IComparable, IEquatable<TSelf>
#if NET7_0_OR_GREATER
    , IParsable<TSelf>
#endif
    where TSelf : IStringWithRegexValueObject<TSelf>
{
    string Value { get; }

    bool IsEmpty { get; }

#if NET6_0_OR_GREATER
    static abstract string RegexString { get; }
    static abstract string Description { get; }
    static abstract TSelf Parse(string value);
    static abstract TSelf From(string value);
    static abstract REx Regex();
    static abstract TSelf ExampleValue { get; }
    static abstract TSelf Empty { get; }
#else
    string RegexString { get; }
    string Description { get; }
    TSelf ExampleValue { get; }
    REx Regex();
#endif
}
