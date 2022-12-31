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

using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using static JustinWritesCode.Enumerations.CodeGeneration.Constants;

internal record struct EnumDeclaration(EnumDeclarationSyntax SyntaxTree, SemanticModel SemanticModel, string EnumerationClassName = "", string EnumerationNamespace = "", TypeToGenerate TypeToGenerate = TypeToGenerate.RecordStruct)
{
    public string EnumerationClassName { get; set; } = EnumerationClassName;
    public string EnumerationNamespace { get; set; } = EnumerationNamespace;
    public TypeToGenerate TypeToGenerate { get; set; } = TypeToGenerate;
    // {
    //     get
    //     {
    //         var enumType =  EnumerationTypeAttributeType switch {
    //             GenerateEnumerationRecordStructAttribute => TypeToGenerate.RecordStruct,
    //             GenerateEnumerationClassAttribute => TypeToGenerate.Class,
    //             GenerateEnumerationRecordClassAttribute => TypeToGenerate.RecordClass,
    //             GenerateEnumerationStructAttribute => TypeToGenerate.Struct,
    //             _ => TypeToGenerate.RecordStruct
    //         };
    //         WriteLine($"TypeToGenerate ({EnumerationClassName}): {enumType}");
    //         return _typeToGenerate ??= enumType;
    //     }
    //     set => _typeToGenerate = value;
    // }

    private AttributeSyntax? _enumerationTypeAttributeDeclaration = null;
    public AttributeSyntax EnumerationTypeAttributeDeclaration
    {
        get {
             _enumerationTypeAttributeDeclaration ??= SyntaxTree.AttributeLists.SelectMany(a => a.Attributes).FirstOrDefault(x => GenerateEnumerationAttributeTypeNames.Contains(x.Name.ToString()));
            WriteLine($"EnumerationTypeAttributeDeclaration ({EnumerationClassName}): {_enumerationTypeAttributeDeclaration}");
            return _enumerationTypeAttributeDeclaration;
        }
        set => _enumerationTypeAttributeDeclaration = value;
    }

    public string? EnumerationTypeAttributeType => EnumerationTypeAttributeDeclaration?.Name?.ToString();
}
