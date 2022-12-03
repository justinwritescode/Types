/*
 * IPager.cs
 *
 *   Created: 2022-11-26-05:15:42
 *   Modified: 2022-11-26-05:15:42
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads.Abstractions;

public interface IPager : IPager<object>
{
    // [JProp("items")]
    // T[] Items { get; set; }
    // int TotalRecords { get; set; }
    // int PageSize { get; set; }

    // int Page { get; set; }
    // int PageStartIndex  { get; }
    // int PageEndIndex { get; }
    // int TotalPages { get; }
    // bool IsLastPage { get; }
    // bool HasPreviousPage { get; }
    // bool HasNextPage { get; }
}
