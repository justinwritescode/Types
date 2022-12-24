//
// IEnumeration<TId>.cs
//
//   Created: 2022-11-02-03:46:21
//   Modified: 2022-11-02-03:46:21
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//
namespace JustinWritesCode.Enumerations.Abstractions;

public interface IEnumeration<TSelf, TId> : IEnumeration<TSelf>
    where TId : IComparable, IComparable<TId>, IEquatable<TId>
    where TSelf : struct, IEnumeration<TSelf, TId>
{
    //string Name { get; }
}
