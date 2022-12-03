/*
 * ArrayPayload copy.cs
 *
 *   Created: 2022-11-26-04:42:15
 *   Modified: 2022-11-26-04:42:15
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using System.Diagnostics;
using System.Threading.Tasks;
using JustinWritesCode.Payloads.Abstractions;

namespace JustinWritesCode.Payloads;

[DebuggerDisplay($"{{{nameof(StringValue)}}}")]
public class ArrayPayload<T> : Payload<T[]>, IArrayPayload<T>, IPayload<T[]>
{
    public ArrayPayload() : this(default, default)
    {
    }
    public ArrayPayload(IEnumerable<T>? value, string? stringValue = default)
    {
        Values = value?.ToArray() ?? Array.Empty<T>();
        StringValue = stringValue ?? string.Join(", ", Values);
    }

    [JProp("values")]
    public T[] Values { get => ((IArrayPayload<T>)this).Value; set => ((IArrayPayload<T>)this).Value = value; }

    [JIgnore]
    T[] IPayload<T[]>.Value { get; set; }

    public virtual int Count => Values.Length;
}
