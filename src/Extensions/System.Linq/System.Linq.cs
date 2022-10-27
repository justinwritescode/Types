//
//  System.Linq.cs
//
//  Authors:
//       Justin Chase <justin@thebackroom.app>
//       &
//       Municipal Drew <drew@wheatleythecat.com>
//
//  Copyright ©️ 2022 2022 Justin Chase
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System.Collections.Generic;

namespace System.Linq;

public static class JustinsEnumerableExtensions
{
    /// <summary>
    /// Determines if the <see cref="IEnumerable{T}"/> is null or empty.
    /// </summary>
    /// <param name="e">The <see cref="IEnumerable{T}"/>  to check</param>
    /// <typeparam name="T">The type of elements in the <see cref="IEnumerable{T}"/> </typeparam>
    /// <returns><c>TRUE</c> if <paramref cref="e" /> is <c>NULL</c> or empty, <c>FALSE</c> otherwise.</returns>
    public static bool IsNullOrEmpty<T>(this IEnumerable<T> e)
        => e == null || !e.Any();

    /// <summary>
    /// Performs the specified action on each element of the <see cref="IEnumerable{T}"/>.
    /// </summary>
    /// <param name="e">The <see cref="IEnumerable{T}"/> to perform the action on.</param>
    /// <param name="foreach">The action to perform on each element of the <see cref="IEnumerable{T}"/>.</param>
    public static void ForEach<T>(this IEnumerable<T> e, Action<T> @foreach)
    {
        foreach (var item in e)
            @foreach(item);
    }

    /// <summary>
    /// Adds the specified elements to the <see cref="ICollection{T}"/>.
    /// </summary>
    /// <param name="collection">The <see cref="ICollection{T}"/> to add the elements to.</param>
    /// <param name="thingsToAdd">The elements to add to the <see cref="ICollection{T}"/>.</param>
    /// <typeparam name="T">The type of elements in the <see cref="ICollection{T}"/>.</typeparam>
    /// <typeparam name="TCollection">The type of the <see cref="ICollection{T}"/>.</typeparam>
    /// <returns>The <see cref="ICollection{T}"/> with the added elements.</returns>
    public static TCollection AddRange<TCollection, T>(this TCollection collection, IEnumerable<T> thingsToAdd)
        where TCollection : ICollection<T>
    {
        collection.ForEach(item => collection.Add(item));
        return collection;
    }

    /// <summary>
    /// Removes the specified elements from the <see cref="ICollection{T}"/>.
    /// </summary>
    /// <param name="collection">The collection from which to remove the elements</param>
    /// <param name="removeRange">The elements to remove from the <see cref="ICollection{T}" /></param>
    /// <typeparam name="T">The type of elements in the <see cref="ICollection{T}"/>.</typeparam>
    /// <typeparam name="TCollection">The type of the <see cref="ICollection{T}"/>.</typeparam>
    /// <returns>The <see cref="ICollection{T}"/> with the removed elements.</returns>
    public static TCollection RemoveRange<TCollection, T>(this TCollection collection, IEnumerable<T> removeRange) where TCollection : ICollection<T>
    {
        removeRange.ToList().ForEach(item => collection.Remove(item));
        return collection;
    }

    /// <summary>
    /// Removes the elements from the collection that match the specified predicate.
    /// </summary>
    /// <param name="collection">The collection from which to remove the elements.</param>
    /// <param name="predicate">The predicate to match the elements to remove.</param>
    /// <typeparam name="T">The type of elements in the <see cref="ICollection{T}"/>.</typeparam>
    /// <typeparam name="TCollection">The type of the <see cref="ICollection{T}"/>.</typeparam>
    /// <returns>The <see cref="ICollection{T}"/> with the removed elements.</returns>
    public static TCollection Without<TCollection, T>(this TCollection collection, Func<T, bool> predicate) where TCollection : ICollection<T>
    {
        collection.RemoveRange(collection.Where(predicate).ToList());
        return collection;
    }

    /// <summary>
    /// Returns all elements from <paramref name="collection"/> that <b>don't</b> match the specified predicate.
    /// </summary>
    /// <param name="collection">The collection from which to select the elements.</param>
    /// <param name="predicate">The predicate to match the elements to not select.</param>
    /// <typeparam name="T">The type of elements in the <see cref="ICollection{T}"/>.</typeparam>
    /// <typeparam name="TCollection">The type of the <see cref="ICollection{T}"/>.</typeparam>
    /// <returns>The <see cref="ICollection{T}"/> without the matchings elements.</returns>
    public static ICollection<T> Except<TCollection, T>(this TCollection collection, Func<T, bool> predicate) where TCollection : ICollection<T>
        => collection.Except(collection.Where(predicate)).ToList();
}
