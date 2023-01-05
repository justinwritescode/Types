/* 
 * GenerateInterfaceAttribute.cs
 * 
 *   Created: 2022-11-12-04:13:09
 *   Modified: 2022-11-12-04:13:10
 * 
 *   Author: Justin Chase <justin@justinwritescode.com>
 *   
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
 // BEGIN
using System;

[AttributeUsage(AttributeTargets.Interface)]
internal class {ClassName} : Attribute
{
    public Type Type {{ get; } }
    public bool ProxyBaseClasses {{ get; }}

    public {ClassName} (Type type, bool proxyBaseClasses = false)
    {
        {
            Type = type;
            ProxyBaseClasses = proxyBaseClasses;
        }
    }
}
