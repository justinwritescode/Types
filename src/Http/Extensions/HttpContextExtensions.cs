// 
// HttpContextExtensions.cs
// 
//   Created: 2022-10-31-08:17:52
//   Modified: 2022-10-31-08:17:54
// 
//   Author: Justin Chase <justin@justinwritescode.com>
//   
//   Copyright © 2022 Justin Chase, All Rights Reserved
//      License: MIT (https://opensource.org/licenses/MIT)
// 

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace JustinWritesCode.Http.Extensions;

public static class HttpContextExtensions
{

    public static async Task<bool> ExecuteSecurityMiddlewareAsync(this HttpContext ctx)
    {
        var authHeader = ctx.Request.Headers["Authorization"].FirstOrDefault();
        var requestingIp = ctx.Connection.RemoteIpAddress;
        var allowedIps = Environment.GetEnvironmentVariable("ALLOWED_IPS")?.Split(';') ?? Array.Empty<string>();
        var apiKey = Environment.GetEnvironmentVariable("BACKROOM_API_KEY");
        if (!allowedIps.Contains(requestingIp.ToString()) && (authHeader != "Bearer " + Environment.GetEnvironmentVariable("BACKROOM_API_KEY")))
        {
            ctx.Response.StatusCode = 401;
            await ctx.Response.WriteAsync("Unauthorized");
            return false;
        }
        return true;
    }
}
