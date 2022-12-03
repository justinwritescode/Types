/*
 * ResponsePayload{T}.cs
 *
 *   Created: 2022-11-29-05:25:22
 *   Modified: 2022-11-29-05:25:35
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads;
using JustinWritesCode.Payloads.Abstractions;

public class ResponsePayload : ResponsePayload<object>, IResponsePayload
{
    public ResponsePayload()
        : this(default, true, default)
        {
        }

    public ResponsePayload(object? value, bool isSuccess = true, string? message = default)
    {
        Value = value;
        IsSuccess = isSuccess;
        Message = message ?? string.Empty;
        StringValue = value.ToString();
    }
}
