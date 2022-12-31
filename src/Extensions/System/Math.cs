/*
 *
 * Math.cs
 *
 *   Created: 2022-11-12-07:23:53
 *   Modified: 2022-11-12-07:25:59
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 *
 */

namespace System;
using static System.Math;
// #if DEFINE_INTERNAL
public static class MathExtensions
// #else
// public static class MathExtensions
// #endif
{
    public const double π = PI;

    public static double ToRadians(this double degrees) => degrees * (π / 180.0);
    public static double ToDegrees(this double radians) => radians * (180.0 / π);
    public static bool IsBetween(this double value, double min, double max) => value >= min && value <= max;
    public static bool IsBetween(this int value, int min, int max) => value >= min && value <= max;
    public static bool IsBetween(this long value, long min, long max) => value >= min && value <= max;
    public static bool IsBetween(this float value, float min, float max) => value >= min && value <= max;
}
