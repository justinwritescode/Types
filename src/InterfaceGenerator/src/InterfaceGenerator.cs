//
// InterfaceGenerator.cs
//
//   Created: 2022-11-11-03:54:47
//   Modified: 2022-11-12-11:16:54
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022-2023 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//


namespace JustinWritesCode.InterfaceGenerator;

// using JustinWritesCode.CodeGeneration.Extensions;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;

[Generator]
public partial class EnumerationClassGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var interfaces = context.SyntaxProvider.ForAttributeWithMetadataName(GenerateInterfaceAttributeName,
            (token, _) => token is InterfaceDeclarationSyntax interfaceDeclarationSyntax && interfaceDeclarationSyntax.AttributeLists.Any(al  => al.Attributes.Any(a => a.Name.ToString() == GenerateInterfaceAttributeName)),
        (context, _) =>
            (context.Attributes.FirstOrDefault(a => a.AttributeClass?.Name == GenerateInterfaceAttributeName), context.TargetSymbol as INamedTypeSymbol, context.SemanticModel)
        ).Collect();

        var compilation = context.CompilationProvider;

        context.RegisterSourceOutput(interfaces, Generate);

        context.RegisterPostInitializationOutput((ctx) => ctx.AddSource($"{GenerateInterfaceAttributeName}.g.cs", GenerateInterfaceAtributeDeclaration));
    }

    protected static void Generate(SourceProductionContext context, ImmutableArray<(AttributeData, INamedTypeSymbol, SemanticModel)> values)
    {
        context.AddSource($"AttributeCount.g.cs", $"/* {values.Length} */");
        foreach(var (attributeData, interfaceSymbol, semanticModel) in values)
        {
            var interfaceName = interfaceSymbol.Name;
            var interfaceNamespace = interfaceSymbol.ContainingNamespace.ToDisplayString();
            var classToGenerateTheInterfaceFor = attributeData.ConstructorArguments.First().Value as INamedTypeSymbol;
            context.AddSource(interfaceName + ".g.cs",
            InterfaceDeclarationTemplate.Render(new InterfaceGeneratorModel(interfaceNamespace, interfaceName,
                string.Join(Environment.NewLine,
                    classToGenerateTheInterfaceFor
                    .GetMembers()
                    .Where(member => member.Kind is SymbolKind.Property)
                    .OfType<IPropertySymbol>()
                    .Where(p => p.DeclaredAccessibility == Accessibility.Public)
                    .Select(p =>
                        PropertyDeclarationTemplate.Render(new PropertyDeclarationModel("public", p.Type.ToDisplayString(), p.Name, p.GetMethod != null, p.SetMethod != null)))) +
                string.Join(Environment.NewLine,
                    classToGenerateTheInterfaceFor
                    .GetMembers()
                    .Where(member => member.Kind is SymbolKind.Method)
                    .OfType<IMethodSymbol>()
                    .Where(m => m.DeclaredAccessibility == Accessibility.Public && m.CanBeReferencedByName)
                    .Select(m =>
                        MethodDeclarationTemplate.Render(new MethodDeclarationModel(m.ReturnType.ToDisplayString(),
                            m.Name + (m.IsGenericMethod ? $"<{string.Join(", ", m.TypeParameters.Select(tp => tp.Name))}>" : ""),
                            string.Join(", ", m.Parameters.Select(p => $"{p.Type.ToDisplayString()} {p.Name}")),
                            m.IsGenericMethod ? $"{string.Join(Environment.NewLine,
                                m.TypeParameters.Select(tp =>
                                    tp.HasReferenceTypeConstraint || tp.HasValueTypeConstraint || tp.HasConstructorConstraint || tp.ConstraintTypes.Any() ?
                                    "where " + tp.Name + " : " +
                                    (tp.HasReferenceTypeConstraint ? "class" : "") +
                                    (tp.HasValueTypeConstraint ? "struct" : "") +
                                    string.Join(", ", tp.ConstraintTypes.Select(ct => ct.ToDisplayString())) +
                                    (tp.HasConstructorConstraint ? "new()" : "").Trim() : ""))}" : "")))))));
        }
    }
}


//     public virtual void Generate(SourceProductionContext context, (Compilation Compilation, (AnalyzerConfigOptionsProvider AnalyzerConfigOptions, ImmutableArray<(InterfaceDeclarationSyntax, SemanticModel, ImmutableArray<AttributeData>)> Values) Values) values)
//     {
//         try
//         {
//             var (compilation, (analyzerConfigOptions, Values)) = values;
//             var interfaceAtributeDeclaration = GenerateInterfaceAtributeDeclaration;
//             var header = Header;
//             context.AddSource(GenerateInterfaceAttributeName + ".g.cs", interfaceAtributeDeclaration);
//             foreach(var (interfaceDeclaration, semanticModel, attributeData) in Values)
//             {
//                 var interfaceName = interfaceDeclaration.Identifier.Text;
//                 var interfaceNamespace = interfaceDeclaration.GetNamespace();
//                 var classToGenerateTheInterfaceFor = (Type)attributeData.First().ConstructorArguments.First().Value!;
//                 context.AddSource(interfaceName + "g.cs", $@"/* {header}
//     {classToGenerateTheInterfaceFor.Namespace}.{classToGenerateTheInterfaceFor.Name}
//     */");
//         }}
//         catch(Exception ex)
//         {
//             context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("INTERFACEGENERATOR", "Strongly Typed Resource Generator", ex.Message, "INTERFACEGENERATOR", DiagnosticSeverity.Error, true), Location.Create("StronglyTypesEmbeddedResourceGenerator.cs", new TextSpan(0, 0), new LinePositionSpan(new LinePosition(0, 0), new LinePosition(0, 0)))));
//             context.AddSource("Error.g.cs", $@"/* {ex.Source}: {ex.Message}:
// {ex.StackTrace} */");
//         }
//     }
