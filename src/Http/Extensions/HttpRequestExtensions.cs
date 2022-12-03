using System.Net.Mime;
/*
 * HttpRequestExtensions.cs
 *
 *   Created: 2022-11-26-11:58:30
 *   Modified: 2022-11-26-11:58:30
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */

namespace Microsoft.AspNetCore.Http;
using static System.Net.Http.Headers.HttpRequestHeaderNames;
using static System.Net.Mime.MediaTypeNames;

public static partial class HttpRequestExtensions2
{
    public static string GetContentType(this HttpRequest req)
        => req.ContentType ?? req.GetHeaderParam<string>(ContentType) ?? ApplicationMediaTypeNames.Json;
}
