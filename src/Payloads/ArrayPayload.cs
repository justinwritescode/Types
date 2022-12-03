/*
 * ArrayPayload.cs
 *
 *   Created: 2022-11-20-07:14:18
 *   Modified: 2022-11-26-04:44:57
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Collections;
using System.Diagnostics;
using JustinWritesCode.Payloads.Abstractions;

namespace JustinWritesCode.Payloads;

[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public class ArrayPayload : ArrayPayload<object>
{
    public ArrayPayload()
        : this(Array.Empty<object>())
    {
    }

    public ArrayPayload(IEnumerable values, string? stringValue = default)
    : base(values.OfType<object>().ToArray(), stringValue)
    {
    }
}
