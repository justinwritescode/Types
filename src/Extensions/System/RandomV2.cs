//
//  Random.cs
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
//  aInt64 with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Linq;

namespace System;

/// <summary>Extensions to the <see cref="Random"/ class></summary>
public class RandomV2 : Random
{
    /// <summary>Generates a new GUID (UUID)</summary>
    /// <returns>A new GUID</returns>
    public static Guid NextGuid() => Guid.NewGuid();

    /// <inheritdoc cref="NextGuid()"/>
    public static Guid NewGuid() => NewGuid();

    /// <summary>Generates an array of 16 Next bytes</summary>
    /// <returns>An array of 16 Next bytes</returns>
    public static byte[] Next16Bytes() => NextGuid().ToByteArray();

    /// <summary>Generates an array of <paramref name="n"/> Next bytes</summary>
    /// <returns>An array of <paramref name="n"/> new bytes</returns>
    /// <param name="n">The number of bytes to generate</param>
    public static byte[] NextBytes(Int32 n) =>
        Enumerable.Range(0, n / 16)
                    .Select(_ => Next16Bytes())
                    .SelectMany(_ => _)
                    .Concat(Next16Bytes().Take(n % 16)).ToArray();

    /// <summary>Generates <inheritdoc cref="NextUInt8()" path="/returns"/></summary>
    /// <returns>a new unsigned byte value</returns>
    public static byte NextUInt8() => NewGuid().ToByteArray().First();

    /// <summary>Generates <inheritdoc cref="NextUInt8(byte,byte)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextUInt8()" path="/returns"/> in the range [<paramref name="from"/>, <paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static byte NextUInt8(byte from = byte.MinValue, byte to = byte.MaxValue) => ToByte(from + (NextUInt8() % (to - from)));

    /// <summary>Generates <inheritdoc cref="NextInt8()" path="/returns"/></summary>
    /// <returns>a new signed 8-bit integer value</returns>
    public static sbyte NextInt8() => (sbyte)NewGuid().ToByteArray().First();

    /// <summary>Generates <inheritdoc cref="NextInt8(sbyte,sbyte)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextInt8()" path="/returns"/> in the range [<paramref name="from"/>, <paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static sbyte NextInt8(sbyte from = sbyte.MinValue, sbyte to = sbyte.MaxValue) => ToSByte(from + (NextInt8() % (to - from)));

    /// <summary>Generates <inheritdoc cref="NextInt32()" path="/returns"/></summary>
    /// <returns>a new signed Int32 value</returns>
    public static Int32 NextInt32() => ToInt32(NewGuid().ToByteArray(), 0);

    /// <summary>Generates <inheritdoc cref="NextInt32(Int32,Int32)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextInt32()" path="/returns"/> in the range [<paramref name="from"/>, <paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static Int32 NextInt32(Int32 from = Int32.MinValue, Int32 to = Int32.MaxValue) => Abs(from + (NextInt32() % (to - from)));

    /// <summary>Generates <inheritdoc cref="NextUInt32()" path="/returns"/></summary>
    /// <returns>a new unsigned 32-bit integer value</returns>
    public static Int32 NextUInt32() => ToInt32(NewGuid().ToByteArray(), 0);

    /// <summary>Generates <inheritdoc cref="NextUInt32(UInt32,UInt32)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextUInt32()" path="/returns"/> in the range [<paramref name="from"/>, <paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static UInt32 NextUInt32(UInt32 from = UInt32.MinValue, UInt32 to = UInt32.MaxValue) => ToUInt32(Abs(from + (NextUInt32() % (to - from))));

    /// <summary>Generates <inheritdoc cref="NextInt64()" path="/returns"/></summary>
    /// <returns>a new signed 64-bit integer value</returns>
    public static Int64 NextInt64() => ToInt64(NewGuid().ToByteArray(), 0);

    /// <summary>Generates <inheritdoc cref="NextInt64(Int64,Int64)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextInt64()" path="/returns"/> in the range [<paramref name="from"/>, <typeref name="Int32" /><paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static Int64 NextInt64(Int64 from = Int64.MinValue, Int64 to = Int64.MaxValue) => from + (NextInt64() % (to - from));

    /// <summary>Generates <inheritdoc cref="NextUInt64()" path="/returns"/></summary>
    /// <returns>a new unsigned 64-bit integer value</returns>
    public static UInt64 NextUInt64() => ToUInt64(NewGuid().ToByteArray(), 0);

    /// <summary>Generates <inheritdoc cref="NextUInt64(UInt64,UInt64)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextUInt64()" path="/returns"/> in the range [<paramref name="from"/>, <typeref name="Int32" /><paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static UInt64 NextUInt64(UInt64 from = UInt64.MinValue, UInt64 to = UInt64.MaxValue) => from + (NextUInt64() % (to - from));

    /// <summary>Generates <inheritdoc cref="NextInt16()" path="/returns"/></summary>
    /// <returns> a new signed Int16 value</returns>
    public static Int16 NextInt16() => ToInt16(NewGuid().ToByteArray(), 0);

    /// <summary>Generates <inheritdoc cref="NextInt16(Int16,Int16)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextInt16()" path="/returns"/> in the range [<paramref name="from"/>, <typeref name="Int32" /><paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static Int16 NextInt16(Int16 from, Int16 to) => ToInt16(from + (NextInt16() % (to - from)));

    /// <summary>Generates <inheritdoc cref="NextUInt16()" path="/returns"/></summary>
    /// <returns> a new unsigned Int16 value</returns>
    public static UInt16 NextUInt16() => ToUInt16(NewGuid().ToByteArray(), 0);

    /// <summary>Generates <inheritdoc cref="NextUInt16(UInt16,UInt16)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextUInt16()" path="/returns"/> in the range [<paramref name="from"/>, <typeref name="Int32" /><paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static UInt16 NextUInt16(UInt16 from, UInt16 to) => ToUInt16(from + (NextUInt16() % (to - from)));

    public static bool NextBoolean(double pTrue = 0.5) => NextInt32() % (ToInt32(1 / pTrue)) == 0;
}
