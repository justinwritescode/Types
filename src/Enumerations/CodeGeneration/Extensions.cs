/*
 * EnumerationClassGenerator.cs
 *
 *   Created: 2022-10-16-04:03:15
 *   Modified: 2022-11-11-01:59:02
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace JustinWritesCode.Enumerations.CodeGeneration;

using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using static JustinWritesCode.Enumerations.CodeGeneration.Constants;

public static class Extensions
{
    internal static AttributeData? GetGenerateEnumerationTypeAttribute(this ITypeSymbol typeSymbol)
    {
        return typeSymbol?.GetAttributes().GetGenerateEnumerationTypeAttribute();
    }

    internal static AttributeData? GetGenerateEnumerationTypeAttribute(this IEnumerable<AttributeData> attributes)
    {
        return attributes.FirstOrDefault(a => GenerateEnumerationTypeAttributesName.Contains(a.AttributeClass.Name));
    }
}
