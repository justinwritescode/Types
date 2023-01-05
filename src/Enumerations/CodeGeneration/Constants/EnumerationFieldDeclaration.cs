//
// EnumerationFieldDeclaration.cs
//
//   Created: 2022-10-16-12:34:48
//   Modified: 2022-10-30-04:20:34
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022-2023 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace JustinWritesCode.Enumerations.CodeGeneration;

public static partial class Constants
{
    // public static readonly string EnumerationFieldDeclaration =
    //     new StreamReader(typeof(Constants).Assembly.GetManifestResourceStream("JustinWritesCode.Enumerations.CodeGeneration.Resources.EnumerationFieldDeclaration.cs")).ReadToEnd().TrimFromSentinel();
    public const string EnumerationFieldDeclaration =
$$$""""

/**
    {{ documentation }}
*/
[System.Runtime.CompilerServices.CompilerGenerated]
[{{{GeneratedCodeAttribute}}}]
public record struct {{ field_name }}
{
    public static readonly {{ enumeration_class_name }} Instance = new {{ enumeration_class_name }}({{ id }}, ({{ enum_type }})({{ value }}), "{{ name }}");

    public const string Name = "{{ name }}";
    public const string DisplayName = "{{ display_name }}";
    public const string ShortName = "{{ short_name }}";
    public const int Order = {{ order }};
    public const int Id = {{ id }};
    public const {{ value_type }} Value = ({{ enum_type }})({{ value }});
}
"""";
}
