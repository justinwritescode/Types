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

using JustinWritesCode.Payloads.Abstractions;

namespace JustinWritesCode.Payloads;

public struct StringResponsePayload : IResponsePayload<string>
{
    public StringResponsePayload(string value, bool isSuccess = true, string? message = default!, string stringValue = default!)
    {
        Value = value;
        IsSuccess = isSuccess;
        Message = message ?? string.Empty;
        StringValue = stringValue ?? value;
    }

    public string Value { get; set; }
    public string StringValue { get; set; }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
