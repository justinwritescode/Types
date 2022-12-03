/*
 * IPayload{T}.cs
 *
 *   Created: 2022-11-26-04:22:55
 *   Modified: 2022-11-26-04:22:56
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace JustinWritesCode.Payloads.Abstractions;
public interface IPayload<T>
{
    T Value { get; set; }
    string StringValue { get; set; }
}
