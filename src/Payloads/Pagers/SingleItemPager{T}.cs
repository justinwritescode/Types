/*
 * SingleItemPager{T}.cs
 *
 *   Created: 2022-11-29-08:46:23
 *   Modified: 2022-11-29-08:46:23
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads;

using System.Diagnostics;
using JustinWritesCode.Payloads.Abstractions;

[DebuggerDisplay($"{{{nameof(StringValue)}}}, {nameof(Page)}: {{{nameof(Page)}}} of {{{nameof(TotalRecords)}}}")]
public class SingleItemPager<T> : Pager<T>, ISingleItemPager<T>
{
    public SingleItemPager(T value, int pageNumber, int totalRecords)
    : base(new[] { value }, pageNumber, 1, totalRecords)
    {
        Item = ((IPayload<T>)this).Value = value!;
        Page = pageNumber;
        TotalRecords = totalRecords;
        Message = string.Empty;
        StringValue = value.ToString();
    }

    public T Item { get; set; }

    [JsonIgnore]
    T IPayload<T>.Value { get; set; }

    // public int TotalRecords { get; set; }
    // public int PageNumber { get; set; }
    // public int PageSize { get => 1; set { } }
    // public int Page { get; set; }

    // public int PageStartIndex => PageNumber - 1;

    // public int PageEndIndex => PageNumber - 1;
    // public bool IsLastPage => PageNumber >= TotalRecords;

    // public bool HasPreviousPage => PageNumber > 1;

    // public bool HasNextPage => PageNumber < TotalRecords;

    // public bool IsSuccess { get; set; }
    // public string Message { get; set; }
    // public string StringValue { get; set; }
}
