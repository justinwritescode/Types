/*
 * Randoms.cs
 *
 *   Created: 2022-10-23-11:42:05
 *   Modified: 2022-12-02-11:19:03
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System;
using System.Linq;

namespace System;
using static System.Convert;
using static System.Math;

/// <summary>Extensions to the <see cref="Random" /> class</summary>
public class Randoms : System.Random
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
    public static byte[] NextBytes( int n) =>
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
    /// <returns>a new signed  int value</returns>
    public static  int NextInt32() => ToInt32(NewGuid().ToByteArray());

    /// <summary>Generates <inheritdoc cref="NextInt32( int, int)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextInt32()" path="/returns"/> in the range [<paramref name="from"/>, <paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static  int NextInt32( int from =  int.MinValue,  int to =  int.MaxValue) => Abs(from + (NextInt32() % (to - from)));

    /// <summary>Generates <inheritdoc cref="NextUInt32()" path="/returns"/></summary>
    /// <returns>a new unsigned 32-bit integer value</returns>
    public static  int NextUInt32() => ToInt32(NewGuid().ToByteArray());

    /// <summary>Generates <inheritdoc cref="NextUInt32(UInt32,UInt32)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextUInt32()" path="/returns"/> in the range [<paramref name="from"/>, <paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static UInt32 NextUInt32(UInt32 from = UInt32.MinValue, UInt32 to = UInt32.MaxValue) => ToUInt32(Abs(from + (NextUInt32() % (to - from))));

    /// <summary>Generates <inheritdoc cref="NextInt64()" path="/returns"/></summary>
    /// <returns>a new signed 64-bit integer value</returns>
    public static  long NextInt64() => ToInt64(NewGuid().ToByteArray());

    /// <summary>Generates <inheritdoc cref="NextInt64(long, long)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextInt64()" path="/returns"/> in the range [<paramref name="from"/>, <typeref name=" int" /><paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static  long NextInt64( long from =  long.MinValue,  long to =  long.MaxValue) => from + (NextInt64() % (to - from));

    /// <summary>Generates <inheritdoc cref="NextUInt64()" path="/returns"/></summary>
    /// <returns>a new unsigned 64-bit integer value</returns>
    public static UInt64 NextUInt64() => ToUInt64(NewGuid().ToByteArray());

    /// <summary>Generates <inheritdoc cref="NextUInt64(UInt64,UInt64)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextUInt64()" path="/returns"/> in the range [<paramref name="from"/>, <typeref name=" int" /><paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static UInt64 NextUInt64(UInt64 from = UInt64.MinValue, UInt64 to = UInt64.MaxValue) => from + (NextUInt64() % (to - from));

    /// <summary>Generates <inheritdoc cref="NextInt16()" path="/returns"/></summary>
    /// <returns> a new signed Int16 value</returns>
    public static Int16 NextInt16() => ToInt16(NewGuid().ToByteArray());

    /// <summary>Generates <inheritdoc cref="NextInt16(Int16,Int16)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextInt16()" path="/returns"/> in the range [<paramref name="from"/>, <typeref name=" int" /><paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static Int16 NextInt16(Int16 from, Int16 to) => ToInt16(from + (NextInt16() % (to - from)));

    /// <summary>Generates <inheritdoc cref="NextUInt16()" path="/returns"/></summary>
    /// <returns> a new unsigned Int16 value</returns>
    public static UInt16 NextUInt16() => ToUInt16(NewGuid().ToByteArray());

    /// <summary>Generates <inheritdoc cref="NextUInt16(UInt16,UInt16)" path="/returns"/></summary>
    /// <returns><inheritdoc cref="NextUInt16()" path="/returns"/> in the range [<paramref name="from"/>, <typeref name=" int" /><paramref name="to"/>]</returns>
    /// <param name="from">The lower bound of the range to generate the Next number</param>
    /// <param name="to">The upper bound of the range to generate the Next number</param>
    public static UInt16 NextUInt16(UInt16 from, UInt16 to) => ToUInt16(from + (NextUInt16() % (to - from)));

    public static bool NextBoolean(double pTrue = 0.5) => NextInt32() % (ToInt32(1 / pTrue)) == 0;
}
