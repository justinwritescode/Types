namespace JustinWritesCode.Enumerations.CodeGeneration;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Linq;
using System;
using static JustinWritesCode.Enumerations.CodeGeneration.Constants;

[Microsoft.CodeAnalysis.Generator]
public class EnumerationClassGenerator : Microsoft.CodeAnalysis.IIncrementalGenerator
{
    public const string GenerateEnumerationClassAttributeName = "GenerateEnumerationClassAttribute";
    public const string EnumerationClassName = nameof(EnumerationClassName);
    public const string FieldName = nameof(FieldName);
    public const string Namespace = nameof(Namespace);
    public const string Fields = nameof(Fields);
    public const string Values = nameof(Values);
    public const string Filename = nameof(Filename);
    public const string AuthorEmail = nameof(AuthorEmail);
    public const string AuthorName = nameof(AuthorName);
    public const string EnumType = nameof(EnumType);
    public const string Timestamp = nameof(Timestamp);
    public const string Year = nameof(Year);
    public const string Name = nameof(Name);
    public const string Id = nameof(Id);

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
#if DEBUGATTACH
        if (!System.Diagnostics.Debugger.IsAttached)
        {
            System.Diagnostics.Debugger.Launch();
        }
#endif
        var enumDeclarations = context.SyntaxProvider.CreateSyntaxProvider(
           predicate: (s, t) => s is EnumDeclarationSyntax,
           transform: GetTypeSymbols).Collect();

        context.RegisterSourceOutput(enumDeclarations, GenerateSource);
    }


    // public void Execute(GeneratorExecutionContext context)
    // {
    //     var enumDeclarations = context.SyntaxProvider.CreateSyntaxProvider(
    //        predicate: (s, t) => s is EnumDeclarationSyntax,
    //        transform: GetTypeSymbols).Collect();

    //     context.RegisterSourceOutput(enumDeclarations, GenerateSource);

    //     context.SyntaxReceiver
    // }

    private void GenerateSource(SourceProductionContext context, ImmutableArray<ITypeSymbol> typeSymbols)
    {
        try
        {
            var codeHeader = CodeHeader.Replace($"{{{AuthorName}}}", "JustinWritesCode")
                .Replace($"{{{AuthorEmail}}}", "justin@justinwritescode.com")
                .Replace($"{{{Year}}}", DateTime.Now.Year.ToString())
                .Replace($"{{{Timestamp}}}", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss UTC"));

            // var generateEnumerationClassAttributeDeclaration = GenerateEnumerationClassAttributeDeclaration.Replace("{{Namespace}")
            context.AddSource("TypeSymbols.g.cs", @$"// {string.Join("\n", typeSymbols.Select(ts => ts.Name))}");

            var sb = new StringBuilder();
            foreach (var symbol in typeSymbols)
            {
                if (symbol is null)
                    continue;

                var generateEnumClassAttributeDecoration = symbol.GetAttributes().FirstOrDefault(a => a.AttributeClass.Name == GenerateEnumerationClassAttributeName);

                context.AddSource(symbol.Name + "_Attributes.g.cs",
                    @$"/* {string.Join(", ", generateEnumClassAttributeDecoration?.ConstructorArguments.Select(arg => $"{arg.Type}: {arg.Value}") ?? Array.Empty<string>())} */");

                if (generateEnumClassAttributeDecoration != null)
                {
                    context.AddSource("generateEnumClassAttributeDecoration.g.cs", @$"/* {generateEnumClassAttributeDecoration}({generateEnumClassAttributeDecoration.ConstructorArguments.Count()}, {generateEnumClassAttributeDecoration.NamedArguments.Count()}) */");
                    context.AddSource(symbol.Name + "." + GenerateEnumerationClassAttributeName + ".ConstructorArgs.g.cs", @$"/* {string.Join("\n", generateEnumClassAttributeDecoration.ConstructorArguments)} */s");
                    var enumType = symbol.Name;
                    var enumNamespace = GetNamespace(symbol.ContainingNamespace);
                    var enumerationClassName = generateEnumClassAttributeDecoration.ConstructorArguments.FirstOrDefault().Value?.ToString() ?? enumType + "Enumeration";
                    //generateEnumClassAttributeDecoration.NamedArguments
                    var @namespace = generateEnumClassAttributeDecoration.ConstructorArguments.Skip(1).FirstOrDefault().Value?.ToString() ?? enumNamespace;
                    //var toStringProperty = generateEnumClassAttributeDecoration.ConstructorArguments.ToArray()[2].Value.ToString();
                    //var comparisonProperty = generateEnumClassAttributeDecoration.ConstructorArguments.ToArray()[3].Value.ToString();

                    var enumFields = symbol.GetMembers().Where(member => member.Kind == SymbolKind.Field);
                    var enumClassDeclaration =
                        EnumerationClassDeclaration
                        .Replace($"{{{EnumerationClassName}}}", enumerationClassName)
                        .Replace($"{{{Namespace}}}", @namespace)
                        .Replace($"{{{EnumType}}}", enumType)
                        .Replace($"{{{Values}}}", string.Join(", ", enumFields.Select(f => $"{enumerationClassName}.{f.Name}")))
                        .Replace($"{{{Fields}}}",
                            string.Join(" ", enumFields.Select(f =>
                                EnumerationFieldDeclaration
                                .Replace($"{{{EnumerationClassName}}}", enumerationClassName)
                                .Replace($"{{{FieldName}}}", f.Name)
                                .Replace($"{{{Id}}}", ((IFieldSymbol)f).ConstantValue.ToString())
                                .Replace($"{{{Name}}}", $"\"{((IFieldSymbol)f).ConstantValue.ToString()}\""))));
                    var enumClassFile = codeHeader + enumClassDeclaration;

                    context.AddSource($"{enumerationClassName}.g.cs", SourceText.From(codeHeader.Replace($"{{{Filename}}}", $"{enumerationClassName}.g.cs") + "\n" + enumClassFile, Encoding.UTF8));
                }

                // context.AddSource(enumerationClassName + ".g.cs", SourceText.From(EnumerationClassDeclaration, Encoding.UTF8));
            }

            context.AddSource(GenerateEnumerationClassAttributeName + ".g.cs", SourceText.From(codeHeader.Replace($"{{{Filename}}}", $"{GenerateEnumerationClassAttributeName}.g.cs") + "\n" + GenerateEnumerationClassAttributeDeclaration, Encoding.UTF8));
        }
        catch (Exception ex)
        {
            context.AddSource("Error.g.cs", @$"Exception: {ex.Message}
{ex.StackTrace}");
        }
    }

    private string GetNamespace(INamespaceSymbol ns, string? nsSoFar = null)
    {
        if (ns.IsGlobalNamespace) return nsSoFar;
        else return GetNamespace(ns.ContainingNamespace, ns.Name + (nsSoFar is null ? "" : "." + nsSoFar));
    }

    private ITypeSymbol GetTypeSymbols(GeneratorSyntaxContext context, CancellationToken cancellationToken)
    {
        var decl = (EnumDeclarationSyntax)context.Node;

        if (context.SemanticModel.GetDeclaredSymbol(decl, cancellationToken) is ITypeSymbol typeSymbol)
        {
            return typeSymbol;
        }

        return null;
    }
}
