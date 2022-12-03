//
// IntResponsePayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:47:14
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

using System.Collections.Concurrent;
using JustinWritesCode.Payloads.Abstractions;

namespace JustinWritesCode.Payloads;

public class IntResponsePayload : ResponsePayload<int>
{
    public IntResponsePayload(int value, bool isSuccess = true, string? message = default!)
    {
        Value = value;
        IsSuccess = isSuccess;
        Message = message ?? string.Empty;
    }
    public override string StringValue
    {
        get => Value.ToString();
        set => Value = int.Parse(value);
    }
}
