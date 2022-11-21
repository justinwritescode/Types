// 
// IntPayload.cs
// 
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:40:31
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Payloads;

public record IntPayload(int Value) : Payload<int>(Value, Value.ToString());
// {
// public IntPayload(int Value) : base(Value) { }
// }
