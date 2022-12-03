//
// BooleanPayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:33:46
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

using JustinWritesCode.Payloads.Abstractions;

namespace JustinWritesCode.Payloads;

public struct BooleanPayload : IPayload<bool>
{
    public BooleanPayload() : this(true) { }
    public BooleanPayload(bool value = true) => Value = value;

    public bool Value { get; set; }
    public string StringValue { get => Value.ToString(); set => Value = bool.Parse(value); }
}
