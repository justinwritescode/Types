// 
// Enumeration<TId>.cs
// 
//   Created: 2022-11-02-03:53:23
//   Modified: 2022-11-02-07:40:11
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

// // 
// // Enumeration<TId>.cs
// // 
// //   Created: 2022-11-02-03:53:23
// //   Modified: 2022-11-02-03:53:23
// // 
// //   Author: Justin Chase <justin@justinwritescode.com>
// //   
// //   Copyright © 2022 Justin Chase, All Rights Reserved
// //      License: MIT (https://opensource.org/licenses/MIT)
// // 
// namespace JustinWritesCode.Enumerations;
// using System.Reflection;
// using System.ComponentModel.DataAnnotations;
// using JustinWritesCode.Abstractions;
// public abstract class Enumeration<TId> : Enumeration, IEnumeration<TId>
//     where TId : IComparable, IComparable<TId>, IEquatable<TId>
// {
//     protected Enumeration(IEquatable<IComparable> id, string name)
//     {
//         Id = id;
//         Name = name;
//     }

//     public virtual TId Id => (TId)base.Id;
//     public virtual string Name { get; init; }
//     public virtual string ShortName => Name;
//     public virtual string Description => Name;
//     protected Func<IEnumeration<TId>, string> ToStringDelegate { get; init; } = e => e.DisplayName;
//     public override string ToString() => ToStringDelegate(this);
//     public virtual int CompareTo(IEnumeration other) => Id.CompareTo(other.Id);
//     public override bool Equals(IEnumeration other) => Id.Equals(other.Id);
//     public override int GetHashCode() => Id.GetHashCode();
// }
