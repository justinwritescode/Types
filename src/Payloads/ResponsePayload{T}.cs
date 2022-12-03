/*
 * ResponsePayload.cs
 *
 *   Created: 2022-11-20-07:14:18
 *   Modified: 2022-11-29-05:25:05
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads;
using JustinWritesCode.Payloads.Abstractions;

public class ResponsePayload<T> : Payload<T>, IResponsePayload<T>
{
    public ResponsePayload() : this(default, true, default) { }

    public ResponsePayload(T value, bool isSuccess = true, string? message = default)
    {
        Value = value;
        IsSuccess = isSuccess;
        Message = message ?? string.Empty;
        StringValue = value.ToString();
    }

    [JProp("isSuccess")]
    public virtual bool IsSuccess { get; set; }
    [JProp("message")]
    public virtual string Message { get; set; }
}
