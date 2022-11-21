// 
// Constants.cs
// 
//   Created: 2022-11-11-04:00:23
//   Modified: 2022-11-12-11:24:45
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 


namespace JustinWritesCode.InterfaceGenerator;
using JustinWritesCode.CodeGeneration.Extensions;
public static class Constants
{
    public const string BeginCodeSentinel = "// BEGIN";

	public const string GenerateInterfaceAttributeName = "GenerateInterfaceAttribute";
    public static readonly string Header = new StreamReader(typeof(Constants).Assembly.GetManifestResourceStream("JustinWritesCode.InterfaceGenerator.Resources.Header.cs")!).ReadToEnd().TrimFromSentinel(BeginCodeSentinel);
    public static readonly string GenerateInterfaceAtributeDeclaration =
		Header + "\r\n" + 
        new StreamReader(typeof(Constants).Assembly.GetManifestResourceStream("JustinWritesCode.InterfaceGenerator.Resources.GenerateInterfaceAttribute.cs")!).ReadToEnd().TrimFromSentinel(BeginCodeSentinel);
}
