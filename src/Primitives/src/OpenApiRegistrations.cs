/*
 * OpenApiRegistrations.cs
 *
 *   Created: 2022-12-28-01:42:05
 *   Modified: 2022-12-28-01:42:05
 *
 *   Author: Justin Chase <justin@justinwritescode.com>
 *
 *   Copyright © 2022 Justin Chase, All Rights Reserved
 *      License: MIT (https://opensource.org/licenses/MIT)
 */
#if NETSTANDARD2_0_OR_GREATER

namespace Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;
using System.Reflection;

public static class OpenApiRegistrations
{

#if NET6_0_OR_GREATER
    public static WebApplicationBuilder Describe<T>(this WebApplicationBuilder builder)
        where T : IStringWithRegexValueObject<T>
    {
        builder.Services.Describe<T>();
        return builder;
    }
#endif

#if NETSTANDARD2_0_OR_GREATER
        public static IServiceCollection Describe<T>(this IServiceCollection services)
        where T : IStringWithRegexValueObject<T>
    {
        services.ConfigureSwaggerGen(options =>
        {
#if NET6_0_OR_GREATER
            options.SchemaGeneratorOptions.CustomTypeMappings[typeof(T)] = () => new OpenApiSchema
            {
                Type = "string",
                Pattern = T.RegexString,
                Format = typeof(T).Name,
                Description = T.Description,
                Example = new OpenApiString(T.ExampleValue.ToString())
            };
#else
            options.SchemaGeneratorOptions.CustomTypeMappings[typeof(T)] = () => new OpenApiSchema
            {
                Type = "string",
                Pattern = typeof(T).GetRuntimeProperty(nameof(IStringWithRegexValueObject<ObjectId>.RegexString)).GetValue(null) as string,
                Format = typeof(T).Name,
                Description = typeof(T).GetRuntimeProperty(nameof(IStringWithRegexValueObject<ObjectId>.Description)).GetValue(null) as string,
                Example = new OpenApiString(typeof(T).GetRuntimeProperty(nameof(IStringWithRegexValueObject<ObjectId>.ExampleValue)).GetValue(null).ToString())
            };
#endif
        });
        return services;
    }
#else
    public static IServiceCollection Describe<T>(this IServiceCollection services)
        where T : IStringWithRegexValueObject<T>
    {
        throw new PlatformNotSupportedException("This feature is not supported by this framework.  Upgrade to .NET Standard 2.0 or higher to use it.");
    }
#endif
}
#endif
