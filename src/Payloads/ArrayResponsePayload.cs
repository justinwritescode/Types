// 
// ArrayResponsePayload.cs
// 
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:33:41
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

using System;
using System.Collections.Generic;
using System.Linq;

namespace JustinWritesCode.Payloads;

public record ArrayResponsePayload<T>(IEnumerable<T> Values, bool Success = true, string? Error = null, string? Message = null, string? StackTrace = null) : 
    ResponsePayload<List<T>>(Values.ToList(), Success, Error, Message, StackTrace);
// {
    // public ArrayResponsePayload() : this(Array.Empty<T>()) { }
    // public ArrayResponsePayload(IEnumerable<T> array) : base(array.ToList()) { }
    // public ArrayResponsePayload(IEnumerable<T> array, bool Success = true, string? Error = null, string? Message = null, string? StackTrace = null)
    //     : base(array.ToList(), Success, Error, Message, StackTrace) { }
// }
