// 
// StringResponsePayload.cs
// 
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:46:26
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Payloads;

public record StringResponsePayload(string Value, bool Success = true, string? Error = default, string? Message = null, string? StackTrace = null) 
    : ResponsePayload<string>(Value, Success, Error, Message, StackTrace);
// {
    // public StringResponsePayload(string Value, bool Success = true, string? Error = default, string? Message = null, string? StackTrace = null)
    // : base(Value, Success, Error, Message, StackTrace)
    // { }
// }
