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
using System.Diagnostics;
using System;

/// <summary>
///  An abstract base class for enumerations.
/// </summary>
/// <typeparam name="TEnumeration">The enumeration class</typeparam>
/// <typeparam name="TValue">The type of the enumeration's value</typeparam>
/// <typeparam name="TId">The type of the enumeration's id</typeparam>
/// <remarks>This class was partially adapted from the contents of the now-defunct NuGetPackage "Enumeration" https://www.nuget.org/packages/Enumeration</remarks>
[Serializable]
[DebuggerDisplay("{DisplayName} - {Value}")]
public abstract class Enumeration<TEnumeration, TId, TValue> : Enumeration<TEnumeration, TId>
    where TEnumeration : Enumeration<TEnumeration, TId, TValue>
    where TValue : Enum, IComparable
    where TId : IComparable, IComparable<TId>, IEquatable<TId>
{
    protected Enumeration(TId id, TValue value, string name) : base(id, name)
    {
        Value = value;
    }

    public virtual new TValue Value {get; init;}
}
