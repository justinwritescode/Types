/*
 * IEnumerableExtensions.cs
 *
 *   Created: 2022-12-27-08:55:30
 *   Modified: 2022-12-27-08:55:30
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

#if !JUSTINS_IENUMERABLE_EXTENSIONS
#define JUSTINS_IENUMERABLE_EXTENSIONS

namespace System.Collections.Generic;

public static class JustinsIEnumerableExtensions
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> source) where T : class
    {
        return source.Where(item => item != null)!;
    }

    public static string Join(this IEnumerable source, string separator)
    {
        return string.Join(separator, source.OfType<object>());
    }
}
#endif
