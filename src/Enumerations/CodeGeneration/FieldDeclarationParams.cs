using System.Xml.Linq;
/*
 * EnumerationClassGenerator.cs
 *
 *   Created: 2022-10-16-04:03:15
 *   Modified: 2022-11-11-01:59:02
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
namespace JustinWritesCode.Enumerations.CodeGeneration;
using System.Linq;
using System.Xml;
using Microsoft.CodeAnalysis;

internal record struct FieldDeclarationParams(string FieldName, string EnumerationClassName, string EnumNamespace, string DisplayName, string ShortName, string Order, string GroupName, string? Id, string Namespace, string EnumType, string Name, object Value, string Id_type, string Value_type, string XmlDocumentation)
{
    public string Documentation
    {
        get
        {
            var defaultDocumentation = new XElement("summary", $"{DisplayName} - {FieldName}");
            try { return (XmlDocumentation.SelectXpath("//summary").FirstOrDefault() ?? defaultDocumentation).ToString(); }
            catch { return defaultDocumentation.ToString(); }
        }
    }
}
