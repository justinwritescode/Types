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
using JustinWritesCode.CodeGeneration.Logging;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using static JustinWritesCode.CodeGeneration.Constants;
using static JustinWritesCode.Enumerations.CodeGeneration.Constants;
/**
 * <summary>
 *     EnumerationClassGenerator is a Roslyn source generator that generates
 *     strongly-typed enumeration <see langword="record" /> <see langword="struct" />s from an <see langword="enum" /> declarations.
 * </summary>
 */
[Generator]
public partial class EnumerationTypeGenerator : IIncrementalGenerator
{
    private static string LogPath => Format("{0}-{1}.cs", Now, Guid.NewGuid().ToString().Substring(0, 4));

    public SourceGeneratorLogger<EnumerationTypeGenerator>? Logger { get; private set; }
    public virtual void Initialize(IncrementalGeneratorInitializationContext context)
    {
        if (!Debugger.IsAttached)
        {
            _ = Debugger.Launch();
        }

        Logger = new((hint, text) => context.RegisterPostInitializationOutput(context => context.AddSource(hint, text)));

        try
        {
            var initialValuesProvider =
                context.CompilationProvider
                .Combine(context.AnalyzerConfigOptionsProvider);


            var isEnumDeclarationSyntaxPredicate = (SyntaxNode node, CancellationToken _) => node is EnumDeclarationSyntax enumDeclarationSyntax;

            Logger.LogInformation("Registering source output for GenerateEnumerationRecordClassAttribute (\"GenerateEnumerationRecordClass\")...");
            var valuesProvider = initialValuesProvider.Combine(context.SyntaxProvider.ForAttributeWithMetadataName(GenerateEnumerationRecordClassAttribute, isEnumDeclarationSyntaxPredicate, Transform(TypeToGenerate.RecordClass)).Collect());
            context.RegisterSourceOutput(valuesProvider, Generate);

            Logger.LogInformation("Registering source output for GenerateEnumerationClassAttribute (\"GenerateEnumerationClassAttribute\")...");
            valuesProvider = initialValuesProvider.Combine(context.SyntaxProvider.ForAttributeWithMetadataName(GenerateEnumerationClassAttribute, isEnumDeclarationSyntaxPredicate, Transform(TypeToGenerate.Class)).Collect());
            context.RegisterSourceOutput(valuesProvider, Generate);

            Logger.LogInformation("Registering source output for GenerateEnumerationRecordStructAttribute (\"GenerateEnumerationRecordStructAttribute\")...");
            valuesProvider = initialValuesProvider.Combine(context.SyntaxProvider.ForAttributeWithMetadataName(GenerateEnumerationRecordStructAttribute, isEnumDeclarationSyntaxPredicate, Transform(TypeToGenerate.RecordStruct)).Collect());
            context.RegisterSourceOutput(valuesProvider, Generate);

            Logger.LogInformation("Registering source output for GenerateEnumerationStructAttribute (\"GenerateEnumerationStructAttribute\")...");
            valuesProvider = initialValuesProvider.Combine(context.SyntaxProvider.ForAttributeWithMetadataName(GenerateEnumerationStructAttribute, isEnumDeclarationSyntaxPredicate, Transform(TypeToGenerate.Struct)).Collect());
            context.RegisterSourceOutput(valuesProvider, Generate);
            // throw new Exception("Fuck your mom!");

            context.RegisterPostInitializationOutput(context =>
            {
                context.AddSource(GenerateEnumerationTypeAttributesName + ".g.cs", MinimalCodeHeaderTemplate.Template.Render(new { Filename = $"{GenerateEnumerationTypeAttributesName}.g.cs", Timestamp = UtcNow.ToString("yyyy-MM-dd HH:mm:ss") }) + Environment.NewLine + GenerateEnumerationTypeAttributesDeclaration);
                context.AddSource($"{ nameof(TypeToGenerate)}.g.cs", MinimalCodeHeaderTemplate.Template.Render(new { Filename = $"{nameof(TypeToGenerate)}.g.cs", Timestamp = UtcNow.ToString("yyyy-MM-dd HH:mm:ss") }) + Environment.NewLine + TypeToGenerateEnumDeclaration);
            });
        }
        catch (Exception ex)
        {
            var message = new StringBuilder();
            do
            {
                var stackTrace = new StackTrace(ex, true);
                _ = message.AppendLine(
                $""""
                /*
                Exception: {ex.Message}
                {ex.StackTrace}

                {stackTrace.GetFrames().Select(frame => $""""
                    {frame.GetMethod().DeclaringType.FullName}.{frame.GetMethod().Name}
                    {frame.GetFileName()}:{frame.GetFileLineNumber()}
                """" + Environment.NewLine).Aggregate((a, b) => a + b)}

                */
                """"
                );
            } while ((ex = ex.InnerException) != null);
            context.RegisterPostInitializationOutput(context => context.AddSource("Exception.g.cs", message.ToString()));
        }
        finally { Logger.Dispose(); }
    }

