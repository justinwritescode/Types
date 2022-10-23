//
//  IHaveAnId.cs
//
//  Authors:
//       Justin Chase <justin@justinwritescode.com>
//
//  Copyright ©️ 2022 Justin Chase
//

namespace JustinWritesCode.Abstractions;

/// <summary>
/// Marker interface for an object or struct that has a *read-only* <c><see cref="Id">Id</see></c> property.
/// </summary>
public interface IHaveAnId
{
    object Id { get; }
}

/// <summary>
/// Marker interface for an object or struct that has a *read-only* <c><see cref="Id">Id</see></c> property of type <typeparamref name="TId"/>.
/// </summary>
public interface IHaveAnId<TId> where TId : IComparable, IEquatable<TId>
{
    TId Id { get; }
}

/// <summary>
/// Marker interface for an object or struct that has a *read/write* <c><see cref="Id">Id</see></c> property.
/// </summary>
public interface IHaveAWritableId : IHaveAnId
{
    new object Id { get; set; }
}


/// <summary>
/// Marker interface for an object or struct that has a *read/write* <c><see cref="Id">Id</see></c> property.
/// </summary>
public interface IHaveAWritableId<TId> : IHaveAnId<TId> where TId : IComparable, IEquatable<TId>
{
    new TId Id { get; set; }
}
