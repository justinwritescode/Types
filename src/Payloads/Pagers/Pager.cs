// 
// Pager.cs
// 
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:58:34
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

using System.Runtime.Serialization;
// 
// Pager.cs
// 
//   Created: 2022-10-31-08:33:05
//   Modified: 2022-10-31-08:45:12
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

using System.Collections.Generic;
using static System.Math;
namespace JustinWritesCode.Payloads;

public record Pager<T>(IEnumerable<T?>? Value, int PageNumber, int PageSize, int TotalRecords, bool Success = true, string? Error = null, string? Message = null, string? StackTrace = null) 
    : ResponsePayload<IEnumerable<T?>?>(Value, Success, Error, Message, StackTrace)
{
    // public Pager(IEnumerable<T?>? Value, int PageNumber, int PageSize, int Total, bool Success = true, string? Error = null, string? Message = null, string? StackTrace = null)
    //     : base(Value, Success, Error, Message, StackTrace)
    // {
    //     this.PageNumber = PageNumber;
    //     this.PageSize = PageSize;
    //     this.Total = Total;
    // }

    public virtual IEnumerable<T?>? Items => this.Value;
    public virtual int TotalRecords { get; init; } = TotalRecords;
    public virtual int PageNumber { get; init; } = PageNumber;
    public virtual int PageSize { get; init; } = PageSize;
    // public virtual int Total { get; }

    public virtual int PageStartIndex => (this.PageNumber - 1) * this.PageSize;
    public virtual int PageEndIndex => this.PageNumber * this.PageSize;
    public virtual int TotalPages => (int)Ceiling((double)this.TotalRecords / this.PageSize);
    public bool IsLastPage => this.PageNumber >= this.TotalPages;
    public virtual bool HasPreviousPage => this.PageNumber > 1;
    public virtual bool HasNextPage => this.PageNumber < this.TotalPages;
}
