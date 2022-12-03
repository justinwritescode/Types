/*
 * ArrayResponsePayload{T}.cs
 *
 *   Created: 2022-11-20-07:14:18
 *   Modified: 2022-11-28-09:44:22
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace JustinWritesCode.Payloads;
using JustinWritesCode.Payloads.Abstractions;

public class ArrayResponsePayload<T> : ArrayPayload<T>, IArrayResponsePayload<T>
{
    public ArrayResponsePayload()
        : this(Array.Empty<T>())
    {
    }
    public ArrayResponsePayload(IEnumerable<T> value, bool isSuccess = true, string? message = default, string? stringValue = default) : base(value, stringValue)
    {
        IsSuccess = isSuccess;
        Message = message ?? string.Empty;
    }


    public bool IsSuccess { get; set; }
    public string Message { get; set; }
}