    internal static Func<GeneratorAttributeSyntaxContext, CancellationToken, EnumDeclaration> Transform(TypeToGenerate typeToGenerate)
    {
        return (GeneratorAttributeSyntaxContext context, CancellationToken _) =>
        {
            var enumDeclarationSyntax = context.TargetNode as EnumDeclarationSyntax;
            var semanticModel = context.SemanticModel;
            var enumSymbol = semanticModel.GetDeclaredSymbol(enumDeclarationSyntax, _) as ITypeSymbol;
            var enumName = enumSymbol.Name;
            var enumNamespace = enumSymbol?.ContainingNamespace?.ToDisplayString();
            var enumerationAttributeDeclaration = context.Attributes.GetGenerateEnumerationTypeAttribute();// @enumDeclarationSyntax.AttributeLists.SelectMany(a => a.Attributes).FirstOrDefault(a => GenerateEnumerationAttributeTypeNames.Contains(a.Name.ToString()));
            var enumerationClassNameArgument = enumerationAttributeDeclaration?.ConstructorArguments.FirstOrDefault();
            var enumerationClassName = enumerationClassNameArgument?.Value?.ToString() ??
                            (enumName.EndsWith("Enum") ?
                            enumName.Replace("Enum", "") :
                            enumName + "Enumeration");
            var enumerationNamespaceNameArgument = enumerationAttributeDeclaration?.ConstructorArguments.Skip(1).FirstOrDefault(); //enumerationNamespaceDeclaration?.ArgumentList?.Arguments.Skip(1).FirstOrDefault();
            var enumerationNamespace = enumerationNamespaceNameArgument?.Value?.ToString() ?? enumNamespace;
            return new (enumDeclarationSyntax, semanticModel, enumerationClassName, enumerationNamespace, typeToGenerate);
        };
    }

