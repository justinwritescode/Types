//
// IIdentifiable.cs
//
//   Created: 2022-10-16-08:38:27
//   Modified: 2022-11-02-08:16:06
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//


namespace JustinWritesCode.Abstractions;

/// <summary>
/// Marker interface for an object or struct that has a *read-only* <c><see cref="Id">Id</see></c> property.
/// </summary>
public interface IIdentifiable
{
    object Id { get; }
}

/// <summary>
/// Marker interface for an object or struct that has a *read-only* <c><see cref="Id">Id</see></c> property of type <typeparamref name="TId"/>.
/// </summary>
public interface IIdentifiable<TId> where TId : IComparable, IEquatable<TId>
{
    TId Id { get; }
}

/// <summary>
/// Marker interface for an object or struct that has a *read/write* <c><see cref="Id">Id</see></c> property.
/// </summary>
public interface IHaveAWritableId : IIdentifiable
{
    new object Id { get; set; }
}


/// <summary>
/// Marker interface for an object or struct that has a *read/write* <c><see cref="Id">Id</see></c> property.
/// </summary>
public interface IHaveAWritableId<TId> : IIdentifiable<TId> where TId : IComparable, IEquatable<TId>
{
    new TId Id { get; set; }
}
