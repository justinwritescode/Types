// 
// Enumeration{TEnumeration}.cs
// 
//   Created: 2022-10-18-10:54:13
//   Modified: 2022-10-31-01:53:38
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Enumerations;
using System.Diagnostics;
using System;

/// <summary>
///  An abstract base class for enumerations.
/// </summary>
/// <typeparam name="TEnumeration">The enumeration class</typeparam>
/// <remarks>This class was partially adapted from the contents of the now-defunct NuGetPackage "Enumeration" https://www.nuget.org/packages/Enumeration</remarks>
// [Serializable]
// [DebuggerDisplay("{DisplayName} - {Value}")]
// public abstract class Enumeration<TEnumeration> : Enumeration
//      where TEnumeration : Enumeration<TEnumeration>
// {
//     protected Enumeration(object id, string name)
//         : base(id, name)
//     {
//     }
// }
