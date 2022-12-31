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
using System.Linq;
using System.Xml;
using Microsoft.CodeAnalysis;

internal record struct EnumDeclarationParams(string EnumerationClassName, string EnumNamespace, string Namespace, string EnumType, string Id_type, string Value_type, string XmlDocumentation, string IsReadonly, TypeToGenerate TypeToGenerate, string Values, string Fields)
{
    public string Documentation
    {
        get
        {
            var defaultDocumentation = new System.Xml.Linq.XElement("summary", $"An enumeration of {EnumerationClassName} values.");
            try { return (XmlDocumentation.SelectXpath("//summary").FirstOrDefault() ?? defaultDocumentation).ToString(); }
            catch { return defaultDocumentation.ToString(); }
        }
    }

    public string EnumerationType => TypeToGenerate switch
    {
        TypeToGenerate.RecordStruct => "record struct",
        TypeToGenerate.RecordClass => "record class",
        TypeToGenerate.Struct => "struct",
        TypeToGenerate.Class => "class",
        _ => throw new NotImplementedException()
    };
}
