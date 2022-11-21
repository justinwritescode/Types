// 
// InterfaceGenerator.cs
// 
//   Created: 2022-11-11-03:54:47
//   Modified: 2022-11-12-11:16:54
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 


namespace JustinWritesCode.InterfaceGenerator;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Linq;
using Microsoft.CodeAnalysis.Diagnostics;
using JustinWritesCode.CodeGeneration.Extensions;
using System.Collections.Immutable;

[Generator]
public partial class EnumerationClassGenerator : IIncrementalGenerator
{
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var valuesProvider = context.SyntaxProvider.ForAttributeWithMetadataName(GenerateInterfaceAttributeName, (node, _) => node is InterfaceDeclarationSyntax interfaceDeclarationSyntax ? true : false, (context, _) => (context.TargetNode as InterfaceDeclarationSyntax, context.SemanticModel, context.Attributes)).Collect();
        var valuesProvider2 =
            context.AnalyzerConfigOptionsProvider.Combine(valuesProvider);
        var valuesProvider3 =
            context.CompilationProvider.Combine(valuesProvider2);

        context.RegisterSourceOutput(valuesProvider3, Generate);
	}

	public virtual void Generate(SourceProductionContext context, (Compilation Compilation, (AnalyzerConfigOptionsProvider AnalyzerConfigOptions, ImmutableArray<(InterfaceDeclarationSyntax, SemanticModel, ImmutableArray<AttributeData>)> Values) Values) values)
	{
		try
		{
			var (compilation, (analyzerConfigOptions, Values)) = values;
			var interfaceAtributeDeclaration = GenerateInterfaceAtributeDeclaration;
			var header = Header;
			context.AddSource(GenerateInterfaceAttributeName + ".g.cs", interfaceAtributeDeclaration);
			foreach(var (interfaceDeclaration, semanticModel, attributeData) in Values)
			{
				var interfaceName = interfaceDeclaration.Identifier.Text;
				var interfaceNamespace = interfaceDeclaration.GetNamespace();
				var classToGenerateTheInterfaceFor = (Type)attributeData.First().ConstructorArguments.First().Value!;
				context.AddSource(interfaceName + "g.cs", $@"/* {header}
	{classToGenerateTheInterfaceFor.Namespace}.{classToGenerateTheInterfaceFor.Name} 
	*/");
		}}
		catch(Exception ex)
		{
			context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor("INTERFACEGENERATOR", "Strongly Typed Resource Generator", ex.Message, "INTERFACEGENERATOR", DiagnosticSeverity.Error, true), Location.Create("StronglyTypesEmbeddedResourceGenerator.cs", new TextSpan(0, 0), new LinePositionSpan(new LinePosition(0, 0), new LinePosition(0, 0)))));
			context.AddSource("Error.g.cs", $@"/* {ex.Source}: {ex.Message}:
{ex.StackTrace} */");
		}
	}
}
