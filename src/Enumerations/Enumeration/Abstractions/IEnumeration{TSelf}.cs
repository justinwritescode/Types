/*
 * IEnumeration{TSelf}.cs
 *
 *   Created: 2022-12-23-12:08:46
 *   Modified: 2022-12-23-12:08:46
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Enumerations.Abstractions;

public interface IEnumeration<TSelf> : IEnumeration
    where TSelf : IEnumeration<TSelf>
{
    //TValue Value { get; }
    //DisplayAttribute? DisplayAttribute { get; }
}