    public static readonly CodeTemplate EnumerationClassTemplate = new(EnumerationClassDeclaration);
    public static readonly CodeTemplate EnumerationFieldDeclarationTemplate = new(EnumerationFieldDeclaration);
    internal void Generate(SourceProductionContext context, ((Compilation Compilation, AnalyzerConfigOptionsProvider AnalyzerConfigOptions) CompilationAndConfig, ImmutableArray<EnumDeclaration> Values) values)
    {
        Logger = new(context.AddSource);
        Logger.LogInformation("Generating source output...");
        // get the populated receiver
        var (Compilation, AnalyzerConfigOptions, EnumDeclarations) =
            (values.CompilationAndConfig.Compilation, values.CompilationAndConfig.AnalyzerConfigOptions, values.Values);// valu

        try
        {
            for(var i = 0; i < EnumDeclarations.Length; i++)
            {
                var enumDeclaration = EnumDeclarations[i];
                // get the semantic model
                var semanticModel = @enumDeclaration.SemanticModel;
                var enumSymbol = semanticModel.GetDeclaredSymbol(@enumDeclaration.SyntaxTree) as ITypeSymbol;

                var attributes = enumSymbol.GetAttributes();
                var enumerationNamespace = enumDeclaration.EnumerationNamespace;
                var enumNamespace = enumSymbol?.ContainingNamespace?.ToDisplayString();
                var enumName = enumSymbol.Name;
                var enumerationTypeName = enumDeclaration.EnumerationClassName ??=
                        enumName.EndsWith("Enum") ?
                        enumName.Replace("Enum", "") :
                        enumName + "Enumeration";

                var enumerationAttributeDeclaration = @enumDeclaration.SyntaxTree.AttributeLists.SelectMany(a => a.Attributes).FirstOrDefault(x => x.Name.ToString() == GenerateEnumerationClassAttributeName || x.Name.ToString() == GenerateEnumerationClassAttributeNameWithoutAttribute);

                var additionalFields = new Dictionary<string, object>();
                var enumerationTypeAttributeDeclaration = enumDeclaration.EnumerationTypeAttributeDeclaration = @enumDeclaration.SyntaxTree.AttributeLists.SelectMany(a => a.Attributes).FirstOrDefault(x => GenerateEnumerationTypeAttributesName.Contains(x.Name.ToString()));
                additionalFields[$"enumerationTypeAttributeDeclaration"] = enumerationTypeAttributeDeclaration;
                if (enumerationTypeAttributeDeclaration is not null)
                {
                    var enumerationClassNameArgument = enumerationTypeAttributeDeclaration.ArgumentList?.Arguments.FirstOrDefault();
                    additionalFields["enumerationClassNameArgument"] = enumerationClassNameArgument?.Expression;
                    var enumerationClassNameArgumentSemanticModel = enumerationClassNameArgument != null ? Compilation.GetSemanticModel(enumerationClassNameArgument?.Expression?.SyntaxTree) : null;
                    var enumerationClassNameArgumentValue = enumerationClassNameArgumentSemanticModel?.GetConstantValue(enumerationClassNameArgument?.Expression);
                    enumDeclaration.EnumerationClassName = enumerationTypeName = enumerationClassNameArgumentValue.HasValue ? enumerationClassNameArgumentValue.Value.ToString() : enumerationTypeName;
                    additionalFields["enumDeclaration.EnumerationClassName"] = enumDeclaration.EnumerationClassName;

                    var enumerationClassNamespaceArgument = enumerationTypeAttributeDeclaration.ArgumentList?.Arguments.Skip(1).FirstOrDefault();
                    additionalFields["enumerationClassNamespaceArgument"] = enumerationClassNamespaceArgument?.Expression;
                    var enumerationClassNamespaceArgumentSemanticModel = enumerationClassNamespaceArgument != null ? Compilation.GetSemanticModel(enumerationClassNamespaceArgument?.Expression?.SyntaxTree) : null;
                    var enumerationCTypeNamespaceArgumentValue = enumerationClassNamespaceArgumentSemanticModel?.GetConstantValue(enumerationClassNamespaceArgument?.Expression);
                    enumDeclaration.EnumerationNamespace = enumerationNamespace = enumerationCTypeNamespaceArgumentValue.HasValue ? enumerationCTypeNamespaceArgumentValue.Value.ToString() : enumNamespace;
                    additionalFields["enumDeclaration.EnumerationNamespace"] = enumDeclaration.EnumerationNamespace;

                    context.AddSource(enumSymbol.Name + "_AttributeConstructorArgs.g.cs",
                        @$"/* {Join(", ", enumerationTypeAttributeDeclaration.ArgumentList?.Arguments.Select(arg => $"{arg.ToFullString()}") ?? Empty<string>())} */");
                }

                var enumType = enumSymbol.Name;
                var @namespace = enumerationNamespace;

                additionalFields["enumType"] = enumType;
                additionalFields["@namespace"] = @namespace;
                additionalFields["enumSymbol.Name"] = enumSymbol.Name;
                additionalFields["enumDeclaration.TypeToGenerate"] = enumDeclaration.TypeToGenerate;

                Logger.LogInformation(
                    """"
                    Enumeration Data
                    """", additionalFields: additionalFields);

                var enumFields = enumSymbol.GetMembers().Where(member => member.Kind == SymbolKind.Field).OfType<IFieldSymbol>();
                var enumClassDeclaration =
                    EnumerationClassTemplate.Template.Render(new EnumDeclarationParams(
                            enumerationTypeName,
                            enumNamespace,
                            @namespace,
                            enumType,
                            nameof(Int32),
                            enumSymbol.Name,
                            enumSymbol.GetDocumentationCommentXml(),
                            enumDeclaration.TypeToGenerate == TypeToGenerate.RecordStruct || enumDeclaration.TypeToGenerate == TypeToGenerate.Struct ? "readonly" : "",
                            enumDeclaration.TypeToGenerate,
                            Join(", ", enumFields.Select(f => $"{enumerationTypeName}.{f.Name}.Instance")),
                            Join(" ", enumFields.Select(f =>
                            EnumerationFieldDeclarationTemplate.Template.Render(new FieldDeclarationParams(
                                    f.Name,
                                    enumerationTypeName,
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
                    Filename = $"{enumerationTypeName}.g.cs",
                    Timestamp = UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
                });
                var enumClassFile = enumCodeHeader + enumClassDeclaration;

                context.AddSource($"{enumerationTypeName}.g.cs", enumCodeHeader + "\n" + enumClassFile);
            }
        }
        catch (Exception ex)
        {
            Logger.LogError(ex);
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
            context.AddSource(Format("Exception-{1}{0}.g.cs", UtcNow.ToString("hh-mm-ss"), Guid.NewGuid().ToString().Substring(0, 2)), message.ToString());
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
