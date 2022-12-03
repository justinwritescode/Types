/*
 * StringWithRegexPayload.cs
 *
 *   Created: 2022-11-26-04:38:20
 *   Modified: 2022-11-26-04:38:23
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

using JustinWritesCode.Payloads.Abstractions;

namespace JustinWritesCode.Payloads;

public struct StringWithRegexPayload : IPayload<string>
{
    public StringWithRegexPayload() : this(default, default) { }

    public StringWithRegexPayload(string? value, string? regex = default)
    {
        Value = value ?? string.Empty;
        Regex = regex ?? string.Empty;
    }

    [JProp("value")]
    public string Value { get; set; }
    [JProp("regex")]
    public string Regex { get; set; }
    [JProp("stringValue")]
    public string StringValue { get => Value; set { } }
}
