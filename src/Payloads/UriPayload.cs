//
// UriPayload.cs
//
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:42:17
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace JustinWritesCode.Payloads;
using System;
using JustinWritesCode.Payloads.Abstractions;

public class UriPayload : Payload<Uri>
{
    public UriPayload() : this(new Uri("about:blank")) { }
    public UriPayload(Uri value) : base(value) { }
}
