/*
 * ArrayResponsePayload.cs
 *
 *   Created: 2022-11-28-09:44:00
 *   Modified: 2022-11-28-09:44:15
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System;
using System.Collections;
using System.Linq;

namespace JustinWritesCode.Payloads;

using System.Diagnostics;
using JustinWritesCode.Payloads.Abstractions;

[DebuggerDisplay($"{{{nameof(StringValue)}}}; Count = {{{nameof(Count)}}}")]
public class ArrayResponsePayload : ArrayResponsePayload<object>, IArrayResponsePayload
{
    public ArrayResponsePayload() : this(Array.Empty<object>()) { }
    public ArrayResponsePayload(IEnumerable value, bool isSuccess = true, string? message = default, string? stringValue = default) : base(value.OfType<object>().ToArray(), isSuccess, message, stringValue)
    {
        IsSuccess = isSuccess;
        Message = message ?? string.Empty;
    }
}
