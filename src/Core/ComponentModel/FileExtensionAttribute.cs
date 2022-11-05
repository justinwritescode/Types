// 
// FileExtensionAttribute.cs
// 
//   Created: 2022-10-30-07:46:05
//   Modified: 2022-10-30-10:01:19
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

using System;
// 
// ExtensionAttribute.cs
// 
//   Created: 2022-10-30-07:46:05
//   Modified: 2022-10-30-07:46:06
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 
namespace JustinWritesCode.ComponentModel;

/// <summary>
/// For marking an item with a file extension.
/// </summary>
[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
public sealed class FileExtensionAttribute : ValueAttribute<string[]>
{
    public FileExtensionAttribute(params string[] extensions) : base((extensions.Select(extension => (!extension.StartsWith(".") ? "." : "") + extension)).ToArray()) { }

    /// <summary>
    /// The extensions with the leading dot.
    /// </summary>
    /// <value><inheritdoc cref="Extension" path="/summary/node()" /></value>
    public string[] Extensions => Value;

    /// <summary>
    /// The first extension with the leading dot.
    /// </summary>
    /// <value><inheritdoc cref="Extension" path="/summary/node()" /></value>
    public string? Extension => Value?.FirstOrDefault();
}
