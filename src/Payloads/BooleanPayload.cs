// 
// BooleanPayload.cs
// 
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:33:46
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Payloads;

public record BooleanPayload(bool Value) : Payload<bool>(Value, Value.ToString());
// {
    // public BooleanPayload(bool Value) : base(Value) { }
// }
