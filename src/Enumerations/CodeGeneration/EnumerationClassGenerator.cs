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

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using JustinWritesCode.CodeGeneration;
using JustinWritesCode.Enumerations.CodeGeneration;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static JustinWritesCode.CodeGeneration.Constants;
using static JustinWritesCode.Enumerations.CodeGeneration.Constants;
/**
 * <summary>
 *     EnumerationClassGenerator is a Roslyn source generator that generates
 *     strongly-typed enumeration <see langword="record" /> <see langword="struct" />s from <see langword="enum" /> declarations.
 * </summary>
 */
[Generator]
public partial class EnumerationClassGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        try
        {
            var initialValuesProvider =
                context.CompilationProvider
                .Combine(context.AnalyzerConfigOptionsProvider);

            var isEnumDeclarationSyntaxPredicate = (SyntaxNode node, CancellationToken _) => node is EnumDeclarationSyntax enumDeclarationSyntax;

            var valuesProvider = initialValuesProvider.Combine(context.SyntaxProvider.ForAttributeWithMetadataName(GenerateEnumerationRecordClassAttribute, isEnumDeclarationSyntaxPredicate, Transform).Collect());
            context.RegisterSourceOutput(valuesProvider, Generate);

            valuesProvider = initialValuesProvider.Combine(context.SyntaxProvider.ForAttributeWithMetadataName(GenerateEnumerationClassAttribute, isEnumDeclarationSyntaxPredicate, Transform).Collect());
            context.RegisterSourceOutput(valuesProvider, Generate);

            valuesProvider = initialValuesProvider.Combine(context.SyntaxProvider.ForAttributeWithMetadataName(GenerateEnumerationRecordStructAttribute, isEnumDeclarationSyntaxPredicate, Transform).Collect());
            context.RegisterSourceOutput(valuesProvider, Generate);

            valuesProvider = initialValuesProvider.Combine(context.SyntaxProvider.ForAttributeWithMetadataName(GenerateEnumerationStructAttribute, isEnumDeclarationSyntaxPredicate, Transform).Collect());
            context.RegisterSourceOutput(valuesProvider, Generate);

            context.RegisterPostInitializationOutput(context =>
            {
                var codeHeader = MinimalCodeHeaderTemplate.Template.Render(new
                {
                    Filename = $"{GenerateEnumerationClassAttributeName}.g.cs",
                    Timestamp = UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                });

                context.AddSource(GenerateEnumerationTypeAttributesName + ".g.cs", codeHeader.Replace($"{Filename}", $"{GenerateEnumerationTypeAttributesName}.g.cs") + Environment.NewLine + GenerateEnumerationTypeAttributesDeclaration);
                context.AddSource("TypeToGenerate.g.cs", MinimalCodeHeaderTemplate.Template.Render(new { Filename = "TypeToGenerate.g.cs", Timestamp = UtcNow.ToString("yyyy-MM-dd HH:mm:ss") }) + Environment.NewLine + TypeToGenerateEnumDeclaration);
            });
        }
        catch (Exception ex)
        {
            var message = new StringBuilder();
            do
            {
                message.AppendLine(
                $""""
                /*
                Exception: {ex.Message}
                {ex.StackTrace}
                */
                """"
                );
            } while ((ex = ex.InnerException) != null);
            context.RegisterPostInitializationOutput(context => context.AddSource("Exception.g.cs", message.ToString()));
        }
    }

    internal static EnumDeclaration Transform(GeneratorAttributeSyntaxContext context, CancellationToken _)
    {
        var enumDeclarationSyntax = context.TargetNode as EnumDeclarationSyntax;
        var semanticModel = context.SemanticModel;
        var enumSymbol = semanticModel.GetDeclaredSymbol(enumDeclarationSyntax, _) as ITypeSymbol;
        var enumName = enumSymbol.Name;
        var enumNamespace = enumSymbol.ContainingNamespace.ToDisplayString();
        var enumerationAttributeDeclaration = context.Attributes.GetGenerateEnumerationTypeAttribute();// @enumDeclarationSyntax.AttributeLists.SelectMany(a => a.Attributes).FirstOrDefault(a => GenerateEnumerationAttributeTypeNames.Contains(a.Name.ToString()));
        var enumerationClassNameArgument = enumerationAttributeDeclaration?.ConstructorArguments.FirstOrDefault();
        var enumerationClassName = enumerationClassNameArgument?.Value?.ToString() ?? enumName + "Enumeration";
        var enumerationNamespaceNameArgument = enumerationAttributeDeclaration?.ConstructorArguments.Skip(1).FirstOrDefault(); //enumerationNamespaceDeclaration?.ArgumentList?.Arguments.Skip(1).FirstOrDefault();
        var enumerationNamespace = enumerationNamespaceNameArgument?.Value?.ToString() ?? enumNamespace;
        return new (enumDeclarationSyntax, semanticModel, enumerationClassName, enumerationNamespace);
    }

    public static readonly CodeTemplate EnumerationClassTemplate = new(EnumerationClassDeclaration);
    public static readonly CodeTemplate EnumerationFieldDeclarationTemplate = new(EnumerationFieldDeclaration);
    internal static void Generate(SourceProductionContext context, ((Compilation Compilation, AnalyzerConfigOptionsProvider AnalyzerConfigOptions) CompilationAndConfig, ImmutableArray<EnumDeclaration> Values) values)
    {
        // get the populated receiver
        var (Compilation, AnalyzerConfigOptions, EnumDeclarations) =
            (values.CompilationAndConfig.Compilation, values.CompilationAndConfig.AnalyzerConfigOptions, values.Values);// valu

        try
        {
            var sb = new StringBuilder();
            for(var i = 0; i < EnumDeclarations.Length; i++)
            {
                var enumDeclaration = EnumDeclarations[i];
                // get the semantic model
                var semanticModel = @enumDeclaration.SemanticModel;
                var enumSymbol = semanticModel.GetDeclaredSymbol(@enumDeclaration.SyntaxTree) as ITypeSymbol;

                var attributes = enumSymbol.GetAttributes();
                var enumerationNamespace = enumDeclaration.EnumerationNamespace;
                var enumNamespace = enumSymbol.ContainingNamespace.ToDisplayString();
                var enumName = enumSymbol.Name;
                var enumerationClassName = enumDeclaration.EnumerationClassName ??=
                        enumName.EndsWith("Enum") ?
                        enumName.Replace("Enum", "") :
                        enumName + "Enumeration";

                var enumerationTypeAttributeData = enumSymbol.GetGenerateEnumerationTypeAttribute();

                var enumerationTypeAttributeDeclaration = enumDeclaration.EnumerationTypeAttributeDeclaration = @enumDeclaration.SyntaxTree.AttributeLists.SelectMany(a => a.Attributes).FirstOrDefault(x => GenerateEnumerationTypeAttributesName.Contains(x.Name.ToString()));
                if (enumerationTypeAttributeDeclaration is not null)
                {
                    var enumerationClassNameArgument = enumerationTypeAttributeDeclaration.ArgumentList?.Arguments.FirstOrDefault();
                    var enumerationClassNameArgumentSemanticModel = enumerationClassNameArgument != null ? Compilation.GetSemanticModel(enumerationClassNameArgument?.Expression?.SyntaxTree) : null;
                    var enumerationClassNameArgumentValue = enumerationClassNameArgumentSemanticModel?.GetConstantValue(enumerationClassNameArgument?.Expression);
                    enumDeclaration.EnumerationClassName = enumerationClassName = enumerationClassNameArgumentValue.HasValue ? enumerationClassNameArgumentValue.Value.ToString() : enumerationClassName;

                    var enumerationClassNamespaceArgument = enumerationTypeAttributeDeclaration.ArgumentList?.Arguments.Skip(1).FirstOrDefault();
                    var enumerationClassNamespaceArgumentSemanticModel = enumerationClassNamespaceArgument != null ? Compilation.GetSemanticModel(enumerationClassNamespaceArgument?.Expression?.SyntaxTree) : null;
                    var enumerationCTypeNamespaceArgumentValue = enumerationClassNamespaceArgumentSemanticModel?.GetConstantValue(enumerationClassNamespaceArgument?.Expression);
                    enumDeclaration.EnumerationNamespace = enumerationNamespace = enumerationCTypeNamespaceArgumentValue.HasValue ? enumerationCTypeNamespaceArgumentValue.Value.ToString() : enumNamespace;

                    context.AddSource(enumSymbol.Name + "_AttributeConstructorArgs.g.cs",
                        @$"/* {Join(", ", enumerationTypeAttributeDeclaration.ArgumentList?.Arguments.Select(arg => $"{arg.ToFullString()}") ?? Empty<string>())} */");
                }

                var enumType = enumSymbol.Name;
                var @namespace = enumerationNamespace;

                WriteLine("enumType: {0}", enumType);
                WriteLine("namespace: {0}", @namespace);

                var enumFields = enumSymbol.GetMembers().Where(member => member.Kind == SymbolKind.Field).OfType<IFieldSymbol>();
                var enumClassDeclaration =
                    EnumerationClassTemplate.Template.Render(new EnumDeclarationParams(
                            enumerationClassName,
                            enumNamespace,
                            @namespace,
                            enumType,
                            nameof(Int32),
                            enumSymbol.Name,
                            enumSymbol.GetDocumentationCommentXml(),
                            enumDeclaration.TypeToGenerate,
                            Join(", ", enumFields.Select(f => $"{enumerationClassName}.{f.Name}.Instance")),
                            Join(" ", enumFields.Select(f =>
                            EnumerationFieldDeclarationTemplate.Template.Render(new FieldDeclarationParams(
                                    f.Name,
                                    enumerationClassName,
                                    enumNamespace,
                                    f.GetAttributes().FirstOrDefault(a => a.AttributeClass.Name == DisplayAttribute)?.NamedArguments.FirstOrDefault(na => na.Key == "Name").Value.Value?.ToString() ?? f.Name,
                                    f.GetAttributes().FirstOrDefault(a => a.AttributeClass.Name == DisplayAttribute)?.NamedArguments.FirstOrDefault(na => na.Key == "ShortName").Value.Value?.ToString() ?? f.Name,
                                    f.GetAttributes().FirstOrDefault(a => a.AttributeClass.Name == DisplayAttribute)?.NamedArguments.FirstOrDefault(na => na.Key == "Order").Value.Value?.ToString() ?? "0",
                                    f.GetAttributes().FirstOrDefault(a => a.AttributeClass.Name == DisplayAttribute)?.NamedArguments.FirstOrDefault(na => na.Key == "GroupName").Value.Value?.ToString() ?? "Default",
                                    f.ConstantValue.ToString(),
                                    @namespace,
                                    enumType,
                                    f.Name,
                                    f.ConstantValue,
                                    nameof(Int32),
                                    f.Type.Name,
                                    f.GetDocumentationCommentXml()
                            ))
                        ))
                    ));
                var enumCodeHeader = MinimalCodeHeaderTemplate.Template.Render(new
                {
                    Filename = $"{enumerationClassName}.g.cs",
                    Timestamp = UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                });
                var enumClassFile = enumCodeHeader + enumClassDeclaration;

                context.AddSource($"{enumerationClassName}.g.cs", enumCodeHeader.Replace($"{Filename}", $"{enumerationClassName}.g.cs") + "\n" + enumClassFile);
            }
        }
        catch (Exception ex)
        {
            var message = new StringBuilder();
            do
            {
            message.AppendLine(
            $""""
            /*
            Exception: {ex.Message}
            {ex.StackTrace}
            */
            """"
            );
            } while ((ex = ex.InnerException) != null);
            context.AddSource($"Exception{Guid.NewGuid()}.g.cs", message.ToString());
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

        var attributes = context.SemanticModel.GetDeclaredSymbol(decl, cancellationToken).GetAttributes();

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
