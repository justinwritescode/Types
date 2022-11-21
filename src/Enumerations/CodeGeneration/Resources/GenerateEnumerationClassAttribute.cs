// 
// GenerateEnumerationClassAttribute.cs
// 
//   Created: 2022-10-30-05:40:26
//   Modified: 2022-11-11-04:52:53
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

// BEGIN
#nullable enable
using System.Runtime.CompilerServices;

[CompilerGenerated, AttributeUsage(AttributeTargets.Enum)] 
internal class GenerateEnumerationClassAttribute : Attribute 
{
    public string? EnumerationClassName { get; set; }
    public string? Namespace { get; set; }

    public GenerateEnumerationClassAttribute(string? EnumerationClassName = null, string? Namespace =  null) 
    {
        this.EnumerationClassName = EnumerationClassName;
        this.Namespace = Namespace;
     } 
}
