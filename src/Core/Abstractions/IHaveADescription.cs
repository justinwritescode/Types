//
//  IHaveAUri.cs
//
//  Authors:
//       Justin Chase <justin@justinwritescode.com>
//
//  Copyright ©️ 2022 2022 Justin Chase
//

namespace JustinWritesCode.Abstractions;

/// <summary>
/// Marker interface for an object or struct that has a *read-only* <c><see cref="Description">Description</see></c> property.
/// </summary>
public interface IHaveADescription
{
    /// <summary>
    /// The thing's description
    /// </summary>
    string Description { get; }
}

/// <summary>
/// Marker interface for an object or struct that has a *read/write* <c><see cref="Description">Description</see></c> property.
/// </summary>
public interface IHaveAWritableDescription : IHaveADescription
{
    new string Description { get; set; }
}


//public interface IHaveAReadWriteDescription : IHaveADescription, IHaveAWritableDescription { }
