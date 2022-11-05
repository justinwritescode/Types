//
//  IHaveAUri.cs
//
//  Authors:
//       Justin Chase <justin@justinwritescode.com>
//
//  Copyright ©️ 2022 2022 Justin Chase
//

namespace JustinWritesCode.Abstractions;

public interface IHaveAUri
{
    Uri Uri { get; }
}

public interface IHaveWritableAUri : IHaveAUri
{
    new Uri Uri { get; set; }
}
