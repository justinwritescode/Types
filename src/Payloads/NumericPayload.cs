// 
// NumericPayload.cs
// 
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:42:45
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Payloads;

public record NumericPayload(decimal Value) : Payload<decimal>(Value, Value.ToString());
// {
// public NumericPayload(decimal Value) : base(Value) { }
// }
