//
//  EqualityComparer.cs
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
using System.Diagnostics.CodeAnalysis;

namespace System.Collections.Generic;

public class LambdaEqualityComparer<T> : IEqualityComparer<T>
{
    private readonly Func<T, T, bool> _comparer;
    private readonly Func<T, int> _getHashCode;
    private static readonly Func<T, int> _defaultGetHashCode = t =>
    {
#if NETSTANDARD2_1_OR_GREATER
        var hashCode = new HashCode();
        hashCode.Add(t);
        return hashCode.ToHashCode();
#else
        return (t?.GetHashCode() ?? default);
#endif
    };

    public LambdaEqualityComparer(Comparer<T> comparer, Func<T, int> getHashCode = null) : this((x, y) => (comparer.Compare(x, y) == 0), getHashCode) { }
    public LambdaEqualityComparer(Func<T, T, bool> comparer, Func<T, int> getHashCode = null)
    {
        _comparer = comparer;
        _getHashCode = getHashCode ?? _defaultGetHashCode;
    }

    public bool Equals(T x, T y) => _comparer(x, y);

    public int GetHashCode(/*[DisallowNull]*/ T obj) => _getHashCode(obj);
}
