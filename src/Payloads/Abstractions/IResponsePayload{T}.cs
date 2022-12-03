/*
 * IResponsePayload copy.cs
 *
 *   Created: 2022-11-26-04:29:28
 *   Modified: 2022-11-26-04:29:28
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads.Abstractions;

public interface IResponsePayload<T> : IPayload<T>
{
    [JProp("success")]
    bool IsSuccess { get; set; }
    [JProp("message")]
    string Message { get; set; }
}
