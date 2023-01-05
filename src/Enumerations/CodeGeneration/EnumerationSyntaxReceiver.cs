// 
// EnumerationSyntaxReceiver.cs
// 
//   Created: 2022-10-31-02:38:51
//   Modified: 2022-10-31-02:38:51
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022-2023 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace JustinWritesCode.Enumerations.CodeGeneration;
public class EnumerationSyntaxReceiver : ISyntaxReceiver
{
    public List<EnumDeclarationSyntax> EnumDeclarations { get; } = new();

    public void OnVisitSyntaxNode(SyntaxNode syntaxNode)
    {
        if (syntaxNode is EnumDeclarationSyntax enumDeclarationSyntax)
        {
            EnumDeclarations.Add(enumDeclarationSyntax);
        }
    }
}
