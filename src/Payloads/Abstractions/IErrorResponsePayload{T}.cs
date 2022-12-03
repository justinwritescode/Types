/*
 * IErrorResponsePayload{T}.cs
 *
 *   Created: 2022-11-26-04:29:47
 *   Modified: 2022-11-26-04:57:03
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads.Abstractions;

public interface IErrorResponsePayload<T> : IResponsePayload<T>
{
    [JProp("stackTrace")]
    string StackTrace { get; set; }
}
