namespace JustinWritesCode.Enumerations.CodeGeneration;

public static partial class Constants
{
    public const string GenerateEnumerationClassAttributeDeclaration =
@"

[AttributeUsage(AttributeTargets.Enum)] public class GenerateEnumerationClassAttribute : Attribute 
{
    // public string EnumerationClassName { get; set; }
    // public string Namespace { get; set; }
    // public string ToStringProperty { get; set; }
    // public string ComparisonProperty { get; set; }

    public GenerateEnumerationClassAttribute(/*string EnumerationClassName = null, string Namespace =  null, string ToStringProperty =  null, string ComparisonProperty = null*/) 
    {
        // this.EnumerationClassName = EnumerationClassName;
        // this.Namespace = Namespace;
        // this.ToStringProperty = ToStringProperty;
        // this.ComparisonProperty = ComparisonProperty;
     } 
}
";
}
