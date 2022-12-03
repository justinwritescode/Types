using System;
//
// UriAttribute.cs
//
//   Created: 2022-10-16-10:50:42
//   Modified: 2022-10-30-07:14:23
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace System.ComponentModel.DataAnnotations;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = true)]
public sealed class UriAttribute : ValueAttribute<Uri>
{
    public UriAttribute(Uri uri) : base(uri) { }
    public UriAttribute(string uri) : this(new Uri(uri)) {}
    public Uri Uri => Value;
}
