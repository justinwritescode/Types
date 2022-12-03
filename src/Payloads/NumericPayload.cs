//
// NumericPayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:42:45
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace JustinWritesCode.Payloads;

using System.Diagnostics;
using JustinWritesCode.Payloads.Abstractions;

[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public struct NumericPayload : IPayload<decimal>
{
    public NumericPayload() : this(default) { }

    public NumericPayload(decimal value, string? stringValue = default)
    {
        Value = value;
        StringValue = stringValue ?? value.ToString();
    }

    [JProp("value")]
    public decimal Value { get; set; }
    [JProp("stringValue")]
    public string StringValue { get; set; }
}
