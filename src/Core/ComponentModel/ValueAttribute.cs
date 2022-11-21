//
// ValueAttribute.cs
//
//   Created: 2022-10-30-07:15:06
//   Modified: 2022-10-30-07:15:06
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//
namespace System.ComponentModel.DataAnnotations;

public abstract class ValueAttribute<T> : Attribute
{
    public ValueAttribute(T value) => Value = value;
    public T Value { get; }
}
