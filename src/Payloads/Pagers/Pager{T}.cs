/*
 * Pager{T}.cs
 *
 *   Created: 2022-11-29-08:42:16
 *   Modified: 2022-11-29-08:42:28
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Diagnostics;
using static System.Math;

namespace JustinWritesCode.Payloads;

[DebuggerDisplay($"{{{nameof(StringValue)}}}, {nameof(Page)}: {{{nameof(Page)}}} of {{{nameof(TotalRecords)}}}")]
public class Pager<T> : IPager<T>
{
    public Pager(T[] items, int page, int pageSize, int totalRecords, string? message = default)
    {
        ((IPayload<T[]>)this).Value = items ?? Array.Empty<T>();
        Page = page;
        PageSize = pageSize;
        TotalRecords = totalRecords;
        Message = message ?? string.Empty;
    }

    [JsonIgnore]
    T[] IPayload<T[]>.Value { get; set; }

    [JProp("items")]
    public virtual T[] Items { get => ((IPayload<T[]>)this).Value; set => ((IPayload<T[]>)this).Value = value; }

    public virtual string StringValue { get; set; }
    public virtual bool IsSuccess { get; set; }
    public virtual string Message { get; set; }

    public virtual int TotalRecords { get; set; }
    public virtual int PageNumber { get; set; }
    public virtual int PageSize { get; set; }

    public virtual int Page { get; set; }
    public virtual int PageStartIndex => (PageNumber - 1) * PageSize;
    public virtual int PageEndIndex => PageNumber * PageSize;
    public virtual int TotalPages => (int)Ceiling((double)TotalRecords / PageSize);
    public virtual bool IsLastPage => PageNumber >= TotalPages;
    public virtual bool HasPreviousPage => PageNumber > 1;
    public virtual bool HasNextPage => PageNumber < TotalPages;
}
