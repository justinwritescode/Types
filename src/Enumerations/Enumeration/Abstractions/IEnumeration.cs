//
// IEnumeration.cs
//
//   Created: 2022-11-02-01:22:22
//   Modified: 2022-11-02-01:22:22
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//
namespace JustinWritesCode.Enumerations.Abstractions;
using JustinWritesCode.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
public interface IEnumeration : IConvertible, IComparable, IHaveAValue, IHaveAName, IHaveADescription, IIdentifiable
{
    FieldInfo FieldInfo {get;}//=> GetType().GetField(Name);
    [FromString]
    string DisplayName {get;}//=> Name;
    [FromString]
    string ShortName{get;}// => Name;
    string GroupName {get;}// => NoGroup;
    int Order{get;}// => DefaultOrder;
    TAttribute? GetCustomAttribute<TAttribute>() where TAttribute : Attribute;
}
