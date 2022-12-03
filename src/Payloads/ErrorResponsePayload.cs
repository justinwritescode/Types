/*
 * ErrorResponsePayload.cs
 *
 *   Created: 2022-11-26-04:57:24
 *   Modified: 2022-11-26-04:57:24
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace JustinWritesCode.Payloads;

using System.Text;
using JustinWritesCode.Payloads.Abstractions;

public struct ErrorResponsePayload : IErrorResponsePayload
{
    public ErrorResponsePayload() : this(default, default) { }
    public ErrorResponsePayload(string? message = default, string? stackTrace = default)
    {
        Message = message ?? string.Empty;
        StackTrace = stackTrace;
        StringValue = message ?? string.Empty;
    }
    public ErrorResponsePayload(Exception ex) : this(ex.Message, ex.StackTrace) { }
    public ErrorResponsePayload(object value, Exception ex) : this(value, ex.Message, ex.StackTrace) { }
    public ErrorResponsePayload(object value, string? message = default, string? stackTrace = default) : this(message, stackTrace) { Value = value; }

    public string? StackTrace { get; set; }
    public bool IsSuccess { get => false; set { } }
    public string Message { get; set; }
    public object? Value { get; set; }
    public string StringValue { get; set; }
}
