// 
// IEnumeration.cs
// 
//   Created: 2022-10-16-12:16:22
//   Modified: 2022-10-31-01:44:39
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

using System;
namespace JustinWritesCode.Enumerations.Abstractions;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
using JustinWritesCode.Abstractions;

public interface IEnumeration<TId, TValue> : IEnumeration<TId>, IHaveAnId<TId>, IEnumeration, IComparable<IEnumeration>
    where TValue : IComparable<TValue>, IEquatable<TValue>
    where TId : IComparable, IComparable<TId>, IEquatable<TId>
{
    //TValue Value { get; }
    //DisplayAttribute? DisplayAttribute { get; }
}
