/*
 * IErrorResponsePayload.cs
 *
 *   Created: 2022-11-26-04:29:18
 *   Modified: 2022-11-26-04:57:12
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads.Abstractions;

public interface IErrorResponsePayload : IResponsePayload<object?>
{
    [JProp("stackTrace")]
    string? StackTrace { get; set; }
}
