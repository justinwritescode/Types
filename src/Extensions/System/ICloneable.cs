//
// ICloneable.cs
//
//   Created: 2022-10-23-11:39:49
//   Modified: 2022-11-11-06:11:07
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace System;

/// <summary>Clones the object</summary>
/// <typeparam name="TSelf">The class' name</typeparam>
// #if DEFINE_INTERNAL
internal interface ICloneable<TSelf> where TSelf : ICloneable<TSelf>
// #else
// public interface ICloneable<TSelf> where TSelf : ICloneable<TSelf>
// #endif
{
    /// <summary>Clones the object</summary>
    /// <returns>The cloned object</returns>
    TSelf Clone();
}
