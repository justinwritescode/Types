// 
// ResponsePayload.cs
// 
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:35:44
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Payloads;

public record ResponsePayload<T>(T Value, bool Success = true, string? Error = null, string? Message = null, string? StackTrace = null)
	: Payload<T>(Value, Value.ToString())
{
	//     public ResponsePayload(T Value, bool Success = true, string? Error = null, string? Message = null, string? StackTrace = null)
	//         : base(Value)
	//     {
	//         this.Success = Success;
	//         this.Error = Error;
	//         this.Message = Message;
	//         this.StackTrace = StackTrace;
	//     }

	public virtual bool Success { get; init; } = Success;
	public virtual string Error { get; init; } = Error;
	public virtual string Message { get; init; } = Message;
	public virtual string StackTrace { get; init; } = StackTrace;
}
