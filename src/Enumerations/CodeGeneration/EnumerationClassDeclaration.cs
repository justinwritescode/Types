namespace JustinWritesCode.Enumerations.CodeGeneration;

public static partial class Constants
{
    public const string EnumerationClassDeclaration = @"

namespace {Namespace};

public class {EnumerationClassName} : JustinWritesCode.Enumerations.Enumeration<{EnumerationClassName}, {EnumType}>
{
    public {EnumerationClassName}(int id, string name, string toStringProperty = null, string comparisonProperty = null) : base(id, name, ({EnumType})id) { }

    public static {EnumerationClassName}[] Values = new[] { {Values} };

    {Fields}
}
";
}
