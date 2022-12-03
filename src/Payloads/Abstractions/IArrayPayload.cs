/*
 * IPayload copy.cs
 *
 *   Created: 2022-11-26-04:39:55
 *   Modified: 2022-11-26-04:39:55
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads.Abstractions;

public interface IArrayPayload : IArrayPayload<object>, IPayload<object[]>
{
}
