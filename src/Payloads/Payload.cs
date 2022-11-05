// 
// Payload.cs
// 
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:35:51
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Payloads;

public record Payload<T>(T Value, string StringValue)
{
//     public Payload() : this(default(T)) { }
//     public Payload(T Value)
//     {
//         this.Value = Value;
//     }

//     public virtual T Value { get; }
//     public virtual string StringValue => Value?.ToString() ?? string.Empty;
}
