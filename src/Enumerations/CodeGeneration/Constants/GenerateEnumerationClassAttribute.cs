// 
// GenerateEnumerationClassAttribute.cs
// 
//   Created: 2022-10-16-12:51:17
//   Modified: 2022-10-30-02:50:34
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Enumerations.CodeGeneration;

public static partial class Constants
{
    public static readonly string GenerateEnumerationClassAttributeDeclaration =
        new StreamReader(typeof(Constants).Assembly.GetManifestResourceStream("JustinWritesCode.Enumerations.CodeGeneration.Resources.GenerateEnumerationClassAttribute.cs")).ReadToEnd();
    /*
@"

[AttributeUsage(AttributeTargets.Enum)] internal class GenerateEnumerationClassAttribute : Attribute 
{
    // public string EnumerationClassName { get; set; }
    // public string Namespace { get; set; }
    // public string ToStringProperty { get; set; }
    // public string ComparisonProperty { get; set; }

    public GenerateEnumerationClassAttribute(/*string EnumerationClassName = null, string Namespace =  null, string ToStringProperty =  null, string ComparisonProperty = null*//*) 
    {
        // this.EnumerationClassName = EnumerationClassName;
        // this.Namespace = Namespace;
        // this.ToStringProperty = ToStringProperty;
        // this.ComparisonProperty = ComparisonProperty;
     } 
}
";*/
}
