//
// HttpRequestBodyExtensions.cs
//
//   Created: 2022-10-31-08:17:52
//   Modified: 2022-10-31-08:18:19
//
//   Author: Justin Chase <justin@justinwritescode.com>
//
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
//

namespace Microsoft.AspNetCore.Http;

using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

public static partial class HttpRequestExtensions2
{
    public static async Task<T?> ReadFromJsonAsync<T>(this HttpRequest req)
        => JsonSerializer.Deserialize<T>(await new StreamReader(req.Body).ReadToEndAsync().ConfigureAwait(false));

    public static T? GetQueryStringParam<T>(this HttpRequest req, string name, T? defaultValue = default)
        => req.Query.ContainsKey(name) ? (T)Convert.ChangeType(req.Query[name].First(), typeof(T)) : defaultValue;

    public static T GetQueryStringEnum<T>(this HttpRequest req, string name, T defaultValue = default)
        where T : struct, Enum
        => req.Query.ContainsKey(name) ?
                Enum.TryParse<T>(req.Query[name].First(), out var result) ?
                result :
                int.TryParse(req.Query[name].First(), out var intResult) ?
                    (T)Enum.ToObject(typeof(T), intResult) :
                    defaultValue :
                defaultValue;

    public static T? GetHeaderParam<T>(this HttpRequest req, string name, T? defaultValue = default)
        => req.Headers.ContainsKey(name) ? (T)Convert.ChangeType(req.Headers[name].First(), typeof(T)) : defaultValue;

    public static T GetHeaderEnum<T>(this HttpRequest req, string name, T defaultValue = default)
        where T : struct, Enum
        => req.Headers.TryGetValue(name, out var stringValue) &&
                Enum.TryParse<T>(stringValue, out var enumValue) ?
                enumValue :
                int.TryParse(stringValue, out var intResult) ?
                    (T)Enum.ToObject(typeof(T), intResult) :
                    defaultValue;

    public static Task WriteResponseAsync<T>(this HttpResponse res, T value)
        => res.WriteAsync(JsonSerializer.Serialize(value));
}
