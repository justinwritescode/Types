namespace JustinWritesCode.Payloads;

using System.Diagnostics;
using JustinWritesCode.Payloads.Abstractions;
using static System.Math;

[DebuggerDisplay($"{{{nameof(StringValue)}}}, {nameof(Page)}: {{{nameof(Page)}}} of {{{nameof(TotalRecords)}}}")]
public class SingleItemPager : SingleItemPager<object>
{
    public SingleItemPager(object value, int pageNumber, int totalRecords)
        : base(value, pageNumber, totalRecords)
    {
    }
}
