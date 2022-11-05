// 
// StringPayload.cs
// 
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:41:44
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Payloads;

public record StringPayload(string Value) : Payload<string>(Value, Value);
// {
    // public StringPayload(string Value, bool Success = true, string? Error = null, string? Message = null, string? StackTrace = null)
    //     : base(Value)
    // { }

    // public StringPayload() : base(string.Empty)
    // { }
// }

public record StringWithRegexPayload(string Value, string Regex) 
    : StringPayload(Value);
// {
    // public string Regex { get; set; }
    // public StringWithRegexPayload(string Value, string Regex) : base(Value)
    // {
    //     this.Regex = Regex;
    // }
// }
