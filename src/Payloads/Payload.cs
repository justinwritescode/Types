/*
 * Payload.cs
 *
 *   Created: 2022-11-29-05:12:56
 *   Modified: 2022-11-29-05:13:18
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads;

using System.Diagnostics;
using JustinWritesCode.Payloads.Abstractions;

[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public class Payload : Payload<object>
{
    public Payload()
        : this(default, default)
        {
        }

    public Payload(object? value, string? stringValue = default)
        : base(value, stringValue)
    {
        Value = value;
        StringValue = stringValue ?? value?.ToString();
    }
}
