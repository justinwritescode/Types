// 
// EnumerationFieldDeclaration.cs
// 
//   Created: 2022-10-16-12:34:48
//   Modified: 2022-10-30-04:20:34
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Enumerations.CodeGeneration;

public static partial class Constants
{
    public static readonly string EnumerationFieldDeclaration = 
        new StreamReader(typeof(Constants).Assembly.GetManifestResourceStream("JustinWritesCode.Enumerations.CodeGeneration.Resources.EnumerationFieldDeclaration.cs")).ReadToEnd();
    /*@"
public static readonly {EnumerationClassName} {FieldName} = new {EnumerationClassName}({Id}, {Name});
";*/
}
