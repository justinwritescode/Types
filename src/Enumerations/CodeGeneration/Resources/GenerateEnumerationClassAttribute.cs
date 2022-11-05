// 
#nullable enable
using System.Runtime.CompilerServices;

[CompilerGenerated, AttributeUsage(AttributeTargets.Enum)] 
internal class GenerateEnumerationClassAttribute : Attribute 
{
    public string? EnumerationClassName { get; set; }
    public string? Namespace { get; set; }

    public GenerateEnumerationClassAttribute(string? EnumerationClassName = null, string? Namespace =  null) 
    {
        this.EnumerationClassName = EnumerationClassName;
        this.Namespace = Namespace;
     } 
}
