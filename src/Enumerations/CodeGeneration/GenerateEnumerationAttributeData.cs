// 
// GenerateEnumerationAttributeData.cs
// 
//   Created: 2022-10-31-02:53:03
//   Modified: 2022-10-31-02:53:03
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022-2023 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 
using System.Collections.Immutable;
using Microsoft.CodeAnalysis;

namespace JustinWritesCode.Enumerations.CodeGeneration;

public class GenerateEnumerationAttributeData : AttributeData
{
    protected override INamedTypeSymbol? CommonAttributeClass {get;}

    protected override IMethodSymbol? CommonAttributeConstructor {get;}

    protected override SyntaxReference? CommonApplicationSyntaxReference {get;}

    protected override ImmutableArray<TypedConstant> CommonConstructorArguments {get;}

    protected override ImmutableArray<KeyValuePair<string, TypedConstant>> CommonNamedArguments {get;}

    
}
