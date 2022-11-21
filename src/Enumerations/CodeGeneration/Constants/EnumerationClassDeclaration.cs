// 
// EnumerationClassDeclaration.cs
// 
//   Created: 2022-10-16-12:10:27
//   Modified: 2022-10-30-04:29:58
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Enumerations.CodeGeneration;

public static partial class Constants
{
    public static readonly string EnumerationClassDeclaration = 
        new StreamReader(typeof(Constants).Assembly.GetManifestResourceStream("JustinWritesCode.Enumerations.CodeGeneration.Resources.EnumerationClassDeclaration.cs")).ReadToEnd().TrimFromSentinel();
    /*@"

namespace {Namespace};

public class {EnumerationClassName} : JustinWritesCode.Enumerations.Enumeration<{EnumerationClassName}, {EnumType}>
{
    public {EnumerationClassName}(int id, string name, string toStringProperty = null, string comparisonProperty = null) : base(id, name, ({EnumType})id) { }

    public static {EnumerationClassName}[] Values = new[] { {Values} };

    {Fields}
}
";*/
}
