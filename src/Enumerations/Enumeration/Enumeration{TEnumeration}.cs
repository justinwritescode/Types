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
public abstract class Enumeration<TEnumeration> : Enumeration<TEnumeration, int>
     where TEnumeration : Enumeration<TEnumeration>
{
    protected Enumeration(int value, string displayName)
        : base(value, displayName, value)
    {
    }

    public static TEnumeration FromInt32(int value)
    {
        return FromValue(value);
    }

    public static bool TryFromInt32(int listItemValue, out TEnumeration result)
    {
        return TryParse(listItemValue, out result);
    }
}
