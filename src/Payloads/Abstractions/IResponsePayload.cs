/*
 * IResponsePayload.cs
 *
 *   Created: 2022-11-26-04:26:06
 *   Modified: 2022-11-26-04:26:06
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads.Abstractions;

public interface IResponsePayload : IResponsePayload<object>, IPayload
{
}
