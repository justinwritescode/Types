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

namespace JustinWritesCode.Http.Extensions;

using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Text.Json;
using System.Linq;

public static class HttpRequestExtensions
{
    public static async Task<T?> ReadRequestBodyAsAsync<T>(this HttpRequest req)
        => JsonSerializer.Deserialize<T>(await new StreamReader(req.Body).ReadToEndAsync().ConfigureAwait(false));

    public static T GetQueryStringParam<T>(this HttpRequest req, string name, T? defaultValue = default)
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

    public static Task WriteResponseAsync<T>(this HttpResponse res, T value)
        => res.WriteAsync(JsonSerializer.Serialize(value));
}
