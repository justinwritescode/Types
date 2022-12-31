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

using System.CodeDom.Compiler;

namespace JustinWritesCode.Enumerations.CodeGeneration;
public static partial class Constants
{
    public const string DisplayAttribute = nameof(DisplayAttribute);
    public const string GenerateEnumerationClassAttributeName = "GenerateEnumerationClassAttribute";
    public const string GenerateEnumerationTypeAttributesName = "GenerateEnumerationTypeAttributes";
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

    public const string GenerateEnumerationRecordClassAttribute = "GenerateEnumerationRecordClassAttribute";
    public const string GenerateEnumerationRecordStructAttribute = "GenerateEnumerationRecordStructAttribute";
    public const string GenerateEnumerationClassAttribute = "GenerateEnumerationClassAttribute";
    public const string GenerateEnumerationStructAttribute = "GenerateEnumerationStructAttribute";

    public const string GeneratedCodeAttribute = $"""GeneratedCode("{nameof(EnumerationTypeGenerator)}", "{ThisAssembly.Info.FileVersion}")""";

    public static readonly string[] GenerateEnumerationAttributeTypeNames = new[]
    {
        GenerateEnumerationRecordClassAttribute,
        GenerateEnumerationRecordStructAttribute,
        GenerateEnumerationClassAttribute,
        GenerateEnumerationStructAttribute
    };


    [System.Diagnostics.CodeAnalysis.StringSyntax("csharp")]
    public const string GenerateEnumerationTypeAttributesDeclaration =
    $$"""""
    #if !GENERATE_ENUMERATION_TYPE_ATTRIBUTES
    #define GENERATE_ENUMERATION_TYPE_ATTRIBUTES

    using System.CodeDom.Compiler;

    #nullable enable
    [CompilerGenerated, {{GeneratedCodeAttribute}}, AttributeUsage(AttributeTargets.Enum)]
    internal abstract class GenerateEnumerationTypeAttribute : Attribute
    {
        public bool GenerateStruct { get => !GenerateClass; set => GenerateClass = !value; }
        public bool GenerateClass { get; set; } = false;
        public bool GenerateRecord { get; set; } = true;
        public string? EnumerationTypeName { get; set; }
        public string? Namespace { get; set; }

        public GenerateEnumerationTypeAttribute(string? EnumerationTypeName = null, string? Namespace =  null)
        {
            this.EnumerationTypeName = EnumerationTypeName;
            this.Namespace = Namespace;
        }
    }

    [CompilerGenerated, AttributeUsage(AttributeTargets.Enum)]
    internal abstract class GenerateEnumerationRecordTypeAttribute : GenerateEnumerationTypeAttribute
    {
        public GenerateEnumerationRecordTypeAttribute(string? EnumerationTypeName = null, string? Namespace = null) : base(EnumerationTypeName, Namespace)
        {
            GenerateRecord = true;
        }
    }

    [CompilerGenerated, AttributeUsage(AttributeTargets.Enum)]
    internal sealed class GenerateEnumerationRecordClassAttribute : GenerateEnumerationRecordTypeAttribute
    {
        public GenerateEnumerationRecordClassAttribute(string? EnumerationTypeName = null, string? Namespace = null) : base(EnumerationTypeName, Namespace)
        {
            GenerateClass = true;
        }
    }

    [CompilerGenerated, AttributeUsage(AttributeTargets.Enum)]
    internal sealed class GenerateEnumerationRecordStructAttribute : GenerateEnumerationRecordTypeAttribute
    {
        public GenerateEnumerationRecordStructAttribute(string? EnumerationTypeName = null, string? Namespace = null) : base(EnumerationTypeName, Namespace)
        {
            GenerateStruct = true;
        }
    }

    [CompilerGenerated, AttributeUsage(AttributeTargets.Enum)]
    internal sealed class GenerateEnumerationClassAttribute : GenerateEnumerationTypeAttribute
    {
        public GenerateEnumerationClassAttribute(string? EnumerationTypeName = null, string? Namespace = null) : base(EnumerationTypeName, Namespace)
        {
            GenerateClass = true;
            GenerateRecord = false;
        }
    }

    [CompilerGenerated, AttributeUsage(AttributeTargets.Enum)]
    internal sealed class GenerateEnumerationStructAttribute : GenerateEnumerationTypeAttribute
    {
        public GenerateEnumerationStructAttribute(string? EnumerationTypeName = null, string? Namespace = null) : base(EnumerationTypeName, Namespace)
        {
            GenerateStruct = true;
            GenerateRecord = false;
        }
    }

    #endif
    """"";

    public const string TypeToGenerateEnumDeclaration =
    """
    #if !TYPE_TO_GENERATE_ENUM_DEFINED
    #define TYPE_TO_GENERATE_ENUM_DEFINED

    internal enum TypeToGenerate
    {
        RecordStruct,
        Struct,
        Class,
        RecordClass
    }

    #endif
    """;

    public static string TrimFromSentinel(this string input)
    {
        var index = input.IndexOf(BeginSentinel, Ordinal);
        return index == -1 ? input : input.Substring(index + BeginSentinel.Length);
    }
}
