// 
// Enumeration{TEnumeration, TId}.cs
// 
//   Created: 2022-11-03-12:18:18
//   Modified: 2022-11-03-12:18:18
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 
namespace JustinWritesCode.Enumerations;
public class Enumeration<TSelf, TId> : Enumeration<TId>
    where TSelf : Enumeration<TId>
    where TId : IComparable, IComparable<TId>, IEquatable<TId>
{
    protected Enumeration(TId id, string name)
        : base(id, name)
    {
    }
}
