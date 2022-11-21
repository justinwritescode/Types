// 
// CodeHeader.cs
// 
//   Created: 2022-10-16-12:31:41
//   Modified: 2022-10-30-02:48:46
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Enumerations.CodeGeneration;

public static partial class Constants
{
    public static readonly string CodeHeader = 
        new StreamReader(typeof(Constants).Assembly.GetManifestResourceStream("JustinWritesCode.Enumerations.CodeGeneration.Resources.CodeHeader.cs")).ReadToEnd()
        .TrimFromSentinel();
}
