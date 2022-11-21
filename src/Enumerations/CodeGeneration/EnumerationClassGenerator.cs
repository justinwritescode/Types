/* 
 * EnumerationClassGenerator.cs
 * 
 *   Created: 2022-10-16-04:03:15
 *   Modified: 2022-11-11-01:59:02
 * 
 *   Author: Justin Chase <justin@justinwritescode.com>
 *   
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */ 
namespace JustinWritesCode.Enumerations.CodeGeneration;

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Linq;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using static JustinWritesCode.Enumerations.CodeGeneration.Constants;

[Generator]
public partial class EnumerationClassGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var valuesProvider = context.SyntaxProvider.CreateSyntaxProvider<(EnumDeclarationSyntax? EnumDeclarationSyntax, SemanticModel? SemanticModel)?>(
            (node, _) => node is EnumDeclarationSyntax enumDeclarationSyntax,
            (context, _) => context.Node is EnumDeclarationSyntax enumDeclarationSyntax
                ? (enumDeclarationSyntax, context.SemanticModel)
                : null).Where(x => x is not null).Collect();
        var valuesProvider2 = 
            context.AnalyzerConfigOptionsProvider.Combine(valuesProvider);
        var valuesProvider3 = 
            context.CompilationProvider.Combine(valuesProvider2);

        context.RegisterSourceOutput(valuesProvider3, Generate);
    }

    // public void Initialize(GeneratorInitializationContext context)
    // {
    //     context.RegisterForSyntaxNotifications(() => new EnumerationSyntaxReceiver());
    // }

    public virtual void Generate(SourceProductionContext context, (Compilation Compilation, (AnalyzerConfigOptionsProvider AnalyzerConfigOptions, ImmutableArray<(EnumDeclarationSyntax EnumDeclarationSyntax, SemanticModel SemanticModel)?> Values) Values) values)
    {
        // get the populated receiver 
        var enumDeclarations = values.Values.Values.Select(x => x.Value.EnumDeclarationSyntax).ToImmutableArray();

        try
        {
            var codeHeader = CodeHeader.Replace($"{AuthorName}", "JustinWritesCode")
                .Replace($"{AuthorEmail}", "justin@justinwritescode.com")
                .Replace($"{Year}", DateTime.Now.Year.ToString())
                .Replace($"{Timestamp}", DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss UTC"));

            var sb = new StringBuilder();
            foreach (var enumDeclaration in enumDeclarations)
            {
                // get the semantic model
                var semanticModel = values.Compilation.GetSemanticModel(@enumDeclaration.SyntaxTree);
                var enumSymbol = semanticModel.GetDeclaredSymbol(@enumDeclaration) as ITypeSymbol;

                var attributes = enumSymbol.GetAttributes();
                var enumerationClassNameString = enumSymbol.Name + "Enumeration";
                var enumerationClassNamespaceValue = enumSymbol.ContainingNamespace.ToDisplayString();

                // var enumerationAttributeSymbol = enumSymbol.GetAttribute(GenerateEnumerationClassAttributeName);

                 var enumerationAttributeDeclaration = @enumDeclaration.AttributeLists.SelectMany(a => a.Attributes).FirstOrDefault(x => x.Name.ToString() == GenerateEnumerationClassAttributeName || x.Name.ToString() == GenerateEnumerationClassAttributeNameWithoutAttribute);
                if (enumerationAttributeDeclaration is not null)
                {
                    var enumName = enumSymbol.Name;
                    var enumNamespace = enumSymbol.ContainingNamespace.ToDisplayString();
                    var enumerationClassNameArgument = enumerationAttributeDeclaration.ArgumentList?.Arguments.FirstOrDefault();
                    var enumerationClassNameArgumentSemanticModel = enumerationClassNameArgument != null ? values.Compilation.GetSemanticModel(enumerationClassNameArgument?.Expression?.SyntaxTree) : null;
                    var enumerationClassName = enumerationClassNameArgumentSemanticModel?.GetConstantValue(enumerationClassNameArgument?.Expression);
                    enumerationClassNameString = enumerationClassName.HasValue ? enumerationClassName.Value.ToString() : enumName + "Enumeration";
                    // enumerationClassNameString = enumSymbol.GetAttribute(GenerateEnumerationClassAttributeName).GetAttributeArgumentValueAsString(0) ?? enumName + "Enumeration";

                    
                    var enumerationClassNamespaceArgument = enumerationAttributeDeclaration.ArgumentList?.Arguments.Skip(1).FirstOrDefault();
                    var enumerationClassNamespaceArgumentSemanticModel = enumerationClassNamespaceArgument != null ? values.Compilation.GetSemanticModel(enumerationClassNamespaceArgument?.Expression?.SyntaxTree) : null;
                    var enumerationClassNamespaceString = enumerationClassNamespaceArgumentSemanticModel?.GetConstantValue(enumerationClassNamespaceArgument?.Expression);
                    enumerationClassNamespaceValue = enumerationClassNamespaceString.HasValue ? enumerationClassNamespaceString.Value.ToString() : enumNamespace;
                    // enumerationClassNamespaceValue = enumSymbol.GetAttribute(GenerateEnumerationClassAttributeName).GetAttributeArgumentValueAsString(1) ?? enumerationClassNamespaceValue;

                    context.AddSource(enumSymbol.Name + "_AttributeConstructorArgs.g.cs",
                        @$"/* {string.Join(", ", enumerationAttributeDeclaration.ArgumentList?.Arguments.Select(arg => $"{arg.ToFullString()}") ?? Array.Empty<string>())} */");
                }

                if (enumerationAttributeDeclaration != null)
                {
                    var enumType = enumSymbol.Name;
                    var enumNamespace = GetNamespace(enumSymbol.ContainingNamespace);
                    var enumerationClassName = enumerationClassNameString;//enumerationAttributeDeclaration.ConstructorArguments.FirstOrDefault().Value?.ToString() ?? enumType + "Enumeration";
                    var @namespace = enumerationClassNamespaceValue;//enumerationAttributeDeclaration.ConstructorArguments.Skip(1).FirstOrDefault().Value?.ToString() ?? enumNamespace;

                    var enumFields = enumSymbol.GetMembers().Where(member => member.Kind == SymbolKind.Field).OfType<IFieldSymbol>();
                    var enumClassDeclaration =
                        EnumerationClassDeclaration
                        .Replace($"{EnumerationClassName}", enumerationClassName)
                        .Replace($"{EnumNamespace}", enumNamespace)
                        .Replace($"{Namespace}", @namespace)
                        .Replace($"{EnumType}", enumType)
                        .Replace($"{Values}", string.Join(", ", enumFields.Select(f => $"{enumerationClassName}.{f.Name}.Instance")))
                        .Replace($"{Fields}",
                            string.Join(" ", enumFields.Select(f =>
                                EnumerationFieldDeclaration
                                .Replace($" {EnumerationClassName}", $" {enumerationClassName}")
                                .Replace($" {FieldName}", $" {f.Name}")
                                .Replace($" {Name}", $" \"{f.Name}\"")
                                .Replace($" {DisplayName}", $" \"{(f.GetAttributes().FirstOrDefault(a => a.AttributeClass.Name == DisplayAttribute)?.NamedArguments.FirstOrDefault(na => na.Key == "Name").Value.Value?.ToString() ?? f.Name).Escape()}\"")
                                .Replace($" {ShortName}", $" \"{f.GetAttributes().FirstOrDefault(a => a.AttributeClass.Name == DisplayAttribute)?.NamedArguments.FirstOrDefault(na => na.Key == "ShortName").Value.Value?.ToString() ?? f.Name}\"")
                                .Replace($" {Order}", $" {f.GetAttributes().FirstOrDefault(a => a.AttributeClass.Name == DisplayAttribute)?.NamedArguments.FirstOrDefault(na => na.Key == "Order").Value.Value?.ToString() ?? f.ConstantValue.ToString()}")
                                .Replace($" {GroupName}", $" \"{f.GetAttributes().FirstOrDefault(a => a.AttributeClass.Name == DisplayAttribute)?.NamedArguments.FirstOrDefault(na => na.Key == nameof(GroupName)).Value.Value?.ToString() ?? JustinWritesCode.Enumerations.Enumeration.NoGroup}\"")
                                .Replace($" {Id}", $" {(f.ConstantValue.ToString())}")
                                .Replace($" {Name}", $" \"{f.Name.ToString()}\""))));
                    var enumClassFile = codeHeader + enumClassDeclaration;

                    context.AddSource($"{enumerationClassName}.g.cs", codeHeader.Replace($"{Filename}", $"{enumerationClassName}.g.cs") + "\n" + enumClassFile);
                }
            }

            context.AddSource(GenerateEnumerationClassAttributeName + ".g.cs", codeHeader.Replace($"{Filename}", $"{GenerateEnumerationClassAttributeName}.g.cs") + "\n" + GenerateEnumerationClassAttributeDeclaration);
        }
        catch (Exception ex)
        {
            context.AddSource("Error.g.cs", @$"/* 
Exception: {ex.Message}
{ex.StackTrace} 
*/");
        }
    }

    private string GetNamespace(INamespaceSymbol ns, string? nsSoFar = null)
    {
        if (ns.IsGlobalNamespace) return nsSoFar ?? "global::";
        else return GetNamespace(ns.ContainingNamespace, ns.Name + (nsSoFar is null ? "" : "." + nsSoFar));
    }

    private (ITypeSymbol @Enum, IEnumerable<AttributeData> Attributes) GetTypeSymbols(GeneratorSyntaxContext context, CancellationToken cancellationToken)
    {
        var decl = (EnumDeclarationSyntax)context.Node;

        var attributes = context.SemanticModel.GetDeclaredSymbol(decl).GetAttributes();//.AttributeLists.SelectMany(al => al.Attributes).Select(a => context.SemanticModel.GetSymbolInfo(a, cancellationToken).Symbol).OfType<IMethodSymbol>().Select(m => m.GetAttributes().FirstOrDefault()).Where(a => a != null);

        if (context.SemanticModel.GetDeclaredSymbol(decl, cancellationToken) is ITypeSymbol typeSymbol)
        {
            return (typeSymbol, attributes);
        }

        return default;
    }

    private (ITypeSymbol @Enum, IEnumerable<AttributeData> Attributes) GetTypeSymbols(GeneratorAttributeSyntaxContext context, CancellationToken cancellationToken)
    {
        var decl = (EnumDeclarationSyntax)context.TargetNode;
        var attributes = context.Attributes;

        if (context.SemanticModel.GetDeclaredSymbol(decl, cancellationToken) is ITypeSymbol typeSymbol)
        {
            return (typeSymbol, attributes);
        }

        return default;
    }
}
