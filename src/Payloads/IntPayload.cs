//
// IntPayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:40:31
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

using JustinWritesCode.Payloads.Abstractions;

namespace JustinWritesCode.Payloads;

public class IntPayload : Payload<int>
{
    public IntPayload() : this(0) { }
    public IntPayload(int value = 0) => Value = value;

    public override string StringValue { get => Value.ToString(); set => Value = int.Parse(value); }
}
