// 
// EnumerationClassGenerator.Constants.cs
// 
//   Created: 2022-10-30-05:13:08
//   Modified: 2022-10-30-05:13:08
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 
namespace JustinWritesCode.Enumerations.CodeGeneration;
public static partial class Constants
{
    public const string DisplayAttribute = nameof(DisplayAttribute);
    public const string GenerateEnumerationClassAttributeName = "GenerateEnumerationClassAttribute";
    public const string GenerateEnumerationClassAttributeNameWithoutAttribute = "GenerateEnumerationClass";
    public const string EnumerationClassName = "ENUMERATION_CLASS_NAME";
    public const string Order = "ORDER";
    public const string ShortName = "SHORT_NAME";
    public const string DisplayName = "DISPLAY_NAME";
    public const string GroupName = "GROUP_NAME";
    public const string FieldName = "FIELD_NAME";
    public const string EnumNamespace = "ENUM_NAMESPACE";
    public const string Namespace = "NAMESPACE";
    public const string Fields = "/*FIELDS*/";
    public const string Values = "/*VALUES*/";
    public const string Filename = "FILENAME";
    public const string AuthorEmail = "AUTHOR_EMAIL";
    public const string AuthorName = "AUTHOR_NAME";
    public const string EnumType = "ENUM_TYPE";
    public const string Timestamp = "TIMESTAMP";
    public const string Year = "YEAR";
    public const string Name = "NAME";
    public const string Id = "ID";
    public const string BeginSentinel = "// BEGIN";

    public static string TrimFromSentinel(this string input)
    {
        var index = input.IndexOf(BeginSentinel, StringComparison.Ordinal);
        return index == -1 ? input : input.Substring(index + BeginSentinel.Length);
    }
}