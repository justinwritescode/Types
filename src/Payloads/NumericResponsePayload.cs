//
// NumericResponsePayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:48:08
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

using System.Diagnostics;
using System.Threading.Tasks;
using JustinWritesCode.Payloads.Abstractions;

namespace JustinWritesCode.Payloads;

[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public class NumericResponsePayload : ResponsePayload<decimal>
{
    public NumericResponsePayload(decimal value, bool isSuccess = true, string? message = default!, string stringValue = default!)
    {
        Value = value;
        IsSuccess = isSuccess;
        Message = message ?? string.Empty;
        StringValue = stringValue ?? value.ToString();
    }
    public override string StringValue { get => Value.ToString(); set => Value = decimal.Parse(value); }
}
