//
// BooleanResponsePayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:33:50
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//


namespace JustinWritesCode.Payloads;
using JustinWritesCode.Payloads.Abstractions;

public struct BooleanResponsePayload : IResponsePayload<bool>
{
    public BooleanResponsePayload(bool value, bool isSuccess = true, string? message = default!)
    {
        Value = value;
        IsSuccess = isSuccess;
        Message = message ?? string.Empty;
    }

    public bool Value { get; set; }
    public string StringValue { get => Value.ToString(); set => Value = bool.Parse(value); }
    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
