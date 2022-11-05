// 
// SingleItemPager.cs
// 
//   Created: 2022-10-31-09:34:37
//   Modified: 2022-10-31-04:34:53
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

namespace JustinWritesCode.Payloads;
using static System.Math;

public record SingleItemPager<T>(T Value, int PageNumber, int Total, bool Success = true, string? Error = null, string? Message = null, string? StackTrace = null)
     : ResponsePayload<T>(Value, Success, Error, Message, StackTrace)
{
    // public Pager(IEnumerable<T?>? Value, int PageNumber, int PageSize, int Total, bool Success = true, string? Error = null, string? Message = null, string? StackTrace = null)
    //     : base(Value, Success, Error, Message, StackTrace)
    // {
    //     this.PageNumber = PageNumber;
    //     this.PageSize = PageSize;
    //     this.Total = Total;
    // }

    public virtual T Item => this.Value;
    public virtual int TotalRecords { get; init; } = Total;
    // public virtual int PageNumber { get; init; } = PageNumber;
    public virtual int PageSize => 1;
    // public virtual int Total { get; }

    public virtual int PageStartIndex => (this.PageNumber - 1) * this.PageSize;
    public virtual int PageEndIndex => this.PageNumber * this.PageSize;
    public virtual int TotalPages => (int)Ceiling((double)this.TotalRecords / this.PageSize);
    public bool IsLastPage => this.PageNumber >= this.TotalPages;
    public virtual bool HasPreviousPage => this.PageNumber > 1;
    public virtual bool HasNextPage => this.PageNumber < this.TotalPages;
}
