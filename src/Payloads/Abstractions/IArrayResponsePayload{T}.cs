/*
 * IArrayResponsePayload{T}.cs
 *
 *   Created: 2022-11-26-04:51:36
 *   Modified: 2022-11-26-04:52:00
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads.Abstractions;

public interface IArrayResponsePayload<T> : IResponsePayload<T[]>
{
    T[] Values { get; set; }
    int Count { get; }
}
