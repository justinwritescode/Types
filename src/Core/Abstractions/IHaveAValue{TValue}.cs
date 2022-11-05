// 
// IHaveAValue{TValue}.cs
// 
//   Created: 2022-11-04-09:30:52
//   Modified: 2022-11-04-09:31:31
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

using System.Net.Http.Headers;
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

public interface IHaveAValue<TValue>
{
    TValue Value { get; }
}

public interface IHaveAWritableValue<TValue> : IHaveAValue
{
    new TValue Value { get; set; }
}
