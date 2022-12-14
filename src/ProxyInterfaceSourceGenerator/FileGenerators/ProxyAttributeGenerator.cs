//
// ProxyAttributeGenerator.cs
//
//   Created: 2022-11-12-07:51:52
//   Modified: 2022-11-12-07:52:09
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022-2023 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

using ProxyInterfaceSourceGenerator.Models;

namespace ProxyInterfaceSourceGenerator.FileGenerators;

internal class ProxyAttributeGenerator : IFileGenerator
{
    private const string ClassName = "GenerateProxyInterfaceAttribute";

    public FileData GenerateFile()
    {
        return new FileData($"{ClassName}.g.cs", $@"//----------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by https://github.com/StefH/ProxyInterfaceSourceGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//----------------------------------------------------------------------------------------

using System;

    [AttributeUsage(AttributeTargets.Interface)]
    internal class {ClassName} : Attribute
    {{
        public Type Type {{ get; }}
        public bool ProxyBaseClasses {{ get; }}

        public {ClassName}(Type type, bool proxyBaseClasses = false)
        {{
            Type = type;
            ProxyBaseClasses = proxyBaseClasses;
        }}
    }}
");
    }
}
