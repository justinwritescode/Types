// 
// NumericResponsePayload.cs
// 
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:48:08
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Payloads;

public record NumericResponsePayload(decimal Value, bool Success = true, string? Error = default, string? Message = null, string? StackTrace = null)
	: ResponsePayload<decimal>(Value, Success, Error, Message, StackTrace);
// {
//     public NumericResponsePayload(decimal Value, bool Success = true, string? Error = null, string? Message = null, string? StackTrace = null)
//         : base(Value, Success, Error, Message, StackTrace)
//     { }
// }
