// 
// IHaveAValue.cs
// 
//   Created: 2022-11-04-09:30:31
//   Modified: 2022-11-04-09:30:31
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 
namespace JustinWritesCode.Abstractions;

public interface IHaveAValue
{
    object Value { get; }
}

public interface IHaveAWritableValue : IHaveAValue
{
    new object Value { get; set; }
}
