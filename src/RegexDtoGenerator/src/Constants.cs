/*
 * Constants.cs
 *
 *   Created: 2022-12-28-04:55:15
 *   Modified: 2022-12-28-04:55:17
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022-2023 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.RegexDtoGenerator;

public static class Constants
{
    public const string RegexDtoGenerator = "RegexDtoGenerator";
    public const string RegexDtoGeneratorVersion = "0.0.1";
    public const string RegexDtoGeneratorDescription =
        "Generates a C# type from a regular expression.";
    public const string RegexDtoGeneratorHelpText =
        "Generates a C# type from a regular expression.";
    public const string RegexDtoGeneratorHelpTextExample =
        "Example: RegexDtoGenerator -r \"(?<Name>\\w+) (?<Age>\\d+)\" -n Person";
    public const string RegexDtoGeneratorHelpTextExample2 =
        "Example: RegexDtoGenerator -r \"(?<Name>\\w+) (?<Age>\\d+)\" -n Person -o \"C:\\Users\\Justin\\Documents\\Person.cs\"";
    public const string RegexDtoGeneratorHelpTextExample3 =
        "Example: RegexDtoGenerator -r \"(?<Name>\\w+) (?<Age>\\d+)\" -n Person -o \"C:\\Users\\Justin\\Documents\\Person.cs\" -p \"JustinWritesCode.RegexDtoGenerator\"";
    public const string RegexDtoGeneratorHelpTextExample4 =
        "Example: RegexDtoGenerator -r \"(?<Name>\\w+) (?<Age>\\d+)\" -n Person -o \"C:\\Users\\Justin\\Documents\\Person.cs\" -p \"JustinWritesCode.RegexDtoGenerator\" -c \"PersonDto\"";
    public const string RegexDtoGeneratorHelpTextExample5 =
        "Example: RegexDtoGenerator -r \"(?<Name>\\w+) (?<Age>\\d+)\" -n Person -o \"C:\\Users\\Justin\\Documents\\Person.cs\" -p \"JustinWritesCode.RegexDtoGenerator\" -c \"PersonDto\" -i";
    public const string RegexDtoGeneratorHelpTextExample6 =
        "Example: RegexDtoGenerator -r \"(?<Name>\\w+) (?<Age>\\d+)\" -n Person -o \"C:\\Users\\Justin\\Documents\\Person.cs\" -p \"JustinWritesCode.RegexDtoGenerator\" -c \"PersonDto\" -i -s";

    public const string RegexDtoAttributeName = "RegexDtoAttribute";

    public const string Header =
    """
    /*
     * {{ file_name }}
     *
     *   Created: {{ created_date }}
     */
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Text;
    using System.Globalization;
    using System.Diagnostics.CodeAnalysis;

    #nullable enable
    """;

    public const string RegexDtoAttributeDeclaration = """"
    #nullable enable
    [System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
    internal sealed class RegexDtoAttribute : System.Attribute
    {
        public RegexDtoAttribute(
            #if NET7_0_OR_GREATER
            [System.Diagnostics.CodeAnalysis.StringSyntax("regex")]
            #endif
            string regex, System.Type? baseType = null)
        {
            Regex = regex;
        }

        public string Regex { get; }
    }
    """";

    public const string RegexDtoAttributeUsage = """"
    [RegexDto(@""(?<Name>\\w+) (?<Age>\\d+)"")]
    public class PersonDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    """";

    public const string RegexDtoBaseTypeDeclaration = """"

    #nullable enable
    namespace {{ namespace_name }}
    {
        {{ visibility }} partial abstract {{ target_data_structure_type }} {{ type_name }}Base {{ if base_type != "" }} : {{ base_type }} {{ end }}
        {
            #if NET7_0_OR_GREATER
            [System.Diagnostics.CodeAnalysis.StringSyntax("regex")]
            #endif
            public const string RegexString = @"""{{ regex }}""";
            #if NET7_0_OR_GREATER
            [GeneratedRegex(RegexString, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.RightToLeft | RegexOptions.Singleline)]
            public static partial System.Text.RegularExpressions.Regex Regex();
            #else
            private static readonly System.Text.RegularExpressions.Regex _regex = new System.Text.RegularExpressions.Regex(RegexString);
            public static System.Text.RegularExpressions.Regex Regex() => _regex;
            #endif

            {{ members }}
        }

        protected {{ type_name }}Base()
        {
        }
    }

    """";

    public const string RegexDtoTypeDeclaration = """"

    #nullable enable
    namespace {{ namespace_name }}
    {
        {{ visibility }} partial {{ target_data_structure_type }} {{ type_name }} {{ if base_type != "" }} : {{ base_type }} {{ end }}
        {
            #if NET7_0_OR_GREATER
            [System.Diagnostics.CodeAnalysis.StringSyntax("regex")]
            #endif
            public const string RegexString = @"""{{ regex }}""";

            #if NET7_0_OR_GREATER
            [GeneratedRegex(RegexString, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.RightToLeft | RegexOptions.Singleline)]
            public static partial System.Text.RegularExpressions.Regex Regex();
            #else
            private static readonly System.Text.RegularExpressions.Regex _regex = new System.Text.RegularExpressions.Regex(RegexString);
            public static System.Text.RegularExpressions.Regex Regex() => _regex;
            #endif

            {{ members }}
        }
    }

    """";

    public const string RegexDtoParseDeclaration = """
    public static {{ type_name }} Parse(string s)
    {
        var match = Regex().Match(s);
        if (!match.Success)
        {
            throw new System.ArgumentException($"The string \"{s}\" does not match the regular expression \"{RegexString}\".", nameof(s));
        }

        return new {{ type_name }}
        {
            {{~ for property in properties ~}}
            {{~ if property.is_nullable ~}}
            {{ property.name }} = match.Groups["{{ property.name }}"]?.Value is null ? null : ({{ property.type }}?)System.Convert.ChangeType(match.Groups["{{ property.name }}"]?.Value, typeof({{ property.type }})),
            {{~ else ~}}
            {{ property.name }} = ({{ property.type }})System.Convert.ChangeType(match.Groups["{{ property.name }}"]?.Value, typeof({{ property.type }})),
            {{~ end ~}}
            {{~ end ~}}
        };
    }
    """;
    public const string RegexDtoConstructorDeclaration = """
    {{ parameterless_constructor_visibility }} {{ type_name }} () { }

    {{ parameterized_constructor_visibility }} {{ type_name }} (string s)
    {
        var match = Regex().Match(s);
        if (!match.Success)
        {
            throw new System.ArgumentException($"The string \"{s}\" does not match the regular expression \"{RegexString}\".", nameof(s));
        }

        {{~ for property in properties ~}}
        {{~ if property.is_nullable ~}}
        {{ property.name }} = match.Groups["{{ property.name }}"]?.Value is null ? null : ({{ property.type }}?)System.Convert.ChangeType(match.Groups["{{ property.name }}"]?.Value, typeof({{ property.type }}));
        {{~ else ~}}
        {{ property.name }} = ({{ property.type }})System.Convert.ChangeType(match.Groups["{{ property.name }}"]?.Value, typeof({{ property.type }}));
        {{~ end ~}}
        {{~ end ~}}
    }
    """;

    public const string RegexDtoPropertiesDeclaration = """
    {{~ for property in properties ~}}
    {{~ if property.is_nullable ~}}
    public {{ property.overridability }} {{ property.type }}? {{ property.name }} { get; set; }
    {{~ else ~}}
    public {{ property.overridability }} {{ property.type }} {{ property.name }} { get; set; }
    {{~ end ~}}
    {{~ end ~}}
    """;

    public const string RegexDtoDeclaration = """"

    #nullable enable
    namespace {{~ namespace_name ~}};

    {{ visibility }} partial {{ target_data_structure_type }} {{ type_name }}
    {
        #if NET7_0_OR_GREATER
        [System.Diagnostics.CodeAnalysis.StringSyntax("regex")]
        #endif
        public const string RegexString = @"""{{ regex }}""";

        #if NET7_0_OR_GREATER
        [GeneratedRegex(RegexString, RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.ExplicitCapture | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace | RegexOptions.Multiline | RegexOptions.RightToLeft | RegexOptions.Singleline)]
        public static partial System.Text.RegularExpressions.Regex Regex();
        #else
        private static readonly System.Text.RegularExpressions.Regex _regex = new System.Text.RegularExpressions.Regex(RegexString);
        public static System.Text.RegularExpressions.Regex Regex() => _regex;
        #endif

        public static {{ type_name }} Parse(string s)
        {
            var match = Regex().Match(s);
            if (!match.Success)
            {
                throw new System.ArgumentException($"The string \"{s}\" does not match the regular expression \"{RegexString}\".", nameof(s));
            }

            return new {{ type_name }}
            {
                {{~ for property in properties ~}}
                {{~ if property.is_nullable ~}}
                {{ property.name }} = match.Groups["{{ property.name }}"]?.Value is null ? null : ({{ property.type }}?)System.Convert.ChangeType(match.Groups["{{ property.name }}"]?.Value, typeof({{ property.type }})),
                {{~ else ~}}
                {{ property.name }} = ({{ property.type }})System.Convert.ChangeType(match.Groups["{{ property.name }}"]?.Value, typeof({{ property.type }})),
                {{~ end ~}}
                {{~ end ~}}
            };
        }

        {{~ for property in properties ~}}
        {{~ if property.is_nullable ~}}
        public {{ property.overridability }} {{ property.type }}? {{ property.name }} { get; set; }
        {{~ else ~}}
        public {{ property.overridability }} {{ property.type }} {{ property.name }} { get; set; }
        {{~ end ~}}
        {{~ end ~}}
    }
    """";

    internal record struct RegexDtoPropertyDeclarationModel(
        string Name,
        string Type,
        bool IsNullable,
        string Overridability,
        bool IsClass = false
    );

    public static readonly Scriban.Template RegexDtoDeclarationTemplate = Scriban.Template.Parse(
        RegexDtoTypeDeclaration
    );
    public static readonly Scriban.Template RegexDtoParseDeclarationTemplate =
        Scriban.Template.Parse(RegexDtoParseDeclaration);
    public static readonly Scriban.Template RegexDtoPropertiesDeclarationTemplate =
        Scriban.Template.Parse(RegexDtoPropertiesDeclaration);
    public static readonly Scriban.Template RegexDtoConstructorDeclarationTemplate =
        Scriban.Template.Parse(RegexDtoConstructorDeclaration);

    internal record struct RegexDtoConstructorDeclarationModel
    {
        public string ParameterizedConstructorVisibility { get; set; }
        public string ParameterlessConstructorVisibility { get; set; }
        public string TypeName { get; set; }
        public RegexDtoPropertyDeclarationModel[] Properties { get; set; }
    }

    internal record struct RegexDtoPropertiesDeclarationModel
    {
        public string TypeName { get; set; }
        public RegexDtoPropertyDeclarationModel[] Properties { get; set; }
    }

    internal record struct RegexDtoDeclarationTemplateModel
    {
        public string NamespaceName { get; set; }
        public string TargetDataStructureType { get; set; }
        public string TypeName { get; set; }
        public string Visibility { get; set; }
        public string Regex { get; set; }
        public RegexDtoPropertyDeclarationModel[] Properties { get; set; }
        public string BaseType { get; set; }
        public string Members { get; set; }
    }
}
